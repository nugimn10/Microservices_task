
using System;
using Microsoft.EntityFrameworkCore;
using ProductServices.Domain.Models;

namespace ProductServices.Infrastructure.Presistence
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
         public DbSet<ProductD> Product { get; set; }

    }
}