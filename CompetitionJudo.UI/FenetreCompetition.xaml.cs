using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CompetitionJudo.Business;
using Microsoft.Win32;
using CompetitionJudo.DataAccess;
using System.Collections.ObjectModel;

namespace CompetitionJudo.UI
{
    public partial class FenetreCompetition : Window
    {
        #region private fields       
        private Donnee donneeCompetition;

        #endregion

        #region ctor                      
        public FenetreCompetition(Donnee importDonnee)
        {
            InitializeComponent();
            this.donneeCompetition = importDonnee;

            ChargementListes();
            ChargementTreeView();
        }


        #endregion

        private void ChargementTreeView()
        {

            //TreeviewGroupes.DataContext = donnee.listeCompetiteursPresents;
        }

        //Trier les compétiteurs présents par poids, catégorie et sexe et leur attribuer un numéro de poule
        private void boutonGenererPoules_Click(object sender, RoutedEventArgs e)
        {          
            

            
            //affichageSelectif();
            //TreeviewGroupes.DataContext = GenerationGroupe.GenerateTreeview(donneeCompetition, donneeCompetition.nombreParPoule);
            TreeviewGroupes.ItemsSource = GenerationGroupe.GenerateTreeview(donneeCompetition, donneeCompetition.nombreParPoule);
        }

        #region Databind

        private void ChargementListes()
        {
            listeClub.DataContext = donneeCompetition.listeCompetiteurs.Select(c => c.club).Distinct().ToList();
            //listeClub.ItemsSource = DonneeManager.Clubs;
            //grilleCompetiteurs.DataContext = DonneeManager.Competiteurs;
            grilleCompetiteurs.DataContext = donneeCompetition.listeCompetiteurs;

            listeCategorie.DataContext = CategorieManager.ListeCategories;
            FiltreColonneCategorie.DataContext = CategorieManager.ListeCategories;
            FiltreColonneCategorie.SelectedValue = CategorieManager.ListeCategories.First();
            FiltreColonneSexe.DataContext = SexeManager.ListeSexes;
            FiltreColonneSexe.SelectedValue = SexeManager.ListeSexes.First();
            FiltreColonneEstPrésent.DataContext = PresenceManager.ListeCategories;
            FiltreColonneEstPrésent.SelectedValue = PresenceManager.ListeCategories.First();

            this.Title = string.Format("{0} {1:dd-MM-yyyy} | {2}", donneeCompetition.nomCompetition, donneeCompetition.dateCompetition, donneeCompetition.lieuCompetition);

        }
        #endregion

        #region Remise à zero des champs de texte
        /**
         * Remise à zero des champs compétiteur
         */
        private void resetChamps()
        {
            textePrenom.Text = "Prenom";
            texteNom.Text = "Nom";
            textePoids.Text = "Poids";
            listeCategorie.Text = "Catégorie";
            listeClub.Text = "Club";
            checkPresent.IsChecked = false;
            barreSexe.Value = 1;
        }
        #endregion

        #region focus sur les champs de texte
        private void texteNom_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = string.Empty;
        }

