using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public interface ITransactionStore
    {
        void InsertTransaction(Transaction transaction);
    }
}