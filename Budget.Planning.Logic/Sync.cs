using System;
using System.Configuration;
using System.IO;

namespace Budget.Planning.Logic
{
    public class Sync : ISync
    {
        private readonly string _transactionFile =ConfigurationManager.AppSettings["transactionFile"];

        public SyncModel SyncTransactions()
        {
            if (File.Exists(_transactionFile))
            {
                return ReadTransactionsFile();
            }
            else
                return new SyncModel {Status = false, Message = Resource.TransactionNotSucceeded, ErrorMessage = Resource.FileNotFound};
        }

        private SyncModel ReadTransactionsFile()
        {
            var lines = System.IO.File.ReadAllLines(_transactionFile);

            try
            {
                foreach (var line in lines)
                {
                    var transaction = line.Split(',');
                }
            }
            catch (Exception e)
            {
                return new SyncModel { Status = true, Message = Resource.TransactionSucceeded, ErrorMessage = e.Message };
            }

            return new SyncModel {Status = true, Message= Resource.TransactionSucceeded, ErrorMessage = Resource.AllTransactionsProcessed};
        }
    }

    public class SyncModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}