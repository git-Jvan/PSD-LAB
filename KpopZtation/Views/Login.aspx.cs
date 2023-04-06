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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            if(Request.Cookies["cookieEmail"] != null && Request.Cookies["cookiePassword"] != null)
            {
                txtcemail.Text = Request.Cookies["cookieEmail"].Value.ToString();
                txtcpassword.Text = Request.Cookies["cookiePassword"].Value.ToString();
            }

            if(Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
            }
            else
            {
                if(Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = cc.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void btnclogin_Click(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            string CustomerEmail = txtcemail.Text.ToString().Trim();
            string CustomerPassword = txtcpassword.Text.ToString().Trim();

            string loginCustomer = cc.loginCustomer(CustomerEmail, CustomerPassword);

            if(loginCustomer.Equals("Login Successfully!"))
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = loginCustomer;

                var c = cc.getCustomerByLogin(CustomerEmail, CustomerPassword);
                Session["sessionLogin"] = c;
                if (cbxcremember.Checked == true)
                {
                    HttpCookie cookieID = new HttpCookie("cookieID");
                    HttpCookie cookieEmail = new HttpCookie("cookieEmail");
                    HttpCookie cookiePassword = new HttpCookie("cookiePassword");
                    cookieID.Value = c.CustomerID.ToString();
                    cookieEmail.Value = c.CustomerEmail.ToString();
                    cookiePassword.Value = c.CustomerPassword.ToString();
                    cookieID.Expires = DateTime.Now.AddHours(2);
                    cookieEmail.Expires = DateTime.Now.AddHours(2);
                    cookiePassword.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(cookieID);
                    Response.Cookies.Add(cookieEmail);
                    Response.Cookies.Add(cookiePassword);
                }

                txtcemail.Text = string.Empty;
                txtcpassword.Text = string.Empty;

                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = loginCustomer;
            }
        }
    }
}