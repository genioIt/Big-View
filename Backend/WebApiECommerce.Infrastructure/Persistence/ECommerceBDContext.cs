using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Domain.Entity;
namespace WebApiEcommerce.Infrastructure.Persistence
{
    public class ECommerceBDContext : DbContext
    {
        public ECommerceBDContext(DbContextOptions<ECommerceBDContext> options)
             : base(options) { }

        //Entities

        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceBDContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItems>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<CartItems>()
             .HasOne(n => n.Users)
             .WithMany(s => s.CartItems)
             .HasForeignKey(n => n.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItems>()
            .HasOne(n => n.Products)
            .WithMany(s => s.CartItems)
            .HasForeignKey(n => n.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<Orders>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<Orders>()
           .HasOne(n => n.Users)
           .WithMany(s => s.Orders)
           .HasForeignKey(n => n.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItems>()
           .HasOne(n => n.Orders)
           .WithMany(s => s.OrderItems)
           .HasForeignKey(n => n.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItems>()
            .HasOne(n => n.Products)
            .WithMany(s => s.OrderItems)
            .HasForeignKey(n => n.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Products>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<Products>()
            .HasOne(p => p.ProductCategories)
            .WithMany(c => c.Products)
            .HasForeignKey(n => n.IdCategory)
            .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<UserSessions>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<UserSessions>()
            .HasOne(n => n.Users)
            .WithMany(s => s.UserSessions)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductCategories>()
           .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<UserRoles>()
            .HasKey(sc => new { sc.Id });

            modelBuilder.Entity<UserRoles>()
            .HasOne(n => n.Users)
            .WithMany(s => s.userRoles)
            .HasForeignKey(n => n.IdUsers)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRoles>()
           .HasOne(n => n.Roles)
           .WithMany(s => s.userRoles)
           .HasForeignKey(n => n.IdRoles)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
