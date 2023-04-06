using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Handlers;

namespace KpopZtation.Controllers
{
    public class CartController
    {
        CartHandler ch;
        AlbumController ac;

        public CartController()
        {
            ch = new CartHandler();
            ac = new AlbumController();
        }

        public string addCart(int CustomerID, int AlbumID, string Qty)
        {
            string validate = validateAddCart(AlbumID, Qty);
            if(validate.Equals("Album Added to Cart!"))
            {
                ch.addCart(CustomerID, AlbumID, int.Parse(Qty));
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public void deleteCart(int CustomerID, int AlbumID)
        {
            ch.deleteCart(CustomerID, AlbumID);
        }

        public void deleteCarts(int CustomerID)
        {
            ch.deleteCarts(CustomerID);
        }

        public List<Cart> getCarts(int CustomerID)
        {
            return ch.getCarts(CustomerID);
        }

        public string validateAddCart(int AlbumID, string Qty)
        {
            var al = ac.searchAlbum(AlbumID);
            if(Qty.Length == 0 || int.Parse(Qty) > al.AlbumStock)
            {
                if(Qty.Length == 0)
                {
                    return "Quantity Must be Filled!";
                }
                else if(int.Parse(Qty) > al.AlbumStock)
                {
                    return "Quantity Can't be More than the Stock Album!";
                }
            }

            return "Album Added to Cart!";
        }
    }
}