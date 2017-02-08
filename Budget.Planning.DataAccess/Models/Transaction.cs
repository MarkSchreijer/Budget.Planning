using System;

namespace Budget.Planning.DataAccess.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime InterestDate { get; set; }
        public DebetCredit DebitCredit { get; set; }
        public decimal Amount { get; set; }
        public Account ContraAccount { get; set; }
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