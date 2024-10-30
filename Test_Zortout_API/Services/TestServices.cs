using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Test_Zortout_API.External.Interface;
using Test_Zortout_API.Models;
using Test_Zortout_API.Models.Request;
using Test_Zortout_API.Models.Result;
using Test_Zortout_API.Services.Interface;
using Test_Zortout_API.Helper;
using Azure.Core;
using System.Linq;
using Test_Zortout_API.Repositories.Interface;
using Test_Zortout_API.Entities.ZortExam;
using Test_Zortout_API.Extension;

namespace Test_Zortout_API.Services
{
    public class TestServices : ITestServices
    {
        private readonly IZortApi _zortApi;
        private readonly ITestRepositories _testRepositories;
        public TestServices(IZortApi zortApi, ITestRepositories testRepositories)
        {
            _zortApi = zortApi;
            _testRepositories = testRepositories;
        }

        public async Task<AuthenticateResult> GetAuthenticate(AuthenticateRequest request)
        {
            try
            {
                var getAuthenticate = await _zortApi.Authenticate(request);
                if (!getAuthenticate.Success)
                {
                    ArgumentExceptionHelper.Throw((int)getAuthenticate.Error?.Code, getAuthenticate.Error?.Message);
                }
                AuthenticateResult result = new AuthenticateResult();
                result.AccessToken = getAuthenticate.Data?.AccessToken;
                result.Expiry = (DateTime)(getAuthenticate.Data?.Expiry);
                result.Type = getAuthenticate.Data?.Type;
                return result;
            }
            catch (ArgumentException arEx)
            {
                throw new ArgumentException(arEx.Message);
            }
            catch (Exception ex)
            {
                List<ErrorInnerResource> errorInnerResources = new List<ErrorInnerResource>();
                errorInnerResources.Add(new ErrorInnerResource { Code = 500, Message = ex.Message });
                string json = JsonConvert.SerializeObject(errorInnerResources);
                throw new Exception(json, ex);
            }
        }

        public async Task<List<CostResult>> GetCost(CostRequest request,string token)
        {
            try
            {
                var getCost = await _zortApi.Cost(request.FromDate, request.ToDate, token);
                if (!getCost.Success)
                {
                    ArgumentExceptionHelper.Throw((int)getCost.Error?.Code, getCost.Error?.Message);
                }

                List<CostResult> result = new List<CostResult>();
                if (request.ProductCode != null && request.ProductCode.Any())
                {
                    getCost.Data = getCost.Data.Where(w => w.ProductCode != null && request.ProductCode.Contains((int)w.ProductCode)).ToList();
                }

                var GetProduct = await _testRepositories.GetProduct();

                foreach (var data in getCost.Data)
                {
                    var cost = new CostResult();
                    cost.Timestamp = data.Timestamp;
                    cost.OrderNumber = data.OrderNumber;
                    cost.ProductCode = data.ProductCode;
                    cost.CostPerUnit = data.CostPerUnit;
                    cost.Quantity = data.Quantity;
                    cost.ProductName = MappProductName(data.ProductCode ?? 0, GetProduct);
                    result.Add(cost);
                }

                return result;
            }
            catch (ArgumentException arEx)
            {
                throw new ArgumentException(arEx.Message);
            }
            catch (Exception ex)
            {
                List<ErrorInnerResource> errorInnerResources = new List<ErrorInnerResource>();
                errorInnerResources.Add(new ErrorInnerResource { Code = 500, Message = ex.Message });
                string json = JsonConvert.SerializeObject(errorInnerResources);
                throw new Exception(json, ex);
            }
        }

        private string MappProductName(int ProductCode, List<Product> Product)
        {
            var result = string.Empty;
            if (Product.Any())
            {
                result = Product.Where(w=> w.ProductCode == ProductCode).Select(s=> s.ProductName).FirstOrDefault();
            }
            return result;
        }

        public async Task<List<TotalSalesResult>> GetTotalSales(TotalSalesRequest request)
        {
            try
            {
                if (!DateTimeExtension.CheckFormatDate(request.FromDate) || !DateTimeExtension.CheckFormatDate(request.FromDate))
                {
                    ArgumentExceptionHelper.Throw(400, "Datetime not format");
                }
                var fromDate = DateTimeExtension.ConvertDateTimeFromString(request.FromDate);
                var toDate = DateTimeExtension.ConvertDateTimeFromString(request.ToDate);
                var getTotalSales = await _testRepositories.GetTotalSales(fromDate, toDate, request.ProductCode);

                List<TotalSalesResult> result = getTotalSales;
                return result;
            }
            catch (ArgumentException arEx)
            {
                throw new ArgumentException(arEx.Message);
            }
            catch (Exception ex)
            {
                List<ErrorInnerResource> errorInnerResources = new List<ErrorInnerResource>();
                errorInnerResources.Add(new ErrorInnerResource { Code = 500, Message = ex.Message });
                string json = JsonConvert.SerializeObject(errorInnerResources);
                throw new Exception(json, ex);
            }
        }
    }
}
