using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Test_Zortout_API.Entities.ZortExam;
using Test_Zortout_API.Models.Result;
using Test_Zortout_API.Repositories.Interface;

namespace Test_Zortout_API.Repositories
{
    public class TestRepositories : ITestRepositories
    {
        private readonly ZortExam_DbContext _zortExam_DbContext;

        public TestRepositories(ZortExam_DbContext zortExam_DbContext)
        {
            _zortExam_DbContext = zortExam_DbContext;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await _zortExam_DbContext.Product.ToListAsync();
        }

        public async Task<List<TotalSalesResult>> GetTotalSales(DateTime fromDate, DateTime toDate, int[] ProductCode)
        {
            var result = await _zortExam_DbContext.OrderProduct
           .GroupJoin(_zortExam_DbContext.OrderDetail,
               x => new { x.OrderNumber },
               y => new { y.OrderNumber },
               (x, y) => new { OrderProduct = x, OrderDetail = y })
           .SelectMany(x => x.OrderDetail.DefaultIfEmpty(),
               (x, y) => new { x.OrderProduct, OrderDetail = y })
           .GroupJoin(_zortExam_DbContext.Product,
               x => x.OrderProduct.ProductCode,
               y => y.ProductCode,
               (x, y) => new { OrderProduct = x, Product = y }
           )
           .SelectMany(x => x.Product.DefaultIfEmpty(),
           (x, y) => new { x = x.OrderProduct, Product = y })
           .Select(x => new TotalSalesModel
           {
               ProductCode = x.x.OrderProduct.ProductCode,
               ProductName = x.Product.ProductName,
               TotalSales = x.x.OrderProduct.PricePerUnit * x.x.OrderProduct.Quantity,
               TimeStamp = x.x.OrderDetail.CreatedDate
           })
           .Where(w => ProductCode.Any() && ProductCode.Contains((int)w.ProductCode)
           && (w.TimeStamp.Date >= fromDate.Date  && w.TimeStamp.Date <= toDate.Date))
           .ToListAsync();

             var sumData = result.GroupBy(g => g.ProductCode)
            .Select(cl => new TotalSalesResult
            {
                ProductCode = cl.First().ProductCode,
                ProductName = cl.First().ProductName,
                TotalSales = cl.Sum(c => c.TotalSales),
            }).ToList();

            return sumData;
        }
    }
}
