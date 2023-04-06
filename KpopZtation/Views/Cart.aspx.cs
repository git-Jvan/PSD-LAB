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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController custController = new CustomerController();
            CartController cc = new CartController();

            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                if (Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = custController.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

                var c = (Customer)Session["sessionLogin"];
                if (c.CustomerRole.Equals("Customer"))
                {
                }
                else
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
            }

            if (!IsPostBack)
            {
                List<Model.Cart> carts = new List<Model.Cart>();
                var customer = (Customer)Session["sessionLogin"];
                int CustomerID = customer.CustomerID;
                carts = cc.getCarts(CustomerID);

                rcart.DataSource = carts;
                rcart.DataBind();

                if (!carts.Any())
                {
                    lblcnone.Visible = true;
                    btncheckout.Visible = false;
                }
                else
                {
                    lblcnone.Visible = false;
                    btncheckout.Visible = true;
                }
            }
        }

        protected void btncdelete_Command(object sender, CommandEventArgs e)
        {
            CartController cc = new CartController();

            var customer = (Customer)Session["sessionLogin"];
            int CustomerID = customer.CustomerID;
            int AlbumID = int.Parse(e.CommandArgument.ToString());
            cc.deleteCart(CustomerID, AlbumID);

            rcart.DataSource = cc.getCarts(CustomerID);
            rcart.DataBind();
        }

        protected void btnccheckout_Click(object sender, EventArgs e)
        {
            CartController cc = new CartController();
            TransactionHistoryController thc = new TransactionHistoryController();

            var customer = (Customer)Session["sessionLogin"];
            int CustomerID = customer.CustomerID;
            thc.insertTransactionHistory(CustomerID);
            cc.deleteCarts(CustomerID);

            Response.Redirect("~/Views/Home.aspx");
        }
    }
}