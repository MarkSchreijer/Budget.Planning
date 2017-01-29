using System.IO;

namespace Budget.Planning.Logic
{
    public class Sync : ISync
    {
        private readonly string _transactionFile = @"C:\Temp\Transactions\transactions.txt";

        public SyncModel SyncTransactions()
        {
            if (File.Exists(_transactionFile))
            {
                return ReadTransactionsFile();

                //return new SyncModel {Status = true, Message = "Bestand gevonden"};
            }
            else
                return new SyncModel {Status = false, Message = Resource.FileNotFound};
        }

        private SyncModel ReadTransactionsFile()
        {
            var lines = System.IO.File.ReadAllLines(_transactionFile);

            foreach (var line in lines)
            {
                var transaction = line.Split(',');
            }

            return new SyncModel {Status = true, Message = Resource.AllTransactionsProcessed};
        }
    }

    public class SyncModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}