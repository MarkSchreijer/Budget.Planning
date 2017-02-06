using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using Budget.Planning.DataAccess;
using Budget.Planning.DataAccess.Helpers;
using Budget.Planning.DataAccess.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace Budget.Planning.Logic
{
    public class Sync : ISync
    {
        private readonly string _transactionFile = ConfigurationManager.AppSettings["transactionFile"];
        private readonly string _archiveFolder = ConfigurationManager.AppSettings["archiveFolder"];

        private readonly IAccountNumberStore _accountNumberStore;
        public Sync(IAccountNumberStore accountNumberStore)
        {
            _accountNumberStore = accountNumberStore;
        }

        public SyncModel SyncTransactions()
        {
            return File.Exists(_transactionFile) ? ReadTransactionsFile() : new SyncModel { Status = false, Message = Resource.TransactionNotSucceeded, ErrorMessage = Resource.FileNotFound };
        }

        public List<AccountNumber> AccountNumbers()
        {
            return _accountNumberStore.FindAllAccountNumbers();
        }

        private SyncModel ReadTransactionsFile()
        {
            try
            {
                ProcessTransactions();
                //ArchivingTransactionFile();
            }
            catch (Exception e)
            {
                return new SyncModel { Status = false, Message = Resource.TransactionNotSucceeded, ErrorMessage = e.Message };
            }

            return new SyncModel { Status = true, Message = Resource.TransactionSucceeded, ErrorMessage = Resource.AllTransactionsProcessed };
        }

        private void ProcessTransactions()
        {
            TextReader textReader = new StreamReader(_transactionFile);

            var csvReader = new CsvReader(textReader);
            csvReader.Configuration.HasHeaderRecord = false;
            csvReader.Configuration.RegisterClassMap<MapTransaction>();
            var test = csvReader.GetRecords<Transaction>().ToList();
        }

        private void ArchivingTransactionFile()
        {
            if (!Directory.Exists(_archiveFolder))
                Directory.CreateDirectory(_archiveFolder);

            var fileNameCurrent = Path.GetFileNameWithoutExtension(_transactionFile);
            var fileNameNew = $"{fileNameCurrent}_{DateTime.Now:ddMMyyyyHHmm}.txt";
            var transactionFileNew = Path.Combine(_archiveFolder, fileNameNew);

            if (File.Exists(transactionFileNew))
                File.Delete(transactionFileNew);

            File.Move(_transactionFile, transactionFileNew);
        }
    }

    public class SyncModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }

    public sealed class MapTransaction : CsvClassMap<Transaction>
    {
        public MapTransaction()
        {
            Map(m => m.AccountNumberId).Index(0);
            Map(m => m.Valuta).ConvertUsing(r => ParseValuta(r.GetField<string>(1)));
            Map(m => m.InterestDate).ConvertUsing(r => ParseTransactionDate(r.GetField<string>(2)));
            Map(m => m.DebitCredit).ConvertUsing(r => r.GetField(3) == "C" ? DebetCredit.Credit : DebetCredit.Debet);
            Map(m => m.Amount).Index(4).TypeConverterOption(NumberStyles.Currency);
            Map(m => m.ContraAccountId).Index(5);
            Map(m => m.ToName).Index(6);
            Map(m => m.BookingDate).ConvertUsing(r => ParseTransactionDate(r.GetField(7)));
            Map(m => m.BookingCode).ConvertUsing(r => ParseBookingCode(r.GetField(8)));
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
            switch (valuta.Trim('"'))
            {
                case "Eur":
                    return Valuta.Eur;
                case "Usd":
                    return Valuta.Usd;
                default:
                    return Valuta.Eur;
            }
        }

        private static BookingCode ParseBookingCode(string bookingCode)
        {
            switch (bookingCode.Trim('"'))
            {
                case "Ac":
                    return BookingCode.Ac;
                case "Ba":
                    return BookingCode.Ba;
                case "Bc":
                    return BookingCode.Bc;
                case "Bg":
                    return BookingCode.Bg;
                case "Cb":
                    return BookingCode.Cb;
                case "Ck":
                    return BookingCode.Ck;
                case "Db":
                    return BookingCode.Db;
                case "Eb":
                    return BookingCode.Eb;
                case "Ei":
                    return BookingCode.Ei;
                case "Fb":
                    return BookingCode.Fb;
                case "Ga":
                    return BookingCode.Ga;
                case "Gb":
                    return BookingCode.Gb;
                case "Id":
                    return BookingCode.Id;
                case "Kh":
                    return BookingCode.Kh;
                case "Ma":
                    return BookingCode.Ma;
                case "Sb":
                    return BookingCode.Sb;
                case "Tb":
                    return BookingCode.Tb;
                case "Sp":
                    return BookingCode.Sp;
                case "Cr":
                    return BookingCode.Cr;
                case "D":
                    return BookingCode.D;
                default:
                    return BookingCode.Ac;
            }
        }
    }
}