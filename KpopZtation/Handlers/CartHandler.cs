using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repositories;
using KpopZtation.Model;

namespace KpopZtation.Handlers
{
    public class CartHandler
    {
        CartRepository cr;

        public CartHandler()
        {
            cr = new CartRepository();
        }

        public void addCart(int CustomerID, int AlbumID, int Qty)
        {
            cr.addCart(CustomerID, AlbumID, Qty);
        }

        public void deleteCart(int CustomerID, int AlbumID)
        {
            cr.deleteCart(CustomerID, AlbumID);
        }

        public void deleteCarts(int CustomerID)
        {
            cr.deleteCarts(CustomerID);
        }

        public List<Cart> getCarts(int CustomerID)
        {
            return cr.getCarts(CustomerID);
        }
    }
}