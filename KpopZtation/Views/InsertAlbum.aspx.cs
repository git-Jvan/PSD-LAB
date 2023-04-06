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
    public partial class InsertAlbum : System.Web.UI.Page
    {
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
                    Response.Redirect("~/Views/Home.aspx");
                }
            }
        }

        protected void btnalinsert_Click(object sender, EventArgs e)
        {
            AlbumController ac = new AlbumController();

            int ArtistID = int.Parse(Request["ArtistID"].ToString());
            string AlbumName = txtalname.Text.ToString().Trim();
            string AlbumImage = fualimage.FileName.ToString().Trim();
            string AlbumPrice = txtalprice.Text.ToString().Trim();
            string AlbumStock = txtalstock.Text.ToString().Trim();
            string AlbumDescription = txtaldescription.Text.ToString().Trim();
            int imageSize = fualimage.PostedFile.ContentLength;

            string insertAlbum = ac.insertAlbum(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription, imageSize);
            if(insertAlbum.Equals("Album Inserted!"))
            {
                fualimage.SaveAs(Request.PhysicalApplicationPath + "/Assets/Albums/" + AlbumImage.ToString());
                lblalvalidation.Visible = true;
                lblalvalidation.Text = insertAlbum;

                txtalname.Text = string.Empty;
                txtalprice.Text = string.Empty;
                txtalstock.Text = string.Empty;
                txtaldescription.Text = string.Empty;

                Response.Redirect("~/Views/ArtistDetail.aspx?ArtistID=" + ArtistID);
            }
            else
            {
                lblalvalidation.Visible = true;
                lblalvalidation.Text = insertAlbum;
            }
        }
    }
}