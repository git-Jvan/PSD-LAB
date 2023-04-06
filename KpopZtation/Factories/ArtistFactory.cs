using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class ArtistFactory
    {
        public static Artist createArtist(string ArtistName, string ArtistImage)
        {
            Artist a = new Artist();
            a.ArtistName = ArtistName;
            a.ArtistImage = ArtistImage;
            return a;
        }
    }
}