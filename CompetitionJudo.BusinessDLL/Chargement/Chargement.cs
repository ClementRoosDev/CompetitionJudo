using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.Business
{
    public class Chargement
    {
        public static NewDictionary<Categories, TimeSpan2> createTempsCombatParametres()
        {
            Dictionary<Categories, TimeSpan2> dictionnaireTempsCombat = new Dictionary<Categories, TimeSpan2>();
            dictionnaireTempsCombat.Add(Categories.Baby, new TimeSpan2(0, 1, 0));
            dictionnaireTempsCombat.Add(Categories.MiniPoussin, new TimeSpan2(0, 1, 15));
            dictionnaireTempsCombat.Add(Categories.Poussin, new TimeSpan2(0, 1, 30));
            dictionnaireTempsCombat.Add(Categories.Benjamin, new TimeSpan2(0, 3, 0));
            dictionnaireTempsCombat.Add(Categories.Minime, new TimeSpan2(0, 3, 30));
            dictionnaireTempsCombat.Add(Categories.Cadet, new TimeSpan2(0, 4, 0));
            dictionnaireTempsCombat.Add(Categories.Junior, new TimeSpan2(0, 5, 0));
            dictionnaireTempsCombat.Add(Categories.Senior, new TimeSpan2(0, 5, 0));
            dictionnaireTempsCombat.Add(Categories.Veteran, new TimeSpan2(0, 5, 0));
            var newDictionnaireTempsCombat = new NewDictionary<Categories, TimeSpan2>(dictionnaireTempsCombat);

            return newDictionnaireTempsCombat;
        }

        public static NewDictionary<Categories, TimeSpan2> createImmoParametres()
        {
            Dictionary<Categories, TimeSpan2> dictionnaireTempsImmo = new Dictionary<Categories, TimeSpan2>();
            dictionnaireTempsImmo.Add(Categories.Baby, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.MiniPoussin, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Poussin, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Benjamin, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Minime, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Cadet, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Junior, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Senior, new TimeSpan2(0, 0, 20));
            dictionnaireTempsImmo.Add(Categories.Veteran, new TimeSpan2(0, 0, 20));

            var newDictionnaireTempsImmo = new NewDictionary<Categories, TimeSpan2>(dictionnaireTempsImmo);

            return newDictionnaireTempsImmo;
        }

        public static int createNombreJudokasParGroupe()
        {
            return 5;
        }

    }
}
