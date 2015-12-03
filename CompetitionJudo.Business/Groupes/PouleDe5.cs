using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Business
{
    public class PouleDe5 : Poule
    {
        public PouleDe5(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = "img\\templateP5.png";
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
            var n1 = new Coordonnee(15, 205);
            var n2 = new Coordonnee(15, 260);
            var n3 = new Coordonnee(15, 315);
            var n4 = new Coordonnee(15, 370);
            var n5 = new Coordonnee(15, 425);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n2);
            listeCoordonneesNom.Add(n3);
            listeCoordonneesNom.Add(n4);
            listeCoordonneesNom.Add(n5);
            var p1 = new Coordonnee(140, 205);
            var p2 = new Coordonnee(140, 260);
            var p3 = new Coordonnee(140, 315);
            var p4 = new Coordonnee(140, 370);
            var p5 = new Coordonnee(140, 425);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p2);
            listeCoordonneesPrenom.Add(p3);
            listeCoordonneesPrenom.Add(p4);
            listeCoordonneesPrenom.Add(p5);
            var cl1 = new Coordonnee(230, 205);
            var cl2 = new Coordonnee(230, 260);
            var cl3 = new Coordonnee(230, 315);
            var cl4 = new Coordonnee(230, 370);
            var cl5 = new Coordonnee(230, 425);
            listeCoordonneesClub.Add(cl1);
            listeCoordonneesClub.Add(cl2);
            listeCoordonneesClub.Add(cl3);
            listeCoordonneesClub.Add(cl4);
            listeCoordonneesClub.Add(cl5);

        }
    }
}
