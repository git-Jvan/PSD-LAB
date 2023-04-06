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
    public partial class UpdateProfile : System.Web.UI.Page
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
                List<String> customerGender = new List<string>();
                customerGender.Add("Male");
                customerGender.Add("Female");
                rblcgender.DataSource = customerGender;
                rblcgender.DataBind();

                var customer = (Customer)Session["sessionLogin"];
                int CustomerID = customer.CustomerID;
                customer = cc.getCustomerByID(CustomerID);
                string CustomerName = customer.CustomerName.ToString();
                string CustomerEmail = customer.CustomerEmail.ToString();
                string CustomerPassword = customer.CustomerPassword.ToString();
                rblcgender.SelectedValue = customer.CustomerGender.ToString();
                rblcgender.DataBind();
                string CustomerAddress = customer.CustomerAddress.ToString();

                txtcname.Text = CustomerName;
                txtcemail.Text = CustomerEmail;
                txtcpassword.Text = CustomerPassword;
                txtcaddress.Text = CustomerAddress;
            }
        }

        protected void btncupdate_Click(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();

            var customer = (Customer)Session["sessionLogin"];
            int CustomerID = customer.CustomerID;
            string CustomerName = txtcname.Text.ToString().Trim();
            string CustomerEmail = txtcemail.Text.ToString().Trim();
            string CustomerPassword = txtcpassword.Text.ToString().Trim();
            string CustomerGender = rblcgender.SelectedValue.ToString().Trim();
            string CustomerAddress = txtcaddress.Text.ToString().Trim();

            customer = cc.getCustomerByID(CustomerID);
            int CustomerEmailTaken = -1;
            if (CustomerEmail.Equals(customer.CustomerEmail.ToString()))
            {
                CustomerEmailTaken = 12;
            }

            string updateCustomer = cc.updateCustomer(CustomerID, CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerEmailTaken);
            if(updateCustomer.Equals("Customer Updated!"))
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = updateCustomer;

                txtcname.Text = string.Empty;
                txtcemail.Text = string.Empty;
                txtcpassword.Text = string.Empty;
                rblcgender.SelectedIndex = -1;
                txtcaddress.Text = string.Empty;
            }
            else
            {
                lblcvalidation.Visible = true;
                lblcvalidation.Text = updateCustomer;
            }
        }
    }
}