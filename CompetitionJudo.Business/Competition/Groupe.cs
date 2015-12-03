using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Business
{
    public class Groupe
    {
        public List<Competiteur> competiteurs { get; set;}
        public int id {get;set;}
        // Poule : Type groupe  = 0 : Tableau, type groupe = 1  : poule
        public int typeGroupe = 0;
        public Groupe()
        {
            competiteurs = new List<Competiteur>();
        }
        public override string ToString()
        {
            return id.ToString();
        }

    }
}
