using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factories;
using Microsoft.SqlServer.Server;

namespace KpopZtation.Repositories
{
    public class AlbumRepository
    {
        private Database1Entities1 db;
        Album a;

        public AlbumRepository()
        {
            db = Database.getDB();
            a = new Album();
        }

        public void insertAlbum(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            a = AlbumFactory.createAlbum(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
            db.Albums.Add(a);
            db.SaveChanges();
        }

        public void deleteAlbum(int AlbumID)
        {
            a = db.Albums.Find(AlbumID);
            db.Albums.Remove(a);
            db.SaveChanges();
        }

        public void updateAlbum(int AlbumID, int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            a = db.Albums.Find(AlbumID);
            a.ArtistID = ArtistID;
            a.AlbumName = AlbumName;
            a.AlbumImage = AlbumImage;
            a.AlbumPrice = AlbumPrice;
            a.AlbumStock = AlbumStock;
            a.AlbumDescription = AlbumDescription;
            db.SaveChanges();
        }

        public Album searchAlbum(int AlbumID)
        {
            a = db.Albums.Find(AlbumID);
            return a;
        }

        public List<Album> getAlbums(int ArtistID)
        {
            List<Album> albums = new List<Album>();
            albums = (from allAlbum in db.Albums where allAlbum.ArtistID == ArtistID select allAlbum).ToList();
            return albums;
        }

        public void reduceAlbumStock(int AlbumID, int Qty)
        {
            a = searchAlbum(AlbumID);
            a.AlbumStock = a.AlbumStock - Qty;
            db.SaveChanges();
        }

        public void addAlbumStock(int AlbumID, int Qty)
        {
            a = searchAlbum(AlbumID);
            a.AlbumStock = a.AlbumStock + Qty;
            db.SaveChanges();
        }
    }
}