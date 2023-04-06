using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factories;

namespace KpopZtation.Repositories
{

    public class CartRepository
    {
        private Database1Entities1 db;
        AlbumRepository ar;
        Cart c;

        public CartRepository()
        {
            db = Database.getDB();
            ar = new AlbumRepository();
            c = new Cart();
        }

        public void addCart(int CustomerID, int AlbumID, int Qty)
        {
            ar.reduceAlbumStock(AlbumID, Qty);
            c = CartFactory.createCart(CustomerID, AlbumID, Qty);
            db.Carts.Add(c);
            db.SaveChanges();
        }

        public void deleteCart(int CustomerID, int AlbumID)
        {
            c = (from deletecart in db.Carts where deletecart.CustomerID == CustomerID && deletecart.AlbumID == AlbumID select deletecart).FirstOrDefault();
            ar.addAlbumStock(c.AlbumID, c.Qty);
            db.Carts.Remove(c);
            db.SaveChanges();
        }

        public void deleteCarts(int CustomerID)
        {
            List<Cart> carts = new List<Cart>();
            carts = (from deleteCarts in db.Carts where deleteCarts.CustomerID == CustomerID select deleteCarts).ToList();
            foreach(Cart ca in carts)
            {
                db.Carts.Remove(ca);
                db.SaveChanges();
            }
        }

        public List<Cart> getCarts(int CustomerID)
        {
            List<Cart> carts = new List<Cart>();
            carts = (from allCart in db.Carts where allCart.CustomerID == CustomerID select allCart).ToList();
            return carts;
        }
    }
}