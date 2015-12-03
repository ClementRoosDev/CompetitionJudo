﻿using System;

namespace CompetitionJudo.DataAccess
{
    [Serializable]
    public class Competiteur
    {
        public int id { get; set; }

        public string nom { get; set; }

       
        public string prenom { get; set; }
        public string club { get; set; }
        public double? poids { get; set; }
        public Sexes sexe { get; set; }
        public Categories categorie { get; set; }
        public bool estPresent { get; set; }
        public bool estDansUnePoule { get; set; }
        public int? resultat { get; set; }

        public Competiteur()
        {
            resultat = null;
            estDansUnePoule = false;
        }
        /*
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Competiteur))
            {
                return false;
            }
            var competiteur = (Competiteur)obj;
            if (this.categorie == competiteur.categorie &&
                this.club.Equals(competiteur.club) &&
                this.nom == competiteur.nom &&
                this.prenom == this.prenom &&
                this.sexe == this.sexe)
                return true;
            else
                return false;
        }*/
    }
}
