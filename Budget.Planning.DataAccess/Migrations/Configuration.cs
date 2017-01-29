using Budget.Planning.DataAccess.Models;
using System.Data.Entity.Migrations;

namespace Budget.Planning.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BudgetPlanningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudgetPlanningContext context)
        {
            context.AccountNumbers.AddOrUpdate(
               p => p.Id,
                new AccountNumber { Number = "NL18RABO0329190474", Name = "M. Schreijer Eo" },
                new AccountNumber { Number = "NL18RABO0317043455", Name = "M.C. Schreijer" },
                new AccountNumber { Number = "NL83RABO0321816625", Name = "M.J. Schreijer" }
                );
        }
    }
}