using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int TransactionID, int AlbumID, int Qty)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = TransactionID;
            td.AlbumID = AlbumID;
            td.Qty = Qty;
            return td;
        }
    }
}