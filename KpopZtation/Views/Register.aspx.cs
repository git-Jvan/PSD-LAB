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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            if(IsPostBack == false)
            {
                List<string> customerGender = new List<string>();
                customerGender.Add("Male");
                customerGender.Add("Female");
                rblcgender.DataSource = customerGender;
                rblcgender.DataBind();
            }

            if(Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
            }
            else
            {
                if (Session["sessionLogin"] == null)
                {
                    int CustomerID = int.Parse(Request.Cookies["cookieID"].Value.ToString());
                    var customer = cc.getCustomerByID(CustomerID);
                    Session["sessionLogin"] = customer;
                }

                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void btncregister_Click(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            string CustomerName = txtcname.Text.ToString().Trim();
            string CustomerEmail = txtcemail.Text.ToString().Trim();
            string CustomerPassword = txtcpassword.Text.ToString().Trim();
            string CustomerGender = rblcgender.SelectedValue.ToString().Trim();
            string CustomerAddress = txtcaddress.Text.ToString().Trim();
            string CustomerRole = "Customer";

            string insertCustomer = cc.insertCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole);

            if(insertCustomer.Equals("Customer Registered!"))
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = insertCustomer;

                txtcname.Text = string.Empty;
                txtcemail.Text = string.Empty;
                txtcpassword.Text = string.Empty;
                rblcgender.SelectedIndex = -1;
                txtcaddress.Text = string.Empty;

                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = insertCustomer;
            }
        }
    }
}