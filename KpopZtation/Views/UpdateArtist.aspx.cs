using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controllers;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            ArtistController ac = new ArtistController();

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

            if (IsPostBack == false)
            {
                int ArtistID = int.Parse(Request["ArtistID"]);
                var a = ac.getArtist(ArtistID);

                txtaname.Text = a.ArtistName.ToString();
                string ArtistImagePath = "~/Assets/Artists/" + a.ArtistImage;
                imga.ImageUrl = ArtistImagePath;
            }
        }

        protected void btnaupdate_Click(object sender, EventArgs e)
        {
            ArtistController ac = new ArtistController();

            int ArtistID = int.Parse(Request["ArtistID"]);
            var a = ac.getArtist(ArtistID);

            string ArtistName = txtaname.Text.ToString().Trim();
            string ArtistImage = "";
            string ArtistImageBefore = a.ArtistImage.ToString();
            string ArtistImageBeforePath = Request.PhysicalApplicationPath + "/Assets/Artists/" + ArtistImageBefore;
            int ArtistImageSize = fuaimage.PostedFile.ContentLength;
            int ArtistNameTaken = -1;

            if(fuaimage.HasFile == true)
            {
                ArtistImage = fuaimage.FileName.ToString();
            }
            else if(fuaimage.HasFile == false)
            {
                ArtistImage = a.ArtistImage.ToString();
            }

            if (ArtistName.Equals(a.ArtistName))
            {
                ArtistNameTaken = 12;
            }

            string updateArtist = ac.updateArtist(ArtistID, ArtistName, ArtistImage, ArtistImageSize, ArtistNameTaken);
            if(updateArtist.Equals("Artist Updated!"))
            {
                if(ArtistImage.Equals(ArtistImageBefore) == false)
                {
                    fuaimage.SaveAs(Request.PhysicalApplicationPath + "/Assets/Artists/" + ArtistImage.ToString());
                    System.IO.File.Delete(ArtistImageBeforePath);
                }
                lblavalidation.Visible = true;
                lblavalidation.Text = updateArtist;

                txtaname.Text = string.Empty;

                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                lblavalidation.Visible = true;
                lblavalidation.Text = updateArtist;
            }
        }
    }
}