using System.Collections.Generic;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public interface IAccountNumberStore
    {
        Account FindAccountByAccountNumber(string accountNumber);
        Account InsertAccountNumber(string accountNumber, string accountName);
        List<Account> FindAllAccountNumbers();
    }
}