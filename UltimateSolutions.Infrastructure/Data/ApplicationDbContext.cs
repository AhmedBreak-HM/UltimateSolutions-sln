using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UltimateSolutions.Domain.Models;

namespace UltimateSolutions.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApplication>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceMaster> InvoicesMaster { get; set; }
        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole[] {
                    new IdentityRole{ Id="1", Name="Admin",NormalizedName="ADMIN"},
                    new IdentityRole{ Id="2", Name="Member", NormalizedName="MEMBER"}
            });
            builder.Entity<Customer>().HasData(new Customer[] {
                new Customer{Id= 1, Name="Customer-1"},
                new Customer{Id= 2, Name="Customer-2"},
                new Customer{Id= 3, Name="Customer-3"},
            });

            builder.Entity<Product>().HasData(new Product[] {
                new Product{Id= 1, Name="Product-1"},
                new Product{Id= 2, Name="Product-2"},
                new Product{Id= 3, Name="Product-3"},
            });
        }
    }
}