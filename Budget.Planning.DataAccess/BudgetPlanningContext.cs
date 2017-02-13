using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess
{
    public class BudgetPlanningContext : DbContext
    {
        public BudgetPlanningContext() : base("BudgetPlanningContext")
        {
        }

        public DbSet<Account> AccountNumbers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DebetCredit> DebetCredits { get; set; }
        public DbSet<Valuta> Valutas { get; set; }
        public DbSet<BookingCode> BookingCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}