using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handlers;
using KpopZtation.Model;

namespace KpopZtation.Controllers
{
    public class AlbumController
    {
        AlbumHandler ah;

        public AlbumController()
        {
            ah = new AlbumHandler();
        }

        public string insertAlbum(int ArtistID, string AlbumName, string AlbumImage, string AlbumPrice, string AlbumStock, string AlbumDescription, int AlbumImageSize)
        {
            string validate = validateInsertAlbum(AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription, AlbumImageSize);
            if(validate.Equals("Album Inserted!"))
            {
                ah.insertAlbum(ArtistID, AlbumName, AlbumImage, int.Parse(AlbumPrice), int.Parse(AlbumStock), AlbumDescription);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public void deleteAlbum(int AlbumID)
        {
            ah.deleteAlbum(AlbumID);
        }

        public string updateAlbum(int AlbumID, int ArtistID, string AlbumName, string AlbumImage, string AlbumPrice, string AlbumStock, string AlbumDescription, int AlbumImageSize)
        {
            string validate = validateUpdateAlbum(AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription, AlbumImageSize);
            if (validate.Equals("Album Updated!"))
            {
                ah.updateAlbum(AlbumID, ArtistID, AlbumName, AlbumImage, int.Parse(AlbumPrice), int.Parse(AlbumStock), AlbumDescription);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public Album searchAlbum(int AlbumID)
        {
            return ah.searchAlbum(AlbumID);
        }

        public List<Album> getAlbums(int ArtistID)
        {
            return ah.getAlbums(ArtistID);
        }

        public string validateInsertAlbum(string AlbumName, string AlbumImage, string AlbumPrice, string AlbumStock, string AlbumDescription, int AlbumImageSize)
        {
            if (AlbumName.Length == 0 || AlbumName.Length >= 50)
            {
                if (AlbumName.Length == 0)
                {
                    return "Album's Name Must be Filled!";
                }
                else if (AlbumName.Length >= 50)
                {
                    return "Album's Name Must Under 50 Characters!";
                }
            }

            if (AlbumImage.Length == 0 || (AlbumImage.EndsWith(".png") == false && AlbumImage.EndsWith(".jpg") == false && AlbumImage.EndsWith(".jpeg") == false && AlbumImage.EndsWith(".jfif") == false) || AlbumImageSize >= 2097152)
            {
                if(AlbumImage.Length == 0)
                {
                    return "Album's Image Must be Choosen!";
                }
                else if(AlbumImage.EndsWith(".png") == false && AlbumImage.EndsWith(".jpg") == false && AlbumImage.EndsWith(".jpeg") == false && AlbumImage.EndsWith(".jfif") == false)
                {
                    return "Album's Image Format Must be png or jpg or jpeg or jfif!";
                }
                else if(AlbumImageSize >= 2097152)
                {
                    return "Album's Image Size Must be Lower than 2MB!";
                }
            }

            if(AlbumPrice.Length == 0 || int.Parse(AlbumPrice) <= 100000 || int.Parse(AlbumPrice) >= 1000000)
            {
                if(AlbumPrice.Length == 0)
                {
                    return "Album's Price Must be Filled!";
                }
                else if(int.Parse(AlbumPrice) <= 100000 || int.Parse(AlbumPrice) >= 1000000)
                {
                    return "Album's Price Must Between 100000 and 1000000!";
                }
            }

            if(AlbumStock.Length == 0 || int.Parse(AlbumStock) <= 0)
            {
                if(AlbumStock.ToString().Trim().Length == 0)
                {
                    return "Album's Stock Must be Filled!";
                }
                else if(int.Parse(AlbumStock) <= 0)
                {
                    return "Album's Stock Must More than 0!";
                }
            }

            if(AlbumDescription.Length == 0 || AlbumDescription.Length >= 255)
            {
                if(AlbumDescription.Length == 0)
                {
                    return "Album's Description Must be Filled!";
                }
                else if(AlbumDescription.Length >= 255)
                {
                    return "Album's Description Must Under 255 characters!";
                }
            }

            return "Album Inserted!";
        }

        public string validateUpdateAlbum(string AlbumName, string AlbumImage, string AlbumPrice, string AlbumStock, string AlbumDescription, int AlbumImageSize)
        {
            if (AlbumName.Length == 0 || AlbumName.Length >= 50)
            {
                if (AlbumName.Length == 0)
                {
                    return "Album's Name Must be Filled!";
                }
                else if (AlbumName.Length >= 50)
                {
                    return "Album's Name Must Under 50 Characters!";
                }
            }

            if (AlbumImage.Length == 0 || (AlbumImage.EndsWith(".png") == false && AlbumImage.EndsWith(".jpg") == false && AlbumImage.EndsWith(".jpeg") == false && AlbumImage.EndsWith(".jfif") == false) || AlbumImageSize >= 2097152)
            {
                if (AlbumImage.Length == 0)
                {
                    return "Album's Image Must be Choosen!";
                }
                else if (AlbumImage.EndsWith(".png") == false && AlbumImage.EndsWith(".jpg") == false && AlbumImage.EndsWith(".jpeg") == false && AlbumImage.EndsWith(".jfif") == false)
                {
                    return "Album's Image Format Must be png or jpg or jpeg or jfif!";
                }
                else if (AlbumImageSize >= 2097152)
                {
                    return "Album's Image Size Must be Lower than 2MB!";
                }
            }

            if (AlbumPrice.Length == 0 || int.Parse(AlbumPrice) <= 100000 || int.Parse(AlbumPrice) >= 1000000)
            {
                if (AlbumPrice.Length == 0)
                {
                    return "Album's Price Must be Filled!";
                }
                else if (int.Parse(AlbumPrice) <= 100000 || int.Parse(AlbumPrice) >= 1000000)
                {
                    return "Album's Price Must Between 100000 and 1000000!";
                }
            }

            if (AlbumStock.Length == 0 || int.Parse(AlbumStock) <= 0)
            {
                if (AlbumStock.ToString().Trim().Length == 0)
                {
                    return "Album's Stock Must be Filled!";
                }
                else if (int.Parse(AlbumStock) <= 0)
                {
                    return "Album's Stock Must More than 0!";
                }
            }

            if (AlbumDescription.Length == 0 || AlbumDescription.Length >= 255)
            {
                if (AlbumDescription.Length == 0)
                {
                    return "Album's Description Must be Filled!";
                }
                else if (AlbumDescription.Length >= 255)
                {
                    return "Album's Description Must Under 255 characters!";
                }
            }

            return "Album Updated!";
        }
    }
}