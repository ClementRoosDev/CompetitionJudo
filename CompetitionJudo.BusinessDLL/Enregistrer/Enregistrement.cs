using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CompetitionJudo.Business
{
    public class Enregistrement
    {
        public static void EnregistrerXML(Donnee donneesCompetition)
        {
            var serialise = new XmlSerializer(typeof(Donnee));
            using (var writer = new StreamWriter(donneesCompetition.cheminFichier))
            {
                serialise.Serialize(writer, donneesCompetition);
            }
        }
    }
}
