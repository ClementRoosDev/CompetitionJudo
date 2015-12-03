using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Business
{
    public class Sexe
    {
        public static readonly string MASCULIN = "M";
        public static readonly string FEMININ = "F";
        public readonly List<String> Sexes = new List<string> {Sexe.MASCULIN, Sexe.FEMININ };
    }
}
