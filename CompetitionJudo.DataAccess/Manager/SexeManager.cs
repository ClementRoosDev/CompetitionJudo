
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.DataAccess
{
    public class SexeManager
    {
        public static List<Sexes> ListeSexes
        {
            get
            {
                return Enum.GetValues(typeof(Sexes)).Cast<Sexes>().ToList();
            }
        }

    }
}
