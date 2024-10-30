using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Test_Zortout_API.Entities.ZortExam
{
    public class ZortExam_DbContext : DbContext
    {
        public ZortExam_DbContext(DbContextOptions<ZortExam_DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasNoKey();
        }

        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
    }

}
