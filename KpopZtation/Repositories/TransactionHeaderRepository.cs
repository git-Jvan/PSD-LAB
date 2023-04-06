using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factories;

namespace KpopZtation.Repositories
{
    public class TransactionHeaderRepository
    {
        private Database1Entities1 db;
        TransactionHeader th;

        public TransactionHeaderRepository()
        {
            db = Database.getDB();
            th = new TransactionHeader();
        }

        public void insertTransactionHeader(DateTime TransactionDate, int CustomerID)
        {
            th = TransactionHeaderFactory.createTransactionHeader(TransactionDate, CustomerID);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public List<TransactionHeader> getTransactionHeaders(int CustomerID)
        {
            List<TransactionHeader> transactionHeaders = new List<TransactionHeader>();
            transactionHeaders = (from allTh in db.TransactionHeaders where allTh.CustomerID == CustomerID select allTh).ToList();
            return transactionHeaders;
        }

        public int getTransactionID()
        {
            th = (from thID in db.TransactionHeaders select thID).ToList().LastOrDefault();
            int TransactionID = th.TransactionID;
            return TransactionID;
        }
    }
}