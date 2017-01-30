using System.Collections.Generic;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess
{
    public interface IAccountNumberStore
    {
        List<AccountNumber> FindAllAccountNumbers();
    }
}
