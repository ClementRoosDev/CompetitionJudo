using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.DataAccess
{
    public class CategorieManager
    {
        public static List<Categories> ListeCategories
        {
            get
            {
                return Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();
            }
        }
    }
}
