using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factories;

namespace KpopZtation.Repositories
{
    public class ArtistRepository
    {
        private Database1Entities1 db;
        Artist a;

        public ArtistRepository()
        {
            db = new Database1Entities1();
            a = new Artist();
        }

        public void insertArtist(string ArtistName, string ArtistImage)
        {
            a = ArtistFactory.createArtist(ArtistName, ArtistImage);
            db.Artists.Add(a);
            db.SaveChanges();
        }

        public void deleteArtist(int ArtistID)
        {
            a = db.Artists.Find(ArtistID);
            db.Artists.Remove(a);
            db.SaveChanges();
        }

        public void updateArtist(int ArtistID, string ArtistName, string ArtistImage)
        {
            a = db.Artists.Find(ArtistID);
            a.ArtistName = ArtistName;
            a.ArtistImage = ArtistImage;
            db.SaveChanges();
        }

        public Artist getArtist(int ArtistID)
        {
            a = db.Artists.Find(ArtistID);
            return a;
        }

        public List<Artist> getArtists()
        {
            List<Artist> artists = new List<Artist>();
            artists = (from allArtist in db.Artists select allArtist).ToList();
            return artists;
        }

        public Boolean isNameTrue(string ArtistName)
        {
            a = (from Aname in db.Artists where Aname.ArtistName.Equals(ArtistName) select Aname).FirstOrDefault();
            if(a == null)
            {
                return false;
            }
            return true;
        }
    }
}