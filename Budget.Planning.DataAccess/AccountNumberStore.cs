using System.Collections.Generic;
using System.Linq;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess
{
    public class AccountNumberStore : IAccountNumberStore
    {
        private readonly BudgetPlanningContext _context;

        public AccountNumberStore()
        {
            _context = new BudgetPlanningContext();
        }

        public List<AccountNumber> FindAllAccountNumbers()
        {
            return _context.AccountNumbers.ToList();
        }
    }
}