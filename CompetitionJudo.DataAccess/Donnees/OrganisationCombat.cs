using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CompetitionJudo.DataAccess
{
    public abstract class OrganisationCombat
    {
        public List<Competiteur> grilleCompetiteurs { get; set; }
        public double poidsMini { get; set; }
        public double poidsMaxi { get; set; }
        public int numeroGroupe { get; set; }
        public string genre { get; set; }
        public Bitmap sourceImage { get; set; }
        public List<Coordonnee> listeCoordonneesNom { get; set; }
        public List<Coordonnee> listeCoordonneesPrenom { get; set; }
        public List<Coordonnee> listeCoordonneesClub { get; set; }         
        


        public abstract void CreerFeuille();
        public abstract void CreerCoordonnees();
    }
}
