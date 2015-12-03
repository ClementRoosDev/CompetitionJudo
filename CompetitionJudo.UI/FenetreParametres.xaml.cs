using CompetitionJudo.Business;
using CompetitionJudo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompetitionJudo.UI
{
    /// <summary>
    /// Logique d'interaction pour FenetreParametres.xaml
    /// </summary>
    public partial class FenetreParametres : Window
    {
        private Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsCombats { get; set; }
        private Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsImmo { get; set; }
        private Action<int> actionUpdateNbJudokas { get; set; }


        private int NbJudokasParPoule { get; set; }
        private NewDictionary<Categories, TimeSpan2> tempsCombats { get; set; }
        private Dictionary<Categories, TimeSpan> tempsCombatsDict = new Dictionary<Categories, TimeSpan>();

        private NewDictionary<Categories, TimeSpan2> tempsImmo { get; set; }
        private Dictionary<Categories, TimeSpan> tempsImmoDict = new Dictionary<Categories, TimeSpan>();


        public FenetreParametres()
        {
            InitializeComponent();
            InitializePerso();
        }

        public FenetreParametres(Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsCombats,
                                Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsImmo,
                                Action<int> actionUpdateNbJudokas,
                                NewDictionary<Categories, TimeSpan2> tempsCombat,
                                NewDictionary<Categories, TimeSpan2> tempsImmo,
                                int NbrJudokas)
        {
            InitializeComponent();

            this.actionUpdateTempsCombats = actionUpdateTempsCombats;
            this.actionUpdateNbJudokas = actionUpdateNbJudokas;
            this.actionUpdateTempsImmo = actionUpdateTempsImmo;


            this.NbJudokasParPoule = NbrJudokas;
            this.tempsCombats = tempsCombat;
            this.tempsImmo = tempsImmo;

            InitializePerso();
        }

        private void InitializePerso()
        {
            listeCompetiteursPresents.ItemsSource = (List<Categories>)Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();
            foreach (var item in tempsCombats.ToDictionary())
            {
                tempsCombatsDict.Add(item.Key, item.Value.TimeSinceLastEvent);
            }
            listeCompetiteursPresents.SelectedIndex = 1;



            listeCompetiteursPresentsImmo.ItemsSource = (List<Categories>)Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();
            foreach (var item in tempsImmo.ToDictionary())
            {
                tempsImmoDict.Add(item.Key, item.Value.TimeSinceLastEvent);
            }
            listeCompetiteursPresentsImmo.SelectedIndex = 1;

            switch (NbJudokasParPoule)
            {
                case 2:
                    ListeNombreJudokasParPoule.SelectedIndex = 0;
                    break;
                case 3:
                    ListeNombreJudokasParPoule.SelectedIndex = 1;
                    break;
                case 4:
                    ListeNombreJudokasParPoule.SelectedIndex = 2;
                    break;
                case 5:
                    ListeNombreJudokasParPoule.SelectedIndex = 3;
                    break;
                case 6:
                    ListeNombreJudokasParPoule.SelectedIndex = 4;
                    break;

                default:
                    break;
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            ButtonOk.IsEnabled = false;

            Dictionary<Categories, TimeSpan2> dictionnaireTempsCombat = new Dictionary<Categories, TimeSpan2>();
            foreach (var item in tempsCombatsDict)
            {
                dictionnaireTempsCombat.Add(item.Key, new TimeSpan2(0, item.Value.Minutes, item.Value.Seconds));
            }
            var newdictionnaireTempsCombat = new NewDictionary<Categories, TimeSpan2>(dictionnaireTempsCombat);

            Dictionary<Categories, TimeSpan2> dictionnaireTempsImmo = new Dictionary<Categories, TimeSpan2>();
            foreach (var item in tempsImmoDict)
            {
                dictionnaireTempsImmo.Add(item.Key, new TimeSpan2(0, item.Value.Minutes, item.Value.Seconds));
            }
            var newdictionnaireTempsImmo = new NewDictionary<Categories, TimeSpan2>(dictionnaireTempsImmo);


            NbJudokasParPoule = Convert.ToInt16(ListeNombreJudokasParPoule.Text);
            actionUpdateNbJudokas(NbJudokasParPoule);
            actionUpdateTempsCombats(newdictionnaireTempsCombat);
            actionUpdateTempsImmo(newdictionnaireTempsImmo);

            this.Close();
        }

        private void listeCompetiteursPresents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Categories)listeCompetiteursPresents.SelectedItem != Categories.Tous)
            {
                TxtMinutes.Text = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Minutes.ToString();
                TxtSecondes.Text = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Seconds.ToString();
            }
            else
            {
                TxtMinutes.Text = "";
                TxtSecondes.Text = "";
            }

        }

        private void ListeNombreJudokasParPoule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpMinute_Click(object sender, RoutedEventArgs e)
        {
            tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, 1, 0));
            MàJTemps();
        }

        private void DownMinute_Click(object sender, RoutedEventArgs e)
        {
            if (tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].TotalSeconds > 59)
                tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, -1, 0));
            MàJTemps();
        }

        private void UpSecondes_Click(object sender, RoutedEventArgs e)
        {
            tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, 0, 15));
            MàJTemps();
        }

        private void DownSecondes_Click(object sender, RoutedEventArgs e)
        {
            if (tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].TotalSeconds > 14)
                tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, 0, -15));
            MàJTemps();
        }

        private void MàJTemps()
        {
            TxtSecondes.Text = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Seconds.ToString();
            TxtMinutes.Text = tempsCombatsDict[(Categories)listeCompetiteursPresents.SelectedItem].Minutes.ToString();
            TxtSecondesImmo.Text = tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem].Seconds.ToString();
        }

        private void UpSecondesImmo_Click(object sender, RoutedEventArgs e)
        {
            if (tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem].TotalSeconds < 54)
                tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, 0, 5));
            MàJTemps();
        }

        private void DownSecondesImmo_Click(object sender, RoutedEventArgs e)
        {
            if (tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem].TotalSeconds > 4)
                tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem] = tempsImmoDict[(Categories)listeCompetiteursPresents.SelectedItem].Add(new TimeSpan(0, 0, -5));
            MàJTemps();
        }

        private void listeCompetiteursPresentsImmo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Categories)listeCompetiteursPresentsImmo.SelectedItem != Categories.Tous)
            {
                TxtSecondesImmo.Text = tempsImmoDict[(Categories)listeCompetiteursPresentsImmo.SelectedItem].Seconds.ToString();
            }
            else
            {
                TxtSecondesImmo.Text = "";
            }
        }
    }
}
