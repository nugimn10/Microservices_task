
using System;
using Microsoft.EntityFrameworkCore;
using CustomerServices.Domain.Models;

namespace CustomerServices.Infrastructure.Presistences
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<CustomerD> Customer { get; set; }
        public DbSet<Customer_Payment_Card> Customer_Payment_Cards {get; set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Customer_Payment_Card>()
            .HasOne(a => a.customer).WithMany().HasForeignKey(a => a.customer_id);
        }

    }
}