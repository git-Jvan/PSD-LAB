using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controllers;

namespace KpopZtation.Views
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                this.MasterPageFile = "~/Views/Master/Guest.Master";
            }
            else
            {
                CustomerController cc = new CustomerController();

                if (Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = cc.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

                var c = (Customer)Session["sessionLogin"];
                if (c.CustomerRole.Equals("Admin"))
                {
                    this.MasterPageFile = "~/Views/Master/Admin.Master";
                }
                else
                {
                    this.MasterPageFile = "~/Views/Master/Customer.Master";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            AlbumController ac = new AlbumController();

            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                addcart.Visible = false;
            }
            else
            {
                if (Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = cc.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

                var c = (Customer)Session["sessionLogin"];
                if (c.CustomerRole.Equals("Customer"))
                {
                    addcart.Visible = true;
                }
                else
                {
                    addcart.Visible = false;
                }
            }

            if (IsPostBack == false)
            {
                List<Album> al = new List<Album>();

                int AlbumID = int.Parse(Request["AlbumID"].ToString());
                al.Add(ac.searchAlbum(AlbumID));

                ralbumdetail.DataSource = al;
                ralbumdetail.DataBind();
            }
        }

        protected void btncadd_Click(object sender, EventArgs e)
        {
            CartController cc = new CartController();
            AlbumController ac = new AlbumController();
            List<Album> al = new List<Album>();

            var customer = (Customer)Session["sessionLogin"];
            int CustomerID = customer.CustomerID;
            int AlbumID = int.Parse(Request["AlbumID"].ToString());
            string Qty = txtcquantity.Text.ToString().Trim();

            string addCart = cc.addCart(CustomerID, AlbumID, Qty);
            if(addCart.Equals("Album Added to Cart!"))
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = addCart;
                txtcquantity.Text = string.Empty;

                al.Add(ac.searchAlbum(AlbumID));

                ralbumdetail.DataSource = al;
                ralbumdetail.DataBind();
            }
            else
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = addCart;
            }
        }
    }
}