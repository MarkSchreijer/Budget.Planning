using System.Collections.Generic;
using Budget.Planning.DataAccess.Models;

namespace Budget.Planning.DataAccess.Stores
{
    public interface IBookingCodeStore
    {
        BookingCode FindBookingCodeById(int id);
        BookingCode FindBookingCodeByCode(string code);
        BookingCode FindBookingCodeByDescription(string description);
        List<BookingCode> FindAllBookingCodes();
    }
}