using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.Business
{
    public class SelectionGrille
    {
        public static List<Competiteur> GetCompetiteursFiltres(List<Competiteur> listCompetiteurs, Categories categories, Sexes sexes, Presence presence)
        {
            if (presence == Presence.Tous)
            {
                if (sexes == Sexes.Tous)
                {
                    if (categories == Categories.Tous)
                        return listCompetiteurs.ToList();
                    else
                        return listCompetiteurs.Where(c => c.categorie == categories).ToList();
                }
                else
                {
                    if (categories == Categories.Tous)
                        return listCompetiteurs.Where(d => d.sexe == sexes).ToList();
                    else
                        return listCompetiteurs.Where(c => c.categorie == categories && c.sexe == sexes).ToList();

                }
            }
            else
            {
                if (presence == Presence.Présent)
                {
                    if (sexes == Sexes.Tous)
                    {
                        if (categories == Categories.Tous)
                            return listCompetiteurs.Where(c => c.estPresent).ToList();
                        else
                            return listCompetiteurs.Where(c => c.categorie == categories && c.estPresent).ToList();
                    }
                    else
                    {
                        if (categories == Categories.Tous)
                            return listCompetiteurs.Where(c => c.estPresent && c.sexe == sexes).ToList();
                        else
                            return listCompetiteurs.Where(c => c.estPresent && c.categorie == categories && c.sexe == sexes).ToList();
                    }
                }
                else
                {
                    if (sexes == Sexes.Tous)
                    {
                        if (categories == Categories.Tous)
                            return listCompetiteurs.Where(c => !c.estPresent).ToList();
                        else
                            return listCompetiteurs.Where(c => c.categorie == categories && !c.estPresent).ToList();
                    }
                    else
                    {
                        if (categories == Categories.Tous)
                            return listCompetiteurs.Where(c => !c.estPresent && c.sexe == sexes).ToList();
                        else
                            return listCompetiteurs.Where(c => c.categorie == categories && !c.estPresent && c.sexe == sexes).ToList();
                    }
                }
            }
        }
    }
}
