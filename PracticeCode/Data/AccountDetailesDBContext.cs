using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductCode.Models.CreditDetails;

namespace ProductBase.Data
{
    public class AccountDetailesDBContext:DbContext

    {
        //public ProdectDetailesDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        //{

        //}
        public AccountDetailesDBContext(DbContextOptions<AccountDetailesDBContext> options)
        : base(options)
        {
        }
        public DbSet<CreditAccountDetails> Reg { get; set; }
       
    }
}
