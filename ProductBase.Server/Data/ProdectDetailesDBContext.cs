using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductBase.Models.Domain;
using ProductBase.Models.Product;

namespace ProductBase.Data
{
    public class ProdectDetailesDBContext:DbContext

    {
        //public ProdectDetailesDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        //{

        //}
        public ProdectDetailesDBContext(DbContextOptions<ProdectDetailesDBContext> options)
        : base(options)
        {
        }
        public DbSet<Regestration> Reg { get; set; }
        public DbSet<ProductDetails> productdetails { get; set; }
        public DbSet<ProductType> producttype { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductType>()
        //        .HasKey(p => p.PTId);
        //}
    }
}
