using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Business
{
    public class PouleDe3 : Poule
    {
        public PouleDe3(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = "img\\templateP3.png"; ;
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
            var n1 = new Coordonnee(12, 205);
            var n2 = new Coordonnee(12, 260);
            var n3 = new Coordonnee(12, 315);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n2);
            listeCoordonneesNom.Add(n3);
            var p1 = new Coordonnee(205, 205);
            var p2 = new Coordonnee(205, 260);
            var p3 = new Coordonnee(205, 315);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p2);
            listeCoordonneesPrenom.Add(p3);
            var c1 = new Coordonnee(360, 205);
            var c2 = new Coordonnee(360, 260);
            var c3 = new Coordonnee(360, 315);
            listeCoordonneesClub.Add(c1);
            listeCoordonneesClub.Add(c2);
            listeCoordonneesClub.Add(c3);
        }
        
    }
}
