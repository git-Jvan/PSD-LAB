using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using KpopZtation.Repositories;
using KpopZtation.Model;

namespace KpopZtation.Handlers
{
    public class TransactionHistoryHandler
    {
        TransactionHeaderRepository thr;
        TransactionDetailRepository tdr;
        CartRepository cr;

        public TransactionHistoryHandler()
        {
            thr = new TransactionHeaderRepository();
            tdr = new TransactionDetailRepository();
            cr = new CartRepository();
        }

        public void insertTransactionHistory(DateTime TransactionDate, int CustomerID)
        {
            thr.insertTransactionHeader(TransactionDate, CustomerID);

            int TransactionID = thr.getTransactionID();
            List<Cart> carts = new List<Cart>();
            carts = cr.getCarts(CustomerID);
            foreach(Cart c in carts)
            {
                tdr.insertTransactionDetail(TransactionID, c.AlbumID, c.Qty);
            }
        }

        public List<TransactionHeader> getTransactionHeaders(int CustomerID)
        {
            return thr.getTransactionHeaders(CustomerID);
        }

        public List<TransactionDetail> getTransactionDetails(int TransactionID)
        {
            return tdr.getTransactionDetails(TransactionID);
        }
    }
}