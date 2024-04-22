using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NomNom.Web.Models;
using System.Reflection.Emit;

namespace NomNom.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GrilledCheese> GrilledCheeses { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var vendor = new IdentityRole("vendor");
            vendor.NormalizedName = "vendor";

            builder.Entity<IdentityRole>().HasData(admin, client, vendor);

            builder.Entity<Order>()
                .HasMany(o => o.GrilledCheeses)
                .WithOne(g => g.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
