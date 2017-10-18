using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;


namespace CalculCaisse
{
    public partial class MainFrm : Form
    {
        private string versionAppli;

        const string lastVersionURL = "http://calculcaisse.chiwawaweb.com/download/lastversion.txt";

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            // affiche la version dans la barre de titre
            versionAppli =
                Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." +
                Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." +
                Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            
            this.Text = "Calcul caisse " + versionAppli;

            // vérifie la dernière version en ligne

            if (checkUpdates()==1)
            {
                updateAppli();
            }

            // ouvre la feuille de calcul
            Calcul frm = new Calcul();
            frm.MdiParent = this;
            frm.Show();
            
        }
        
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            DialogResult dialogResult = MessageBox.Show("Etes-vous certain de vouloir fermer la feuille de calcul ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // ferme l'application
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
            */
        }

        private static bool CheckInternetConnection()
        {
            int Desc;
            if (InternetGetConnectedState(out Desc, 0))
            {
                // connexion internet OK
                return true;
            }
            else
            {
                // pas de connexion internet
                return false;
            }
        }

        private int checkUpdates()
        {
            if (CheckInternetConnection())
            {
                string lastVersionRemote;
                using (var webClient = new System.Net.WebClient())
                {
                    try
                    {
                        lastVersionRemote = webClient.DownloadString(lastVersionURL);
                        if (lastVersionRemote != versionAppli)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    catch
                    {
                        return 3;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        private void aProposToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void archivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ouvre le dossier des archives
            try
            {
                System.Diagnostics.Process.Start(@"archives");
            }
            catch
            {
                MessageBox.Show("Il n'y a pas encore de dossier Archives...");
            }
        }

        private void misesÀJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (checkUpdates())
            {
                case 0:
                    MessageBox.Show("Il n'y a pas de connexion internet actuellement. Merci de réessayer ultérieurement.");
                    break;

                case 1:

                    updateAppli();
                    break;

                case 2:
                    MessageBox.Show("Vous avez la dernière version disponible.", "Recherche de mises à jour...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;

                case 3:
                    MessageBox.Show("Erreur serveur. Merci de réessayer ultérieurement.");
                    break;
            }
        }

        private void updateAppli()
        {
            NewUpdate frm = new NewUpdate();
            frm.ShowDialog();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }
    }
}
