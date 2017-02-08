using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Budget.Planning.DataAccess.Models;
using Budget.Planning.DataAccess.Stores;
using CsvHelper;

namespace Budget.Planning.Logic
{
    public class Sync : ISync
    {
        private readonly string _transactionFile = ConfigurationManager.AppSettings["transactionFile"];
        private readonly string _archiveFolder = ConfigurationManager.AppSettings["archiveFolder"];

        private readonly IAccountNumberStore _accountNumberStore;
        private readonly ITransactionStore _transactionStore;

        public Sync(IAccountNumberStore accountNumberStore, ITransactionStore transactionStore)
        {
            _accountNumberStore = accountNumberStore;
            _transactionStore = transactionStore;
        }

        public SyncModel SyncTransactions()
        {
            return File.Exists(_transactionFile)
                ? ReadTransactionsFile()
                : new SyncModel
                {
                    Status = false,
                    Message = Resource.TransactionNotSucceeded,
                    ErrorMessage = Resource.FileNotFound
                };
        }

        public List<Account> AccountNumbers()
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
                return new SyncModel
                {
                    Status = false,
                    Message = Resource.TransactionNotSucceeded,
                    ErrorMessage = e.Message
                };
            }

            return new SyncModel
            {
                Status = true,
                Message = Resource.TransactionSucceeded,
                ErrorMessage = Resource.AllTransactionsProcessed
            };
        }

        private void ProcessTransactions()
        {
            TextReader textReader = new StreamReader(_transactionFile);

            var csvReader = new CsvReader(textReader);
            csvReader.Configuration.HasHeaderRecord = false;
            csvReader.Configuration.RegisterClassMap<MapTransaction>();
            var transactions = csvReader.GetRecords<Transaction>().ToList();

            foreach (var transaction in transactions)
            {
                _transactionStore.InsertTransaction(transaction);
            }

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