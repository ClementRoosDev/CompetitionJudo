using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CompetitionJudo.DataAccess
{
    [Serializable]
    public class Donnee
    {
        public List<Competiteur> listeCompetiteurs { get; set; }
        public string lieuCompetition { get; set; }
        public string nomCompetition { get; set; }
        public DateTime dateCompetition { get; set; }
        public string cheminFichier { get; set; }
        public int nombreParPoule { get; set; }
        public NewDictionary<Categories, TimeSpan2> tempsCombat { get; set; }
        public NewDictionary<Categories, TimeSpan2> tempsImmobilisation { get; set; }

        public List<Categorie> listeTreeviewGroupes { get; set; }
    }   

}
