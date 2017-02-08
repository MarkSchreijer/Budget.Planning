using System.Data.Entity.Migrations;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public class TransactionStore : ITransactionStore
    {
        private readonly BudgetPlanningContext _context;


        public TransactionStore()
        {
            _context = new BudgetPlanningContext();
        }

        public void InsertTransaction(Transaction transaction)
        {
            _context.Set<Transaction>().AddOrUpdate(transaction);
            _context.SaveChanges();
        }
    }
}