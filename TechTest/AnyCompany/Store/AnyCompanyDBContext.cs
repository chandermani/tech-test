using AnyCompany.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Store
{
    public class AnyCompanyDBContext : DbContext, IAnyCompanyDBContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AnyCompanyDBContext()
        {
        }

        public AnyCompanyDBContext(DbContextOptions<AnyCompanyDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Order>()
                .ToTable("Orders");

            base.OnModelCreating(modelBuilder);
        }
    }
}