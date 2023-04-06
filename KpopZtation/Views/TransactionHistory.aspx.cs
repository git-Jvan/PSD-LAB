using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controllers;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            TransactionHistoryController thc = new TransactionHistoryController();

            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
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
                }
                else
                {
                    Response.Redirect("~/Views/Home.aspx");
                }
            }

            if (!IsPostBack)
            {
                List<TransactionHeader> transactionHeaders = new List<TransactionHeader>();
                var customer = (Customer)Session["sessionLogin"];
                int CustomerID = customer.CustomerID;
                transactionHeaders = thc.getTransactionHeaders(CustomerID);

                rtransactionheader.DataSource = transactionHeaders;
                rtransactionheader.DataBind();
            }
        }

        protected void rtransactionheader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TransactionHistoryController thc = new TransactionHistoryController();

                var transactionHeader = (TransactionHeader)e.Item.DataItem;
                int TransactionID = transactionHeader.TransactionID;

                Repeater innerRepeater = e.Item.FindControl("rtransactiondetail") as Repeater;
                innerRepeater.DataSource = thc.getTransactionDetails(TransactionID);
                innerRepeater.DataBind();
            }
        }
    }
}