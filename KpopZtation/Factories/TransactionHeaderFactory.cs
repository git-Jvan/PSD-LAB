using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(DateTime TransactionDate, int CustomerID)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionDate = TransactionDate;
            th.CustomerID = CustomerID;
            return th;
        }
    }
}