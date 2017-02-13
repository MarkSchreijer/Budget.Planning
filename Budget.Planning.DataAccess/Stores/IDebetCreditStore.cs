using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public interface IDebetCreditStore
    {
        DebetCredit FindDebetCreditByCode(string code);
        DebetCredit FindDebetCreditById(int id);
        List<DebetCredit> FindAllDebetCredit();
    }
}
