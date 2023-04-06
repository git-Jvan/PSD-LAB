using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using KpopZtation.Handlers;
using KpopZtation.Model;

namespace KpopZtation.Controllers
{
    public class ArtistController
    {
        ArtistHandler ah;

        public ArtistController()
        {
            ah = new ArtistHandler();
        }

        public string insertArtist(string ArtistName, string ArtistImage, int ArtistImageSize)
        {
            string validate = validateInsertArtist(ArtistName, ArtistImage, ArtistImageSize);
            if(validate.Equals("Artist Inserted!"))
            {
                ah.insertArtist(ArtistName, ArtistImage);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public void deleteArtist(int ArtistID)
        {
            ah.deleteArtist(ArtistID);
        }

        public Artist getArtist(int ArtistID)
        {
            return ah.getArtist(ArtistID);
        }

        public string updateArtist(int ArtistID, string ArtistName, string ArtistImage, int ArtistImageSize, int ArtistNameTaken)
        {
            string validate = validateUpdateArtist(ArtistName, ArtistImage, ArtistImageSize, ArtistNameTaken);
            if(validate.Equals("Artist Updated!"))
            {
                ah.updateArtist(ArtistID, ArtistName, ArtistImage);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public List<Artist> getArtists()
        {
            return ah.getArtists();
        }

        public string validateInsertArtist(string ArtistName, string ArtistImage, int ArtistImageSize)
        {
            if(ArtistName.Length == 0 || ah.isNameTrue(ArtistName) == true)
            {
                if(ArtistName.Length == 0)
                {
                    return "Artist's Name Must be Filled!";
                }
                else if(ah.isNameTrue(ArtistName) == true)
                {
                    return "Artist's Name is Already Taken!";
                }
            }

            if(ArtistImage.Length == 0 || (ArtistImage.EndsWith(".png") == false && ArtistImage.EndsWith(".jpg") == false && ArtistImage.EndsWith(".jpeg") == false && ArtistImage.EndsWith(".jfif") == false) || ArtistImageSize >= 2097152)
            {
                if(ArtistImage.Length == 0)
                {
                    return "Artist's Image Must be Choosen!";
                }
                else if(ArtistImage.EndsWith(".png") == false && ArtistImage.EndsWith(".jpg") == false && ArtistImage.EndsWith(".jpeg") == false && ArtistImage.EndsWith(".jfif") == false)
                {
                    return "Artist's Image Format Must be png or jpg or jpeg or jfif!";
                }
                else if(ArtistImageSize >= 2097152)
                {
                    return "Artist's Image Size Must be Lower than 2MB!";
                }
            }

            return "Artist Inserted!";
        }

        public string validateUpdateArtist(string ArtistName, string ArtistImage, int ArtistImageSize, int ArtistNameTaken)
        {
            if (ArtistName.Length == 0 || (ah.isNameTrue(ArtistName) == true && ArtistNameTaken == -1))
            {
                if (ArtistName.Length == 0)
                {
                    return "Artist's Name Must be Filled!";
                }
                else if (ah.isNameTrue(ArtistName) == true && ArtistNameTaken == -1)
                {
                    return "Artist's Name is Already Taken!";
                }
            }

            if (ArtistImage.Length == 0 || (ArtistImage.EndsWith(".png") == false && ArtistImage.EndsWith(".jpg") == false && ArtistImage.EndsWith(".jpeg") == false && ArtistImage.EndsWith(".jfif") == false) || ArtistImageSize >= 2097152)
            {
                if (ArtistImage.Length == 0)
                {
                    return "Artist's Image Must be Choosen!";
                }
                else if (ArtistImage.EndsWith(".png") == false && ArtistImage.EndsWith(".jpg") == false && ArtistImage.EndsWith(".jpeg") == false && ArtistImage.EndsWith(".jfif") == false)
                {
                    return "Artist's Image Format Must be png or jpg or jpeg or jfif!";
                }
                else if (ArtistImageSize >= 2097152)
                {
                    return "Artist's Image Size Must be Lower than 2MB!";
                }
            }

            return "Artist Updated!";
        }
    }
}