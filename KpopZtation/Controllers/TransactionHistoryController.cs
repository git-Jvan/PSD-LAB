using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handlers;
using KpopZtation.Model;

namespace KpopZtation.Controllers
{
    public class TransactionHistoryController
    {
        TransactionHistoryHandler thh;

        public TransactionHistoryController()
        {
            thh = new TransactionHistoryHandler();
        }

        public void insertTransactionHistory(int CustomerID)
        {
            DateTime TransactionDate = DateTime.Today;
            thh.insertTransactionHistory(TransactionDate, CustomerID);
        }

        public List<TransactionHeader> getTransactionHeaders(int CustomerID)
        {
            return thh.getTransactionHeaders(CustomerID);
        }

        public List<TransactionDetail> getTransactionDetails(int TransactionID)
        {
            return thh.getTransactionDetails(TransactionID);
        }
    }
}