        private void textePrenom_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = string.Empty;
        }

        private void textePoids_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = string.Empty;
        }
        #endregion

        #region Ajout nouveau Compétiteur
        /*
         * Les valeur des champs sont ajoutées à un nouveau compétiteur
         * Les champs sont ensuite remis à zero
         */
        private void boutonAjouterCompetiteur_Click(object sender, RoutedEventArgs e)
        {     
            bool estValide = true;

            var newCompetiteur = new Competiteur()
            {
                club = listeClub.Text,
                nom = texteNom.Text,
                prenom = textePrenom.Text,
            };
            try
            {
                newCompetiteur.categorie = (Categories)listeCategorie.SelectedValue;
            }
            catch (Exception)
            {
                estValide = false;
                MessageBox.Show("Catégorie non selectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!String.IsNullOrWhiteSpace(textePoids.Text))
                try
                {
                    textePoids.Text = textePoids.Text.Replace('.', ',');
                    newCompetiteur.poids = Convert.ToDouble(textePoids.Text);
                }
                catch (FormatException)
                {
                    estValide = false;
                    MessageBox.Show("Poids invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            //Infos  de la barre à curseur glissant qui itère entre 0 (masculin) et 1 (féminin)
            switch (Convert.ToInt16(barreSexe.Value))
            {
                case 0:
                    newCompetiteur.sexe = Sexes.M;
                    break;
                case 1:
                    {
                        estValide = false;
                        MessageBox.Show("Sexe invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case 2:
                    newCompetiteur.sexe = Sexes.F;
                    break;
            }

            newCompetiteur.estPresent = (bool)checkPresent.IsChecked;

            Random r = new Random();
            newCompetiteur.id = r.Next(10000);
            while (donneeCompetition.listeCompetiteurs.Select(c => c.id).Contains(newCompetiteur.id))
            {
                newCompetiteur.id = r.Next(10000);
            }

            if (estValide)
            {
                resetChamps();   

                donneeCompetition.listeCompetiteurs.Add(newCompetiteur);

                affichageSelectif();
            }

            RefreshListeClub();
        }
        #endregion

        #region Rafraichit liste club
        private void RefreshListeClub()
        {
            listeClub.DataContext = donneeCompetition.listeCompetiteurs.Select(c => c.club).Distinct().ToList();
            //listeClub.ItemsSource = DonneeManager.Clubs;
        }
        #endregion

        #region Test sur l'input du poids
        private void textePoids_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsDigit(c) && c != ',' && c != '.')
                {
                    e.Handled = true;
                }
            }
        }

        private void textePoule_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsDigit(c))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region Focus sur les liste club et categories
        private void listeClub_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (ComboBox)sender;
            tb.Text = string.Empty;
        }

        private void listeCategorie_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (ComboBox)sender;
            tb.Text = string.Empty;
        }
        #endregion

        #region Clic Supprimer compétiteur
        private void boutonSupprimerCompetiteur_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Supprimer un compétiteur ?";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Exclamation;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, "", btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    Competiteur c = (Competiteur)grilleCompetiteurs.SelectedItem;
                    donneeCompetition.listeCompetiteurs.Remove(c);                 
                    affichageSelectif();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion

        #region Générer un groupe => Fenetre impression
        private void boutonGenererUnGroupe_Click(object sender, RoutedEventArgs e)
        {
            foreach (var categorie in donneeCompetition.listeTreeviewGroupes)
            {
                var lesGroupesPourImpression = new List<Groupe>();
                foreach (var groupe in categorie.listeGroupes)
                {
                    if (groupe.ToPrint)
                    {
                        lesGroupesPourImpression.Add(groupe);
                    }
                }
                var fenetreImpression = new FenetreImpression(lesGroupesPourImpression, donneeCompetition);
                fenetreImpression.Show();
            }


            /*

            if (donnee.listeCompetiteursEnregitres.Where(c => c.pourImpression).Count() >= 2)
            {
                var listegroupes = new List<int>();
                foreach (var comp in donnee.listeCompetiteursEnregitres)
                {
                    if (comp.poule != null)
                    {
                        if (!listegroupes.Any(c => c == comp.poule))
                        {
                            listegroupes.Add((int)comp.poule);
                        }
                    }
                }

                var lesGroupes = new List<Groupe>();
                foreach (var groupe in listegroupes)
                {
                    var groupeTemp = new Groupe();
                    groupeTemp.id = groupe;
                    foreach (var comp in donnee.listeCompetiteursEnregitres)
                    {
                        if (comp.poule == groupe)
                        {
                            if (comp.pourImpression)
                                groupeTemp.competiteurs.Add(comp);
                        }
                    }
                    lesGroupes.Add(groupeTemp);
                }
                var lesGroupesPourImpression = new List<Groupe>();

                List<int> groupesNonValides = new List<int>();
                foreach (var g in lesGroupes)
                {
                    if (g.competiteurs.Count != 0)
                    {
                        if (g.competiteurs.Count < 2 || g.competiteurs.Count > 5)
                        {
                            groupesNonValides.Add(g.id);
                        }
                        else
                        {
                            lesGroupesPourImpression.Add(g);
                        }
                    }
                }

                if (groupesNonValides.Count == 0)
                {
                    var fenetreImpression = new FenetreImpression(lesGroupesPourImpression, this.donnee);
                    fenetreImpression.Show();
                }
                else
                {
                    groupesNonValides.Sort();
                    MessageBox.Show(String.Format("{0}{1}Poules n° : {2}", "Des poules ont un mauvais nombre de compétiteurs ", Environment.NewLine, string.Join(", ", groupesNonValides), "Erreur", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            }
            else
            {

                MessageBox.Show("Pas assez de compétiteurs selectionnés pour l'impression ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             * */
        }
        #endregion

        #region affichage selectif de la grille
        private void ComboBoxFiltreCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            affichageSelectif();
        }

        //Gère l'affichage de la grille selon les listes déroulantes selectionnées
        private void affichageSelectif()
        {
            grilleCompetiteurs.DataContext = SelectionGrille.GetCompetiteursFiltres(donneeCompetition.listeCompetiteurs, (Categories)FiltreColonneCategorie.SelectedValue,(Sexes)FiltreColonneSexe.SelectedValue,(Presence)FiltreColonneEstPrésent.SelectedValue);
            grilleCompetiteurs.Items.Refresh();
            MajStats();
        }

        private void MajStats()
        {
            LabelInscrits.Content = donneeCompetition.listeCompetiteurs.Count();
            LabelPrésents.Content = donneeCompetition.listeCompetiteurs.Where(c => c.estPresent).Count();
        }

        private void FiltreColonneEstPrésent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            affichageSelectif();
        }
        #endregion

        //Filtre a partir du nom
        private void FiltreColonneNom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (FiltreColonneNom.Text.Length > 0)
            {
                grilleCompetiteurs.DataContext = donneeCompetition.listeCompetiteurs.Where(c => c.nom.ToLower().StartsWith(FiltreColonneNom.Text.ToLower())).ToList();
            }
            else
            {
                affichageSelectif();
            }
        }

        //Filtre a partir du prenom
        private void FiltreColonnePrenom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (FiltreColonnePrenom.Text.Length > 0)
            {
                grilleCompetiteurs.DataContext = donneeCompetition.listeCompetiteurs.Where(c => c.prenom.ToLower().StartsWith(FiltreColonnePrenom.Text.ToLower())).ToList();
            }
            else
            {
                affichageSelectif();
            }
        }

        //Import depuis CSV
        private void boutonImporterExcel_Click(object sender, RoutedEventArgs e)
        {
            List<Competiteur> listeNouveauxCompetiteur = null;
            try
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = "csv files (*.csv)|*.csv";
                if ((bool)dialog.ShowDialog())
                {
                    listeNouveauxCompetiteur = Import.ImportCSV(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Chargement :" + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Action<Competiteur> addCompetiteursCallback = addCompetiteurs;
            if (listeNouveauxCompetiteur.Count > 0)
            {
                FenetreVide fenetre = new FenetreVide(listeNouveauxCompetiteur, addCompetiteursCallback);
                fenetre.Show();
            }

        }

        //Callback pour ajouter des Competiteurs à partir de la fenetre d'import
        private void addCompetiteurs(Competiteur competiteur)
        {
            Competiteur Comp = donneeCompetition.listeCompetiteurs.Where(c => c.nom.ToLower().Equals(competiteur.nom.ToLower()) && c.prenom.ToLower().Equals(competiteur.prenom.ToLower())).FirstOrDefault();

            if (Comp == null)
            {
                donneeCompetition.listeCompetiteurs.Add(competiteur);
                affichageSelectif();
            }
            else
            {
                if (MessageBox.Show(string.Format("Un judoka identique existe déjà : {0}-{1} {2} {3}kg {4} {5} Ajouter quand même : {6}-{7} {8} {9}kg {10}",
                    Environment.NewLine, Comp.nom, Comp.prenom, Comp.poids, Comp.categorie,
                    Environment.NewLine,
                    Environment.NewLine, competiteur.nom, competiteur.prenom, competiteur.poids, competiteur.categorie), "Doublon", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    donneeCompetition.listeCompetiteurs.Add(competiteur);
                    affichageSelectif();
                }
            }
        }

        //Callback pour mettre ) jour les temps de combats
        private void updateTempsDeCombat(NewDictionary<Categories, TimeSpan2> listeTempsCombat)
        {
            donneeCompetition.tempsCombat = listeTempsCombat;
        }

        //callback pour mettre à jour le nombre de judokas par poule
        private void updateNombreJudokasParPoule(int nbJudokasParPoule)
        {
            donneeCompetition.nombreParPoule = nbJudokasParPoule;
        }

        //Résultats généraux
        private void ButtonResultatClub_Click(object sender, RoutedEventArgs e)
        {
            //List<int> data = donnee.listeCompetiteursEnregitres.Where(c => c.resultat != 0).GroupBy(c => new{ MyClub = c.club }).Select(f => new { Average = f.Average(p => p.resultat), Club = f.Key.MyClub}).ToList();
            var listClub = donneeCompetition.listeCompetiteurs.Where(c => c.resultat != 0).GroupBy(c => c.club).Select(f => new { Club = f.Key, Moyenne = f.Average(g => g.resultat), NombreEngages = f.Count() });
            listClub = listClub.OrderBy(c => c.Moyenne);
            List<ResultatCompetition> listeResult = new List<ResultatCompetition>();
            int placeFinale = 1;
            foreach (var item in listClub)
            {
                listeResult.Add(new ResultatCompetition { place = placeFinale, club = item.Club, placeMoyenne = Math.Round((double)item.Moyenne, 2), NombreEngages = item.NombreEngages });
                placeFinale++;
            }

            Fenetre_Stats fenetreStats = new Fenetre_Stats(listeResult);
            fenetreStats.loadDatas();
            fenetreStats.Show();
        }

        private void boutonParametres_Click(object sender, RoutedEventArgs e)
        {
            Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsCombats = updateTempsDeCombat;
            Action<NewDictionary<Categories, TimeSpan2>> actionUpdateTempsImmo = uppdateTempsImmo;
            Action<int> actionUpdateNbJudokas = updateNombreJudokasParPoule;
            FenetreParametres fen = new FenetreParametres(actionUpdateTempsCombats, actionUpdateTempsImmo, actionUpdateNbJudokas, donneeCompetition.tempsCombat, donneeCompetition.tempsImmobilisation, donneeCompetition.nombreParPoule);
            fen.Show();

        }

        private void uppdateTempsImmo(NewDictionary<Categories, TimeSpan2> listeTempsImmo)
        {
            donneeCompetition.tempsImmobilisation = listeTempsImmo;
        }

        #region Bouton ajouter competiteur

        //Enable ou disable le bouton d'ajout des compétiteurs
        private void isButtonCompetiteurEnable()
        {
            if (texteNom != null &&
                textePrenom != null &&
                textePoids != null &&
                listeClub != null &&
                listeCategorie != null &&
                barreSexe != null &&
                boutonAjouterCompetiteur != null)
            {
                if (!String.IsNullOrWhiteSpace(texteNom.Text) &&
                !String.IsNullOrWhiteSpace(textePrenom.Text) &&
                !String.IsNullOrWhiteSpace(textePoids.Text) &&
                !String.IsNullOrWhiteSpace(listeClub.Text) &&
                !listeClub.Text.Equals("Club") &&
                !String.IsNullOrWhiteSpace(listeCategorie.Text) &&
                !listeCategorie.Text.Equals("Catégorie") &&
                !listeCategorie.Text.Equals("Tous") &&
                Convert.ToInt16(barreSexe.Value) != 1)
                {
                    boutonAjouterCompetiteur.IsEnabled = true;
                }
                else
                {
                    boutonAjouterCompetiteur.IsEnabled = false;
                }
            }
        }

        private void text_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isButtonCompetiteurEnable();
        }

        private void barreSexe_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            isButtonCompetiteurEnable();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isButtonCompetiteurEnable();
        }

        private void list_DropDownClosed(object sender, EventArgs e)
        {
            isButtonCompetiteurEnable();
        }

        #endregion


        private void DownPanelGroupe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpPanelGroupe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownPanelListe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpPanelListe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckCategorie_Checked(object sender, RoutedEventArgs e)
        {
            //TreeviewGroupes.DataContext = null;
            //TreeviewGroupes.DataContext = donnee;

        }

        private void boutonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Enregistrement.EnregistrerXML(donneeCompetition);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

    }
}
