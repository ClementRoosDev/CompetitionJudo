using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompetitionJudo.Business
{
    public class PouleDe2 : Poule
    {
        public PouleDe2(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = "img\\templateP2.png";
            CreerCoordonnees();            
            
        }

        public override void CreerFeuille()
        {
        }

        public override void CreerCoordonnees()
        {
            listeCoordonneesNom = new List<Coordonnee>();
            listeCoordonneesPrenom = new List<Coordonnee>();
            listeCoordonneesClub = new List<Coordonnee>();
            var n1 = new Coordonnee(50, 200);
            var n2 = new Coordonnee(50, 260);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n2);
            var p1 = new Coordonnee(265, 200);
            var p2 = new Coordonnee(265, 260);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p2);
            var c1 = new Coordonnee(410, 200);
            var c2 = new Coordonnee(410, 260);
            listeCoordonneesClub.Add(c1);
            listeCoordonneesClub.Add(c2);
        }
    }
}
