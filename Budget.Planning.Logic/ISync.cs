using System.Collections.Generic;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.Logic
{
    public interface ISync
    {
        SyncModel SyncTransactions();

        List<AccountNumber> AccountNumbers();
    }
}