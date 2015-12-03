using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.DataAccess
{
    public class PresenceManager
    {
        public static List<Presence> ListeCategories
        {
            get
            {
                return Enum.GetValues(typeof(Presence)).Cast<Presence>().ToList();
            }
        }
    }
}
