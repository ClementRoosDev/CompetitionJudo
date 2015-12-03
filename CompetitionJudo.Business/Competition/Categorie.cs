using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace CompetitionJudo.Business
{
    public class Categorie
    {
        private static string BABY = "Baby";
        private static string MINIPOUSSIN = "Mini-Poussin";
        private static string POUSSIN = "Poussin";
        private static string BENJAMIN = "Benjamin";
        private static string MINIME = "Minime";
        private static string CADET = "Cadet";
        private static string JUNIOR = "Junior";
        private static string SENIOR = "Senior";
        private static string VETERAN = "Vétéran";
        private static string TOUS = "Tous";
        public static List<string> listeDesCategories = new List<string> { Categorie.BABY, Categorie.MINIPOUSSIN, Categorie.POUSSIN,Categorie.BENJAMIN, Categorie.MINIME, Categorie.CADET, Categorie.JUNIOR, Categorie.SENIOR, Categorie.VETERAN, Categorie.TOUS };
    }
}
