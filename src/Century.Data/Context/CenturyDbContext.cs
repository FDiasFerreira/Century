using System.Linq;
using Century.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Century.Data.Context
{
    public class CenturyDbContext : DbContext
    {
        public CenturyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CenturyDbContext).Assembly);

            ////para na hora de excluir um supplier leve os products junto
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }   
}
