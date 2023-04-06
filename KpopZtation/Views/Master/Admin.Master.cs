using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controllers;

namespace KpopZtation.Views.Master
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            if (Session["sessionLogin"] != null || Request.Cookies["cookieID"] != null)
            {
                if (Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = cc.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

            }

            if (!IsPostBack)
            {
                var c = (Model.Customer)Session["sessionLogin"];
                hlprofile.Text = c.CustomerName.ToString();
            }
        }

        protected void lblogout_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach(string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("sessionLogin");

            Response.Redirect("~/Views/Login.aspx");
        }
    }
}