using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace CompetitionJudo.Data
{
    public class Groupe : INotifyPropertyChanged
    {
        public ObservableCollection<Competiteur> listeJudokas { get; set; }
        public string nomPoule { get;set;}

        public event PropertyChangedEventHandler PropertyChanged;
        public int id { get; set; }

        private bool toPrint { get; set; }
        public double poidsMini { get; set; }
        public double poidsMax { get; set; }
        public double ecartPoids { get; set; }
        public ValiditeGroupes validiteGroupe { get; set; }

        public string ImageSource { get; set; }

        public TypeGroupe typeGroupe { get; set; }

        public Groupe()
        {
            listeJudokas = new ObservableCollection<Competiteur>();
            typeGroupe = TypeGroupe.Poule;

        }
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

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string ischecked)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(ischecked));                
            }
        }
        public override string ToString()
        {
            return id.ToString();
        }

    }

    public enum TypeGroupe
    {
        Tableau,
        Poule
    }
}
