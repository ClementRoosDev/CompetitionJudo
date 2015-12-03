using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Media;
using CompetitionJudo.Business;
using CompetitionJudo.DataAccess;


namespace CompetitionJudo.UI
{
    public class ImageGroupe
    {
        public string nomPoule {get;set;}
        Groupe groupe;
        public Image imageGroupe;
        public Graphics g;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Yellow);
        public OrganisationCombat poule;


        public ImageGroupe(Groupe groupe)
        {
            this.groupe = groupe;

            init();
            //imageGroupe = System.Drawing.Image.FromFile(poule.sourceImage);
            imageGroupe = new Bitmap(poule.sourceImage);
            
        }

        private void init()
        {
            if (groupe.typeGroupe == TypeGroupe.Tableau)
            {
                if (groupe.listeJudokas.Count <= 4)
                {
                    poule = new TableauDe4(groupe.listeJudokas.ToList());
                }
                if (groupe.listeJudokas.Count > 4 && groupe.listeJudokas.Count <= 8)
                {
                    poule = new TableauDe8(groupe.listeJudokas.ToList());
                }
                if (groupe.listeJudokas.Count > 8 && groupe.listeJudokas.Count <= 16)
                {
                    poule = new TableauDe16(groupe.listeJudokas.ToList());
                }
                if (groupe.listeJudokas.Count > 16 && groupe.listeJudokas.Count <= 32)
                {
                    poule = new TableauDe32(groupe.listeJudokas.ToList());
                }
            }
            else
            {
                switch (groupe.listeJudokas.Count())
                {
                    case 2:
                        poule = new PouleDe2(groupe.listeJudokas.ToList());
                         break;
                    case 3:
                         poule = new PouleDe3(groupe.listeJudokas.ToList()); 
                        break;
                    case 4:
                        poule = new PouleDe4(groupe.listeJudokas.ToList()); 
                        break;
                    case 5:
                        poule = new PouleDe5(groupe.listeJudokas.ToList()); 
                        break;
                    case 6:
                        poule = new PouleDe6(groupe.listeJudokas.ToList()); 
                        break;
                }
            }
        }

        private void DrawCompetiteurs()
        {
            for (int i = 0; i < this.groupe.listeJudokas.Count(); i++)
            {
                
            }
        }
    }
}
