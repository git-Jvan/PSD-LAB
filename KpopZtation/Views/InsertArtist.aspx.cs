using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controllers;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class InsertArtist : System.Web.UI.Page
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

        protected void btnainsert_Click(object sender, EventArgs e)
        {
            ArtistController ac = new ArtistController();

            string ArtistName = txtaname.Text.ToString().Trim();
            string ArtistImage = fuaimage.FileName.ToString();
            int imageSize = fuaimage.PostedFile.ContentLength;

            string insertArtist = ac.insertArtist(ArtistName, ArtistImage, imageSize);
            if (insertArtist.Equals("Artist Inserted!"))
            {
                fuaimage.SaveAs(Request.PhysicalApplicationPath + "/Assets/Artists/" + ArtistImage.ToString());
                lblavalidation.Visible = true;
                lblavalidation.Text = insertArtist;

                txtaname.Text = string.Empty;

                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                lblavalidation.Visible = true;
                lblavalidation.Text = insertArtist;
            }
        }
    }
}