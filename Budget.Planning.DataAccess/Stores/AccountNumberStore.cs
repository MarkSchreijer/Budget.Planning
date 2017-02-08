using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public class AccountNumberStore : IAccountNumberStore
    {
        private readonly BudgetPlanningContext _context;

        public AccountNumberStore()
        {
            _context = new BudgetPlanningContext();
        }

        public Account FindAccountByAccountNumber(string accountNumber)
        {
            return _context.AccountNumbers.FirstOrDefault(a => a.Number == accountNumber);
        }

        public Account InsertAccountNumber(string accountNumber, string accountName)
        {
            if(string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(accountName))
                return null;

            var account = new Account
            {
                Number = accountNumber,
                Name = accountName
            };

            _context.Set<Account>().AddOrUpdate(account);
            _context.SaveChanges();

            return account;
        }

        public List<Account> FindAllAccountNumbers()
        {
            return _context.AccountNumbers.ToList();
        }
    }
}