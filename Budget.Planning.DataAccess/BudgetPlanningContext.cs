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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}