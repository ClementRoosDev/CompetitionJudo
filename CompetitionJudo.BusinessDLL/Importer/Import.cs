
using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.Business
{
    public class Import
    {
        public static List<Competiteur> ImportCSV(string cheminFichier)
        {
            var listeNouveauxCompetiteur = new List<Competiteur>();

            string line;
            using (StreamReader reader = new StreamReader(cheminFichier, Encoding.GetEncoding(1252)))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');

                    if (!String.IsNullOrWhiteSpace(values[0]) && !String.IsNullOrWhiteSpace(values[1]) && !String.IsNullOrWhiteSpace(values[5]))
                    {
                        Competiteur competiteurTemporaire = new Competiteur
                        {
                            nom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values[0].ToLower()),
                            prenom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values[1].ToLower()),
                            club = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values[4].ToLower())
                        };

                        Sexes sexOut;
                        if (Enum.TryParse(values[2], out sexOut))
                        {
                            competiteurTemporaire.sexe = (Sexes)Enum.Parse(typeof(Sexes), values[2]);
                        }

                        double doubleOut;
                        if (double.TryParse(values[3], out doubleOut))
                        {
                            competiteurTemporaire.poids = Convert.ToDouble(values[3]);
                        }
                        else
                        {
                            competiteurTemporaire.poids = 0;
                        }

                        Categories categoriesOut;
                        if (Enum.TryParse(values[5], out categoriesOut))
                        {
                            competiteurTemporaire.categorie = (Categories)Enum.Parse(typeof(Categories), values[5]);
                        }
                        listeNouveauxCompetiteur.Add(competiteurTemporaire);
                    }
                }
            }
            return listeNouveauxCompetiteur;
        }
    }
}
