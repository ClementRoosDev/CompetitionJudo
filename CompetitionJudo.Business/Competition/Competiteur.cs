using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CompetitionJudo.Business
{
    public class Competiteur
    {
        public int poule { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string club { get; set; }
        public double poids { get; set; } 
        public string sexe { get; set; }
        public string categorie { get; set; }
        public bool estPresent { get; set; }
        public bool pourImpression { get; set; }

        public List<Competiteur> listeCompetiteur;


    }
}
