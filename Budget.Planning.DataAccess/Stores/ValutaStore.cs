using System.Collections.Generic;
using System.Linq;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public class ValutaStore : IValutaStore
    {
        private readonly BudgetPlanningContext _context;

        public ValutaStore()
        {
            _context = new BudgetPlanningContext();  
        }

        public Valuta FindValutaById(int id)
        {
            return _context.Valutas.FirstOrDefault(v => v.Id == id);
        }

        public Valuta FindValutaByDescription(string description)
        {
            return _context.Valutas.FirstOrDefault(v => v.Description == description);
        }

        public List<Valuta> FindAllValuta()
        {
            return _context.Valutas.ToList();
        }
    }
}