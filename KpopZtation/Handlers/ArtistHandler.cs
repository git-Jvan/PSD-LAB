using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repositories;
using KpopZtation.Model;

namespace KpopZtation.Handlers
{
    public class ArtistHandler
    {
        ArtistRepository ar;

        public ArtistHandler()
        {
            ar = new ArtistRepository();
        }

        public void insertArtist(string ArtistName, string ArtistImage)
        {
            ar.insertArtist(ArtistName, ArtistImage);
        }

        public void deleteArtist(int ArtistID)
        {
            ar.deleteArtist(ArtistID);
        }

        public void updateArtist(int ArtistID, string ArtistName, string ArtistImage)
        {
            ar.updateArtist(ArtistID, ArtistName, ArtistImage);
        }

        public Artist getArtist(int ArtistID)
        {
            return ar.getArtist(ArtistID);
        }

        public List<Artist> getArtists()
        {
            return ar.getArtists();
        }

        public Boolean isNameTrue(string ArtistName)
        {
            return ar.isNameTrue(ArtistName);
        }
    }
}