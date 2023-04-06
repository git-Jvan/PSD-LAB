using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class AlbumFactory
    {
        public static Album createAlbum(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            Album a = new Album();
            a.ArtistID = ArtistID;
            a.AlbumName = AlbumName;
            a.AlbumImage = AlbumImage;
            a.AlbumPrice = AlbumPrice;
            a.AlbumStock = AlbumStock;
            a.AlbumDescription = AlbumDescription;
            return a;
        }
    }
}