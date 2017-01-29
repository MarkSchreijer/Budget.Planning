using System;
using Budget.Planning.DataAccess.Helpers;

namespace Budget.Planning.DataAccess.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountNumberId { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime InterestDate { get; set; }
        public DebetCredit DebitCredit { get; set; }
        public decimal Amount { get; set; }
        public int ContraAccountId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingCode BookingCode { get; set; }
        public string Filler { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string Description6 { get; set; }
        public string EndToEndId { get; set; }
    }
}