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
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            AlbumController ac = new AlbumController();

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
                int AlbumID = int.Parse(Request["AlbumID"].ToString());
                var al = ac.searchAlbum(AlbumID);

                txtalname.Text = al.AlbumName.ToString();
                imgal.ImageUrl = "~/Assets/Albums/" + al.AlbumImage.ToString();
                txtalprice.Text = al.AlbumPrice.ToString();
                txtalstock.Text = al.AlbumStock.ToString();
                txtaldescription.Text = al.AlbumDescription.ToString();
            }
        }

        protected void btnalupdate_Click(object sender, EventArgs e)
        {
            AlbumController ac = new AlbumController();

            int AlbumID = int.Parse(Request["AlbumID"].ToString());
            var al = ac.searchAlbum(AlbumID);
            int ArtistID = al.ArtistID;
            string AlbumName = txtalname.Text.ToString().Trim();
            string AlbumImage = "";
            string AlbumImageBefore = al.AlbumImage.ToString();
            string AlbumImageBeforePath = Request.PhysicalApplicationPath + "/Assets/Albums/" + AlbumImageBefore;
            string AlbumPrice = txtalprice.Text.ToString().Trim();
            string AlbumStock = txtalstock.Text.ToString().Trim();
            string AlbumDescription = txtaldescription.Text.ToString().Trim();
            int AlbumImageSize = fualimage.PostedFile.ContentLength;

            if(fualimage.HasFile == true)
            {
                AlbumImage = fualimage.FileName.ToString();
            }
            else if(fualimage.HasFile == false)
            {
                AlbumImage = al.AlbumImage.ToString();
            }

            string updateAlbum = ac.updateAlbum(AlbumID, ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription, AlbumImageSize);
            if(updateAlbum.Equals("Album Updated!"))
            {
                if(AlbumImage.Equals(AlbumImageBefore) == false)
                {
                    fualimage.SaveAs(Request.PhysicalApplicationPath + "/Assets/Albums/" + AlbumImage.ToString());
                    System.IO.File.Delete(AlbumImageBeforePath);
                }

                lblalvalidation.Visible = true;
                lblalvalidation.Text = updateAlbum;

                txtalname.Text = string.Empty;
                txtalprice.Text = string.Empty;
                txtalstock.Text = string.Empty;
                txtaldescription.Text = string.Empty;

                Response.Redirect("~/Views/ArtistDetail.aspx?ArtistID=" + ArtistID);
            }
            else
            {
                lblalvalidation.Visible = true;
                lblalvalidation.Text = updateAlbum;
            }
        }
    }
}