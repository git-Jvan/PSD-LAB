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
    public partial class ArtistDetail : System.Web.UI.Page
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
            ArtistController ac = new ArtistController();
            AlbumController alc = new AlbumController();
            CustomerController cc = new CustomerController();

            if (Session["sessionLogin"] == null && Request.Cookies["cookieID"] == null)
            {
                insertalbum.Visible = false;
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
                    insertalbum.Visible = true;
                }
                else
                {
                    insertalbum.Visible = false;
                }
            }

            if (IsPostBack == false)
            {
                List<Album> albums = new List<Album>();
                List<Artist> artists = new List<Artist>();

                int ArtistID = int.Parse(Request["ArtistID"].ToString());
                var a = ac.getArtist(ArtistID);
                artists.Add(a);

                albums = alc.getAlbums(ArtistID);

                rartistdetail.DataSource = artists;
                rartistdetail.DataBind();

                ralbum.DataSource = albums;
                ralbum.DataBind();

                if (!albums.Any())
                {
                    lblalnone.Visible = true;
                }
                else
                {
                    lblalnone.Visible = false;
                }
            }
        }

        protected void btnaldelete_Command(object sender, CommandEventArgs e)
        {
            AlbumController alc = new AlbumController();

            int AlbumID = int.Parse(e.CommandArgument.ToString());
            var a = alc.searchAlbum(AlbumID);
            int ArtistID = int.Parse(a.ArtistID.ToString());
            string image = a.AlbumImage;
            string imagePath = Request.PhysicalApplicationPath + "/Assets/Albums/" + image;
            alc.deleteAlbum(AlbumID);
            System.IO.File.Delete(imagePath);

            ralbum.DataSource = alc.getAlbums(ArtistID);
            ralbum.DataBind();
        }

        protected void btnalupdate_Command(object sender, CommandEventArgs e)
        {
            int AlbumID = int.Parse(e.CommandArgument.ToString());

            Response.Redirect("~/Views/UpdateAlbum.aspx?AlbumID=" + AlbumID);
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            int ArtistID = int.Parse(Request["ArtistID"].ToString());
            Response.Redirect("~/Views/InsertAlbum.aspx?ArtistID=" + ArtistID);
        }

        protected void ralbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btndelete = e.Item.FindControl("btnaldelete") as Button;
                Button btnupdate = e.Item.FindControl("btnalupdate") as Button;
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

                var row = e.Item.FindControl("albumrow") as HtmlTableRow;
                var al = e.Item.DataItem as Album;
                int AlbumID = al.AlbumID;
                if(row != null)
                {
                    row.Attributes["onclick"] = "window.location.href='AlbumDetail.aspx?AlbumID=" + AlbumID + "'";                
                }
            }
        }
    }
}