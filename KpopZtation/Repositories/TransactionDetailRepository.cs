using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Factories;
using KpopZtation.Model;

namespace KpopZtation.Repositories
{
    public class TransactionDetailRepository
    {
        private Database1Entities1 db;
        TransactionDetail td;

        public TransactionDetailRepository()
        {
            db = Database.getDB();
            td = new TransactionDetail();
        }

        public void insertTransactionDetail(int TransactionID, int AlbumID, int Qty)
        {
            td = TransactionDetailFactory.createTransactionDetail(TransactionID, AlbumID, Qty);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public List<TransactionDetail> getTransactionDetails(int TransactionID)
        {
            List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
            transactionDetails = (from allTd in db.TransactionDetails where allTd.TransactionID == TransactionID select allTd).ToList();
            return transactionDetails;
        }
    }
}