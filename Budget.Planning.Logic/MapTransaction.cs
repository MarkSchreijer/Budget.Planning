using System;
using System.Globalization;
using Budget.Planning.DataAccess.Models;
using Budget.Planning.DataAccess.Stores;
using CsvHelper.Configuration;

namespace Budget.Planning.Logic
{
    public sealed class MapTransaction : CsvClassMap<Transaction>
    {
        public MapTransaction()
        {
            Map(m => m.Account).ConvertUsing(r => ParseAccountNumber(r.GetField<string>(0), string.Empty));
            Map(m => m.Valuta).ConvertUsing(r => ParseValuta(r.GetField<string>(1)));
            Map(m => m.InterestDate).ConvertUsing(r => ParseTransactionDate(r.GetField<string>(2)));
            Map(m => m.DebitCredit).ConvertUsing(r => ParseCreditEdit(r.GetField(3)));
            Map(m => m.Amount).Index(4).TypeConverterOption(NumberStyles.Currency);
            Map(m => m.ContraAccount).ConvertUsing(r => ParseAccountNumber(r.GetField(5), r.GetField(6)));
            Map(m => m.BookingDate).ConvertUsing(r => ParseTransactionDate(r.GetField(7)));
            Map(m => m.BookingCode).ConvertUsing(r => ParseBookingCode(r.GetField(8)));
            Map(m => m.Filler).Index(9);
            Map(m => m.Description1).Index(10);
            Map(m => m.Description2).Index(11);
            Map(m => m.Description3).Index(12);
            Map(m => m.Description4).Index(13);
            Map(m => m.Description5).Index(14);
            Map(m => m.Description6).Index(15);
            Map(m => m.EndToEndId).Index(16);
        }

        private static Account ParseAccountNumber(string number, string name)
        {
            var accountNumberStore = new AccountNumberStore();

            var accountNumber = accountNumberStore.FindAccountByAccountNumber(number) ??
                                accountNumberStore.InsertAccountNumber(number, name);

            return accountNumber;
        }

        private static DebetCredit ParseCreditEdit(string debetCredit)
        {
            var debetCreditStore = new DebetCreditStore();

            var returnValue = debetCreditStore.FindDebetCreditByCode(debetCredit);
            return returnValue;
        }

        private static DateTime ParseTransactionDate(string date)
        {
            if (string.IsNullOrEmpty(date))
                return new DateTime();

            return new DateTime(int.Parse(date.Trim('"').Substring(0, 4)), int.Parse(date.Trim('"').Substring(4, 2)),
                int.Parse(date.Trim('"').Substring(6, 2)));
        }

        private static Valuta ParseValuta(string valuta)
        {
            var valutaStore = new ValutaStore();

            var returnValue = valutaStore.FindValutaByDescription(valuta);
            return returnValue;
        }

        private static BookingCode ParseBookingCode(string bookingCode)
        {
            var bookingCodeStore = new BookingCodeStore();

            var returnValue = bookingCodeStore.FindBookingCodeByCode(bookingCode);
            return returnValue;
        }
    }
}