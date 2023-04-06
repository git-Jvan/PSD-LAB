using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class CartFactory
    {
        public static Cart createCart(int CustomerID, int AlbumID, int Qty)
        {
            Cart c = new Cart();
            c.CustomerID = CustomerID;
            c.AlbumID = AlbumID;
            c.Qty = Qty;
            return c;
        }
    }
}