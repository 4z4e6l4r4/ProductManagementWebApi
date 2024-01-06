using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Models;
using System.Collections.Generic;

namespace ProductManagementWebApi.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=AZRA;initial catalog=PMWADb;integrated security=true");
            //optionsBuilder.UseSqlServer(@"server=AZRA;database=PMWADb;Trust_Connection=true;MultipleActiveResultSets=true");
        }



        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
