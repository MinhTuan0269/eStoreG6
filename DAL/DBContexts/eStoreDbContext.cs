using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContexts
{
    public class eStoreDbContext : DbContext
    {
        public eStoreDbContext(DbContextOptions<eStoreDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Tự động tăng (Identity) cho tất cả khóa chính kiểu int
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var pk = entity.FindPrimaryKey();
                if (pk != null && pk.Properties.Count == 1)
                {
                    var property = pk.Properties[0];
                    if (property.ClrType == typeof(int))
                    {
                        property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    }
                }
            }

            // 🔹 Composite key cho OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // 🔹 One-to-one: Payment - Order
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId);

            // 🔹 Định dạng số thập phân
            modelBuilder.Entity<Order>()
                .Property(o => o.Freight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

           
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Role)
                .WithMany(r => r.Members)
                .HasForeignKey(m => m.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Customer" }
            );
        }
    }
}
