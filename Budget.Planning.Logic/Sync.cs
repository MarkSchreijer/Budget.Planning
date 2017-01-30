using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Budget.Planning.DataAccess;
using Budget.Planning.DataAccess.Helpers;
using Budget.Planning.DataAccess.Models;

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
            var accountNumbers = AccountNumbers();
            var lines = File.ReadAllLines(_transactionFile);
            var transactions = new List<Transaction>();

            transactions.AddRange(lines.Select(line => line.Split(',')).Select(transactionArray => new Transaction
            {
                AccountNumberId = DetermineAccountNumberId(transactionArray[0], accountNumbers),
                Valuta = DetermineValuta(transactionArray[1]),
                InterestDate = DetermineTransactionDate(transactionArray[2]),
                Description2 = transactionArray[10]
            }));
        }

        private static int DetermineAccountNumberId(string accountNumber, List<AccountNumber> accountNumbers)
        {
            return string.IsNullOrEmpty(accountNumber) ? 0 : accountNumbers.Find(a => a.Number == accountNumber.Trim('"')).Id;
        }

        private static Valuta DetermineValuta(string valuta)
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

        private static DateTime DetermineTransactionDate(string date)
        {
            if (string.IsNullOrEmpty(date))
                return new DateTime();

            return new DateTime(int.Parse(date.Trim('"').Substring(0, 4)), int.Parse(date.Trim('"').Substring(4, 2)),
                int.Parse(date.Trim('"').Substring(6, 2)));
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
}