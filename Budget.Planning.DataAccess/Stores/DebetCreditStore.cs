using System.Collections.Generic;
using System.Linq;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public class DebetCreditStore : IDebetCreditStore
    {
        private readonly BudgetPlanningContext _context;

        public DebetCreditStore()
        {
            _context = new BudgetPlanningContext();
        }

        public DebetCredit FindDebetCreditByCode(string code)
        {
            return _context.DebetCredits.FirstOrDefault(d => d.Code == code);
        }

        public DebetCredit FindDebetCreditById(int id)
        {
            return _context.DebetCredits.FirstOrDefault(d => d.Id == id);
        }

        public List<DebetCredit> FindAllDebetCredit()
        {
            return _context.DebetCredits.ToList();
        }
    }
}