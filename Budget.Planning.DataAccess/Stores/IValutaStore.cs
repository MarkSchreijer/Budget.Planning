using System.Collections.Generic;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public interface IValutaStore
    {
        Valuta FindValutaById(int id);
        Valuta FindValutaByDescription(string description);
        List<Valuta> FindAllValuta();
    }
}