﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.DataAccess
{
    public class Competition
    {
        private List<Competiteur> listeCompetiteursEnregitres { get; set; }
        private string lieu { get; set; }
        private DateTime date { get; set; }

        private void CreerToutesLesFeuilles()
        {
            var listCompetiteursParPoules = new List<List<Competiteur>>();


        }
    }
}
