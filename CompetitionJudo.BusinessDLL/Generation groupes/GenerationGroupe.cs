using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.Business
{
    public class GenerationGroupe
    {
        public static List<Categorie> GenerateTreeview(Donnee donnee, int nombreJudokasParPoule)
        {
            var listeDesCategories = new List<Categorie>();


            foreach (var categorie in Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList())
            {
                Categorie categorieTemp = new Categorie() { nomCategorie = categorie, listeGroupes = new List<Groupe>(), toPrint = true, printed = false };
                List<Groupe> listGroup = new List<Groupe>();

                foreach (var sex in Enum.GetValues(typeof(Sexes)).Cast<Sexes>().ToList())
                {
                    int ComptePoule = 1;

                    Groupe groupTemp = new Groupe() { listeJudokas = new ObservableCollection<Competiteur>(), nomPoule = string.Format("Poule {0}{1}", sex.ToString(), ComptePoule) };

                    List<Competiteur> listeDesCompetiteursCritereOk = donnee.listeCompetiteurs.Where(c => c.categorie == categorie && c.sexe == sex && c.estPresent).OrderBy(c => c.poids).ToList();

                    foreach (var competiteur in listeDesCompetiteursCritereOk)
                    {
                        competiteur.estDansUnePoule = true;

                        groupTemp.listeJudokas.Add(competiteur);
                        if (groupTemp.listeJudokas.Count > nombreJudokasParPoule - 1)
                        {
                            listGroup.Add(groupTemp);
                            ComptePoule++;
                            groupTemp = new Groupe() { listeJudokas = new ObservableCollection<Competiteur>(), nomPoule = string.Format("Poule {0}{1}", sex.ToString(), ComptePoule) };
                        }
                    }
                    if (groupTemp.listeJudokas.Count > 0)
                    {
                        listGroup.Add(groupTemp);
                    }
                }

                if (listGroup.Count > 0)
                {
                    categorieTemp.listeGroupes = listGroup;
                }

                if (categorieTemp.listeGroupes.Count > 0)
                {
                    listeDesCategories.Add(categorieTemp);
                }
            }
            return listeDesCategories;

        }
    }
}