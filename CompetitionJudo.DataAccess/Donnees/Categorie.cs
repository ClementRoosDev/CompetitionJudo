using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.DataAccess
{
    public class Categorie : INotifyPropertyChanged
    {
        public List<Groupe> listeGroupes { get; set; }
        public Categories nomCategorie { get; set; }
        public bool toPrint { get; set; }

        public bool printed { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ToPrint
        {
            get
            {
                return toPrint;
            }
            set
            {
                toPrint = value;
                OnPropertyChanged("toPrint");
            }
        }


        protected void OnPropertyChanged(string ischecked)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                foreach (var groupe in this.listeGroupes)
                {
                    groupe.ToPrint = toPrint;
                }

                handler(this, new PropertyChangedEventArgs("listeGroupes"));
            }
        }
    }

    [Serializable]
    public enum Categories
    {
        [Description("Tous")]
        Tous,
        [Description("Baby")]
        Baby,
        [Description("Mini-Poussin")]
        MiniPoussin,
        [Description("Poussin")]
        Poussin,
        [Description("Benjamin")]
        Benjamin,
        [Description("Minime")]
        Minime,
        [Description("Cadet")]
        Cadet,
        [Description("Junior")]
        Junior,
        [Description("Senior")]
        Senior,
        [Description("Veteran")]
        Veteran
    }
}
