using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public class BookingCodeStore : IBookingCodeStore
    {
        private readonly BudgetPlanningContext _context;

        public BookingCodeStore()
        {
            _context = new BudgetPlanningContext();
        }

        public BookingCode FindBookingCodeById(int id)
        {
            return _context.BookingCodes.FirstOrDefault(b => b.Id == id);
        }

        public BookingCode FindBookingCodeByCode(string code)
        {
            return _context.BookingCodes.FirstOrDefault(b => b.Code == code);
        }

        public BookingCode FindBookingCodeByDescription(string description)
        {
            return _context.BookingCodes.FirstOrDefault(b => b.Description == description);
        }

        public List<BookingCode> FindAllBookingCodes()
        {
            return _context.BookingCodes.ToList();
        }
    }
}