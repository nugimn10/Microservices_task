
using System;
using Microsoft.EntityFrameworkCore;
using MerchantServices.Domain.Models;

namespace MerchantServices.Infrastructure.Presistences
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<MerchantD> Merchant { get; set; }


    }
}