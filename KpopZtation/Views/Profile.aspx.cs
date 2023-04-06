using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controllers;
using System.Web.UI.HtmlControls;

namespace KpopZtation.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
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
                if (c.CustomerRole.Equals("Admin"))
                {
                }
                else
                {
                }
            }

            if (!IsPostBack)
            {
                List<Customer> pro = new List<Customer>();

                var customer = (Customer)Session["sessionLogin"];
                int CustomerID = customer.CustomerID;
                pro.Add(cc.getCustomerByID(CustomerID));

                rprofile.DataSource = pro;
                rprofile.DataBind();
            }
        }

        protected void btncupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfile.aspx");
        }

        protected void btncdelete_Click(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            var customer = (Customer)Session["sessionLogin"];
            int CustomerID = customer.CustomerID;
            cc.deleteCustomer(CustomerID);

            Response.Redirect("~/Views/Login.aspx");
        }

        protected void rprofile_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var customer = e.Item.DataItem as Customer;
                HtmlGenericControl passwordText = e.Item.FindControl("passwordText") as HtmlGenericControl;
                passwordText.InnerHtml = new string('*', customer.CustomerPassword.Length);
            }
        }

        protected void btntogglepassword_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = btn.NamingContainer as RepeaterItem;
            var customer = (Customer)Session["sessionLogin"];
            HtmlGenericControl passwordText = item.FindControl("passwordtext") as HtmlGenericControl;
            if (btn.Text == "Show")
            {
                passwordText.InnerHtml = customer.CustomerPassword;
                btn.Text = "Hide";
            }
            else
            {
                passwordText.InnerHtml = new string('*', customer.CustomerPassword.Length);
                btn.Text = "Show";
            }
        }
    }
}