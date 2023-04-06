using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KpopZtation.Controllers;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class Home : System.Web.UI.Page
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
            ArtistController ac = new ArtistController();

            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                insertartist.Visible = false;
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
                    insertartist.Visible = true;
                }
                else
                {
                    insertartist.Visible = false;
                }
            }

            if (IsPostBack == false)
            {
                rartist.DataSource = ac.getArtists().ToList();
                rartist.DataBind();
            }
        }

        protected void btnadelete_Command(object sender, CommandEventArgs e)
        {
            ArtistController ac = new ArtistController();

            int ArtistID = int.Parse(e.CommandArgument.ToString());
            var a = ac.getArtist(ArtistID);
            string ArtistImage = a.ArtistImage;
            string ArtistImagePath = Request.PhysicalApplicationPath + "/Assets/Artists/" + ArtistImage;
            ac.deleteArtist(ArtistID);
            System.IO.File.Delete(ArtistImagePath);

            rartist.DataSource = ac.getArtists().ToList();
            rartist.DataBind();
        }

        protected void btnaupdate_Command(object sender, CommandEventArgs e)
        {
            int ArtistID = int.Parse(e.CommandArgument.ToString());

            Response.Redirect("~/Views/UpdateArtist.aspx?ArtistID=" + ArtistID);
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertArtist.aspx");
        }

        protected void rartist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btndelete = e.Item.FindControl("btnadelete") as Button;
                Button btnupdate = e.Item.FindControl("btnaupdate") as Button;
                if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
                {
                    btndelete.Visible = false;
                    btnupdate.Visible = false;
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
                        btndelete.Visible = true;
                        btnupdate.Visible = true;
                    }
                    else
                    {
                        btndelete.Visible = false;
                        btnupdate.Visible = false;
                    }
                }

                var row = e.Item.FindControl("artistrow") as HtmlTableRow;
                var a = e.Item.DataItem as Artist;
                int ArtistID = a.ArtistID;
                if(row != null)
                {
                    row.Attributes["onclick"] = "window.location.href='ArtistDetail.aspx?ArtistID=" + ArtistID + "'";
                }
            }
        }
    }
}