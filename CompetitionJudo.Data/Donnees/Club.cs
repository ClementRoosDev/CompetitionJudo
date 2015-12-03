using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Data
{
    [Serializable]
    public class Club : IEquatable<Club>
    {
        public string nom { get; set; }
        public string acronyme { get; set; }
        public int Code{get;set;}

        public override string ToString()
        {
            return nom;
        }

        public override bool Equals(object obj)
        {
            Club club = (Club)obj;
            return this.nom.Equals(club.nom);
        }

        public bool Equals(Club club)
        {
            return this.nom.Equals(club.nom);
        }

        //Implementé pour le distinct sur les clubs
        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null. 
            int hashProductName = nom == null ? 0 : nom.GetHashCode();

            //Get hash code for the Code field. 
            int hashProductCode = Code.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }

    
}
