using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repositories;
using KpopZtation.Model;

namespace KpopZtation.Handlers
{
    public class AlbumHandler
    {
        AlbumRepository ar;

        public AlbumHandler()
        {
            ar = new AlbumRepository();
        }

        public void insertAlbum(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            ar.insertAlbum(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
        }

        public void deleteAlbum(int AlbumID)
        {
            ar.deleteAlbum(AlbumID);
        }

        public void updateAlbum(int AlbumID, int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            ar.updateAlbum(AlbumID, ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
        }

        public Album searchAlbum(int AlbumID)
        {
            return ar.searchAlbum(AlbumID);
        }

        public List<Album> getAlbums(int ArtistID)
        {
            return ar.getAlbums(ArtistID);
        }
    }
}