using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Deployment.Application;
using System.Reflection;
using CalculCaisse.Library;

namespace CalculCaisse
{
    public partial class Calcul : Form
    {
        Billet B500 = new Billet(500);
        Billet B200 = new Billet(200);
        Billet B100 = new Billet(100);
        Billet B50 = new Billet(50);
        Billet B20 = new Billet(20);
        Billet B10 = new Billet(10);
        Billet B5 = new Billet(5);


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // remplace la touche Enter par TAB et donc passe au champ suivant
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private PrintDocument printDocument1 = new PrintDocument();

        // déclaration des variables
        int  nbB200, nbB100, nbB50, nbB20, nbB10, nbB5;
        double totB500, totB200, totB100, totB50, totB20, totB10, totB5, totBillets;

        int nbP2, nbP1, nbP050, nbP020, nbP010, nbP005, nbP002, nbP001, totP2;
        double totP1, totP050, totP020, totP010, totP005, totP002, totP001, totPieces;

        int nbR2, nbR1, nbR050, nbR020, nbR010, nbR005, nbR002, nbR001;
        double totR2, totR1, totR050, totR020, totR010, totR005, totR002, totR001, totRouleaux;

        double totCoffre, totCaisse, totEspeces, mtDepot, diffCaisse;

        public Calcul()
        {
            // constructeur
            InitializeComponent();
        }

        private void ExecuteCalculs()
        {
            /* Récupération des données */
            int nbB500 = int.Parse(txt_nbB500.Text);
            int nbB200 = int.Parse(txt_nbB200.Text);

            /* Calcul */
            double totalB500 = (B500.Total(nbB500));
            double totalB200 = (B200.Total(nbB200));



            /* Affichage */
            /*
            txtTotalB500.Text = totalB500.ToString();
            txtTotalB200.Text = totalB200.ToString();
            */


            // contrôle si valeur nulle ou vide dans chaque champ
            if (String.IsNullOrEmpty(txt_nbB500.Text)) { nbB500 = 0; } else { nbB500 = Convert.ToInt32(txt_nbB500.Text); }
            if (String.IsNullOrEmpty(txt_nbB200.Text)) { nbB200 = 0; } else { nbB200 = Convert.ToInt32(txt_nbB200.Text); }
            if (String.IsNullOrEmpty(txt_nbB100.Text)) { nbB100 = 0; } else { nbB100 = Convert.ToInt32(txt_nbB100.Text); }
            if (String.IsNullOrEmpty(txt_nbB50.Text)) { nbB50 = 0; } else { nbB50 = Convert.ToInt32(txt_nbB50.Text); }
            if (String.IsNullOrEmpty(txt_nbB20.Text)) { nbB20 = 0; } else { nbB20 = Convert.ToInt32(txt_nbB20.Text); }
            if (String.IsNullOrEmpty(txt_nbB10.Text)) { nbB10 = 0; } else { nbB10 = Convert.ToInt32(txt_nbB10.Text); }
            if (String.IsNullOrEmpty(txt_nbB5.Text)) { nbB5 = 0; } else { nbB5 = Convert.ToInt32(txt_nbB5.Text); }
            if (String.IsNullOrEmpty(txt_nbP2.Text)) { nbP2 = 0; } else { nbP2 = Convert.ToInt32(txt_nbP2.Text); }
            if (String.IsNullOrEmpty(txt_nbP1.Text)) { nbP1 = 0; } else { nbP1 = Convert.ToInt32(txt_nbP1.Text); }
            if (String.IsNullOrEmpty(txt_nbP050.Text)) { nbP050 = 0; } else { nbP050 = Convert.ToInt32(txt_nbP050.Text); }
            if (String.IsNullOrEmpty(txt_nbP020.Text)) { nbP020 = 0; } else { nbP020 = Convert.ToInt32(txt_nbP020.Text); }
            if (String.IsNullOrEmpty(txt_nbP010.Text)) { nbP010 = 0; } else { nbP010 = Convert.ToInt32(txt_nbP010.Text); }
            if (String.IsNullOrEmpty(txt_nbP005.Text)) { nbP005 = 0; } else { nbP005 = Convert.ToInt32(txt_nbP005.Text); }
            if (String.IsNullOrEmpty(txt_nbP002.Text)) { nbP002 = 0; } else { nbP002 = Convert.ToInt32(txt_nbP002.Text); }
            if (String.IsNullOrEmpty(txt_nbP001.Text)) { nbP001 = 0; } else { nbP001 = Convert.ToInt32(txt_nbP001.Text); }
            if (String.IsNullOrEmpty(txt_nbR2.Text)) { nbR2 = 0; } else { nbR2 = Convert.ToInt32(txt_nbR2.Text); }
            if (String.IsNullOrEmpty(txt_nbR1.Text)) { nbR1 = 0; } else { nbR1 = Convert.ToInt32(txt_nbR1.Text); }
            if (String.IsNullOrEmpty(txt_nbR050.Text)) { nbR050 = 0; } else { nbR050 = Convert.ToInt32(txt_nbR050.Text); }
            if (String.IsNullOrEmpty(txt_nbR020.Text)) { nbR020 = 0; } else { nbR020 = Convert.ToInt32(txt_nbR020.Text); }
            if (String.IsNullOrEmpty(txt_nbR010.Text)) { nbR010 = 0; } else { nbR010 = Convert.ToInt32(txt_nbR010.Text); }
            if (String.IsNullOrEmpty(txt_nbR005.Text)) { nbR005 = 0; } else { nbR005 = Convert.ToInt32(txt_nbR005.Text); }
            if (String.IsNullOrEmpty(txt_nbR002.Text)) { nbR002 = 0; } else { nbR002 = Convert.ToInt32(txt_nbR002.Text); }
            if (String.IsNullOrEmpty(txt_nbR001.Text)) { nbR001 = 0; } else { nbR001 = Convert.ToInt32(txt_nbR001.Text); }
            if (String.IsNullOrEmpty(txt_totCoffre.Text))       { totCoffre = 0;    } else { totCoffre = Convert.ToDouble(txt_totCoffre.Text); }
            if (String.IsNullOrEmpty(txt_totEspeces.Text))      { totEspeces = 0;   } else { totEspeces = Convert.ToDouble(txt_totEspeces.Text); }
            



            totB500 = nbB500 * 500;
            totB200 = nbB200 * 200;
            totB100 = nbB100 * 100;
            totB50 = nbB50 * 50;
            totB20 = nbB20 * 20;
            totB10 = nbB10 * 10;
            totB5 = nbB5 * 5;

            totP2 = nbP2 * 2;
            totP1 = nbP1 * 1;
            totP050 = nbP050 * 0.50;
            totP020 = nbP020 * 0.20;
            totP010 = nbP010 * 0.10;
            totP005 = nbP005 * 0.05;
            totP002 = nbP002 * 0.02;
            totP001 = nbP001 * 0.01;

            totR2 = nbR2 * 50;
            totR1 = nbR1 * 25;
            totR050 = nbR050 * 20;
            totR020 = nbR020 * 8;
            totR010 = nbR010 * 4;
            totR005 = nbR005 * 2.50;
            totR002 = nbR002 * 1;
            totR001 = nbR001 * 0.50;

            totBillets = totB500 + totB200 + totB100 + totB50 + totB20 + totB10 + totB5;
            totPieces = totP2 + totP1 + totP050 + totP020 + totP010 + totP005 + totP002 + totP001;
            totRouleaux = totR2 + totR1 + totR050 + totR020 + totR010 + totR005 + totR002 + totR001;
            totCaisse = totBillets + totPieces + totRouleaux + totCoffre;
            diffCaisse = totCaisse - totEspeces;

            // calcul des billets à déposer
            double totalDepot = 0.00;
            if (String.IsNullOrEmpty(txt_montantDepot.Text)) { mtDepot = 0; } else { mtDepot = Convert.ToDouble(txt_montantDepot.Text); }
            double TB = 0.00;
            double ResteAdep = 0.00;

            // nombre de B500 à déposer
            var BD500 = 0;
            int BC500 = nbB500;
            int MB500 = Convert.ToInt32(Math.Floor(mtDepot / 500));

            if (MB500 >= BC500)
            {
                BD500 = BC500;
                TB = BD500 * 500;
            }
            else
            {
                BD500 = MB500;
                TB = 0;
            }
            var valDepotB500 = BD500 * 500;

            // nombre de B200 à déposer
            var BD200 = 0;
            int BC200 = nbB200;
            ResteAdep = mtDepot - TB;

            int MB200 = Convert.ToInt32(Math.Floor(ResteAdep / 200));

            if(MB200 >= BC200)
            {
                BD200 = BC200;
                TB += BD200 * 200;
            }
            else
            {
                BD200 = MB200;
                TB += BD200 * 200;
            }
            var valDepotB200 = BD200 * 200;

            // nombre de B100 à déposer
            var BD100 = 0;
            int BC100 = nbB100;
            ResteAdep = mtDepot - TB;

            int MB100 = Convert.ToInt32(Math.Floor(ResteAdep / 100));

            if (MB100 >= BC100)
            {
                BD100 = BC100;
                TB += BD100 * 100;
            }
            else
            {
                BD100 = MB100;
                TB += BD100 * 100;
            }
            var valDepotB100 = BD100 * 100;

            // nombre de B50 à déposer
            var BD50 = 0;
            int BC50 = nbB50;
            ResteAdep = mtDepot - TB;

            var MB50 = Convert.ToInt32(Math.Floor(ResteAdep / 50));

            if (MB50 >= BC50)
            {
                BD50 = BC50;
                TB += BD50 * 50;
            }
            else
            {
                BD50 = MB50;
                TB += BD50 * 50;
            }
            var valDepotB50 = BD50 * 50;

            // nombre de B20 à déposer
            var BD20 = 0;
            int BC20 = nbB20;
            ResteAdep = mtDepot - TB;

            var MB20 = Convert.ToInt32(Math.Floor(ResteAdep / 20));

            if (MB20 >= BC20)
            {
                BD20 = BC20;
                TB += BD20 * 20;
            }
            else
            {
                BD20 = MB20;
                TB += BD20 * 20;
            }
            var valDepotB20 = BD20 * 20;

            // nombre de B10 à déposer
            var BD10 = 0;
            int BC10 = nbB10;
            ResteAdep = mtDepot - TB;

            var MB10 = Convert.ToInt32(Math.Floor(ResteAdep / 10));

            if (MB10 >= BC10)
            {
                BD10 = BC10;
                TB += BD10 * 10;
            }
            else
            {
                BD10 = MB10;
                TB += BD10 * 10;
            }
            var valDepotB10 = BD10 * 10;

            // nombre de B5 à déposer
            var BD5 = 0;
            int BC5 = nbB5;
            ResteAdep = mtDepot - TB;

            var MB5 = Convert.ToInt32(Math.Floor(ResteAdep / 5));

            if (MB5 >= BC5)
            {
                BD5 = BC5;
                TB += BD5 * 5;
            }
            else
            {
                BD5 = MB5;
                TB += BD5 * 5;
            }
            var valDepotB5 = BD5 * 5;

            ResteAdep = mtDepot - TB;

            // vérifie si mtDepotBanque = mtDepot
            if (TB != mtDepot)
            {
                timer_attention.Enabled = true;
            }
            else
            {
                img_attention.Visible = false;
                timer_attention.Enabled = false;
            }

            // affiche les résultats dans les champs calculés
            txt_nbDepotB500.Text = BD500.ToString();
            txt_nbDepotB200.Text = BD200.ToString();
            txt_nbDepotB100.Text = BD100.ToString();
            txt_nbDepotB50.Text = BD50.ToString();
            txt_nbDepotB20.Text = BD20.ToString();
            txt_nbDepotB10.Text = BD10.ToString();
            txt_nbDepotB5.Text = BD5.ToString();

            txt_totDepotB500.Text = valDepotB500.ToString("0.00");
            txt_totDepotB200.Text = valDepotB200.ToString("0.00");
            txt_totDepotB100.Text = valDepotB100.ToString("0.00");
            txt_totDepotB50.Text = valDepotB50.ToString("0.00");
            txt_totDepotB20.Text = valDepotB20.ToString("0.00");
            txt_totDepotB10.Text = valDepotB10.ToString("0.00");
            txt_totDepotB5.Text = valDepotB5.ToString("0.00");

            txt_totDepotBanque.Text = TB.ToString("0.00");

            txt_totB500.Text = totB500.ToString("0.00");
            txt_totB200.Text = totB200.ToString("0.00");
            txt_totB100.Text = totB100.ToString("0.00");
            txt_totB50.Text = totB50.ToString("0.00");
            txt_totB20.Text = totB20.ToString("0.00");
            txt_totB10.Text = totB10.ToString("0.00");
            txt_totB5.Text = totB5.ToString("0.00");

            txt_totP2.Text = totP2.ToString("0.00");
            txt_totP1.Text = totP1.ToString("0.00");
            txt_totP050.Text = totP050.ToString("0.00");
            txt_totP020.Text = totP020.ToString("0.00");
            txt_totP010.Text = totP010.ToString("0.00");
            txt_totP005.Text = totP005.ToString("0.00");
            txt_totP002.Text = totP002.ToString("0.00");
            txt_totP001.Text = totP001.ToString("0.00");

            txt_totR2.Text = totR2.ToString("0.00");
            txt_totR1.Text = totR1.ToString("0.00");
            txt_totR050.Text = totR050.ToString("0.00");
            txt_totR020.Text = totR020.ToString("0.00");
            txt_totR010.Text = totR010.ToString("0.00");
            txt_totR005.Text = totR005.ToString("0.00");
            txt_totR002.Text = totR002.ToString("0.00");
            txt_totR001.Text = totR001.ToString("0.00");

            txt_totBillets.Text = totBillets.ToString("0.00");
            txt_totPieces.Text = totPieces.ToString("0.00");
            txt_totRouleaux.Text = totRouleaux.ToString("0.00");

            txt_totCaisse.Text = totCaisse.ToString("0.00");
            txt_diffCaisse.Text = diffCaisse.ToString("0.00");

        }

        private void chiffreOnly(KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void chiffreDecimalOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                if (this.Text.Contains(e.KeyChar))
                    e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                e.Handled = true;
        }


        private void txt_nbB500_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB500_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }
            

        private void Calcul_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void txt_nbB200_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB200_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB100_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB100_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }
        private void txt_nbB50_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB50_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB20_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB20_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB10_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB10_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB5_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbB5_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbB500_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB500.Text))
            {
                txt_nbB500.SelectionStart = 0;
                txt_nbB500.SelectionLength = txt_nbB500.Text.Length;
            }
        }

        private void txt_nbP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP2_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP1_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP050_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP050_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP020_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP020_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP010_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP010_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP005_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP005_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP002_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP002_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP001_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbP001_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR2_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR1_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR050_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR050_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR020_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR020_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR010_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR010_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR005_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR005_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR002_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR002_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbR001_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreOnly(e);
        }

        private void txt_nbR001_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            // rafraîchi la date et l'heure
            txt_DateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            
        }

        private void Reinitialiser()
        {
            // groupe billets
            foreach (Control c in grp_billets.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
            // groupe pièces
            foreach (Control c in grp_monnaie.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
            // groupe rouleaux
            foreach (Control c in grp_rouleaux.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
            // autres champs
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }

        

        private void txt_nbB200_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB200.Text))
            {
                txt_nbB200.SelectionStart = 0;
                txt_nbB200.SelectionLength = txt_nbB200.Text.Length;
            }
        }

        private void timer_attention_Tick(object sender, EventArgs e)
        {
            if (img_attention.Visible == true) { img_attention.Visible = false; } else { img_attention.Visible = true; }
        }

        private void txt_nbB100_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB100.Text))
            {
                txt_nbB100.SelectionStart = 0;
                txt_nbB100.SelectionLength = txt_nbB100.Text.Length;
            }
        }

        private void txt_nbB50_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB50.Text))
            {
                txt_nbB50.SelectionStart = 0;
                txt_nbB50.SelectionLength = txt_nbB50.Text.Length;
            }
        }

        private void txt_nbB20_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB20.Text))
            {
                txt_nbB20.SelectionStart = 0;
                txt_nbB20.SelectionLength = txt_nbB20.Text.Length;
            }
        }

        private void txt_nbB10_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB10.Text))
            {
                txt_nbB10.SelectionStart = 0;
                txt_nbB10.SelectionLength = txt_nbB10.Text.Length;
            }
        }

        private void txt_nbB5_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbB5.Text))
            {
                txt_nbB5.SelectionStart = 0;
                txt_nbB5.SelectionLength = txt_nbB5.Text.Length;
            }
        }

        private void txt_nbP2_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP2.Text))
            {
                txt_nbP2.SelectionStart = 0;
                txt_nbP2.SelectionLength = txt_nbP2.Text.Length;
            }
        }

        private void txt_nbP1_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP1.Text))
            {
                txt_nbP1.SelectionStart = 0;
                txt_nbP1.SelectionLength = txt_nbP1.Text.Length;
            }
        }

        private void txt_nbP020_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP020.Text))
            {
                txt_nbP020.SelectionStart = 0;
                txt_nbP020.SelectionLength = txt_nbP020.Text.Length;
            }
        }

        private void txt_nbP010_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP010.Text))
            {
                txt_nbP010.SelectionStart = 0;
                txt_nbP010.SelectionLength = txt_nbP010.Text.Length;
            }
        }

        private void txt_nbP005_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP005.Text))
            {
                txt_nbP005.SelectionStart = 0;
                txt_nbP005.SelectionLength = txt_nbP005.Text.Length;
            }
        }

        private void txt_nbP002_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP002.Text))
            {
                txt_nbP002.SelectionStart = 0;
                txt_nbP002.SelectionLength = txt_nbP002.Text.Length;
            }
        }

        private void txt_nbP001_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP001.Text))
            {
                txt_nbP001.SelectionStart = 0;
                txt_nbP001.SelectionLength = txt_nbP001.Text.Length;
            }
        }

        private void txt_nbR2_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR2.Text))
            {
                txt_nbR2.SelectionStart = 0;
                txt_nbR2.SelectionLength = txt_nbR2.Text.Length;
            }
        }

        private void txt_nbR1_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR1.Text))
            {
                txt_nbR1.SelectionStart = 0;
                txt_nbR1.SelectionLength = txt_nbR1.Text.Length;
            }
        }

        private void txt_nbR050_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR050.Text))
            {
                txt_nbR050.SelectionStart = 0;
                txt_nbR050.SelectionLength = txt_nbR050.Text.Length;
            }
        }

        private void txt_nbR020_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR020.Text))
            {
                txt_nbR020.SelectionStart = 0;
                txt_nbR020.SelectionLength = txt_nbR020.Text.Length;
            }
        }

        private void txt_nbR010_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR010.Text))
            {
                txt_nbR010.SelectionStart = 0;
                txt_nbR010.SelectionLength = txt_nbR010.Text.Length;
            }
        }

        private void txt_nbR005_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR005.Text))
            {
                txt_nbR005.SelectionStart = 0;
                txt_nbR005.SelectionLength = txt_nbR005.Text.Length;
            }
        }

        private void txt_nbR002_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR002.Text))
            {
                txt_nbR002.SelectionStart = 0;
                txt_nbR002.SelectionLength = txt_nbR002.Text.Length;
            }
        }

        private void txt_nbR001_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbR001.Text))
            {
                txt_nbR001.SelectionStart = 0;
                txt_nbR001.SelectionLength = txt_nbR001.Text.Length;
            }
        }

        private void txt_montantDepot_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_nbP050_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_nbP050.Text))
            {
                txt_nbP050.SelectionStart = 0;
                txt_nbP050.SelectionLength = txt_nbP050.Text.Length;
            }
        }

        String PDF_Directory = "archives\\"+ DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM")+"\\";
        String PDF_FileName = DateTime.Now.ToString("yyyyMMdd")+".pdf";

        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPDF();
            PDFViewer pdf = new PDFViewer();
            pdf.ShowDialog();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toutEffacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Etes-vous certain de vouloir effacer enitèrement la feuille de calcul ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // réinitialise tous les champs
                Reinitialiser();
                ExecuteCalculs();
            }
        }

        private void AfficheVersionAppli()
        {

        }
        private void Calcul_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_totCoffre_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreDecimalOnly(e);
        }

        private void txt_totCoffre_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_totEspeces_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreDecimalOnly(e);
        }

        private void txt_totEspeces_KeyUp(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void txt_totEspeces_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_totEspeces.Text))
            {
                txt_totEspeces.SelectionStart = 0;
                txt_totEspeces.SelectionLength = txt_totEspeces.Text.Length;
            }
        }

        private void txt_totCoffre_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_totCoffre.Text))
            {
                txt_totCoffre.SelectionStart = 0;
                txt_totCoffre.SelectionLength = txt_totCoffre.Text.Length;
            }
        }

        private void txt_montantDepot_Enter(object sender, EventArgs e)
        {
            // sélection le contenu du champ à l'entrée
            if (!String.IsNullOrEmpty(txt_montantDepot.Text))
            {
                txt_montantDepot.SelectionStart = 0;
                txt_montantDepot.SelectionLength = txt_montantDepot.Text.Length;
            }
        }

        private void txt_montantDepot_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffreDecimalOnly(e);
        }

        private void txt_montantDepot_KeyUp_1(object sender, KeyEventArgs e)
        {
            ExecuteCalculs();
        }

        private void archivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void printPDF()
        {
            Document doc = new Document(PageSize.A4, 5, 5, 5, 5);
            try
            {

                Directory.CreateDirectory(PDF_Directory);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDF_Directory + PDF_FileName, FileMode.Create));
                writer.ViewerPreferences = PdfWriter.FitWindow;

                // entête du fichier
                doc.AddTitle("Caisse du " + DateTime.Now.ToString("dd/MM/yyyy"));
                doc.AddAuthor("Hifi International");
                doc.Open();

                // pied de page


                // titre de la page
                Paragraph titre = new Paragraph("Caisse du " + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD));
                titre.Alignment = Element.ALIGN_CENTER;
                doc.Add(titre);

                // ligne vide
                doc.Add(new Phrase("\n"));


                PdfPTable table = new PdfPTable(11);

                // largeur du tableau
                table.TotalWidth = 560f;
                table.LockedWidth = true;

                float[] widths = new float[] { 1f, 0.6f, 1f, 0.4f, 1f, 0.6f, 1f, 0.4f, 1f, 0.6f, 1f };
                table.SetWidths(widths);

                // modèle de cellule vide
                PdfPCell emptyCell = new PdfPCell();
                emptyCell.Border = 0;
                emptyCell.MinimumHeight = 10;

                // entêtes des tableaux
                PdfPCell hBT = new PdfPCell(new Phrase("BILLETS", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hBT.HorizontalAlignment = 1;
                hBT.MinimumHeight = 22;
                PdfPCell hBQ = new PdfPCell(new Phrase("QTE", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hBQ.HorizontalAlignment = 1;
                PdfPCell hBM = new PdfPCell(new Phrase("MONTANT", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hBM.HorizontalAlignment = 1;
                PdfPCell hPT = new PdfPCell(new Phrase("PIECES", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hPT.HorizontalAlignment = 1;
                PdfPCell hPQ = new PdfPCell(new Phrase("QTE", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hPQ.HorizontalAlignment = 1;
                PdfPCell hPM = new PdfPCell(new Phrase("MONTANT", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hPM.HorizontalAlignment = 1;
                PdfPCell hRT = new PdfPCell(new Phrase("ROULEAUX", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hRT.HorizontalAlignment = 1;
                PdfPCell hRQ = new PdfPCell(new Phrase("QTE", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hRQ.HorizontalAlignment = 1;
                PdfPCell hRM = new PdfPCell(new Phrase("MONTANT", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hRM.HorizontalAlignment = 1;


                // BILLETS
                PdfPCell lB500 = new PdfPCell(new Phrase("500 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB200 = new PdfPCell(new Phrase("200 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB100 = new PdfPCell(new Phrase("100 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB50 = new PdfPCell(new Phrase("50 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB20 = new PdfPCell(new Phrase("20 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB10 = new PdfPCell(new Phrase("10 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lB5 = new PdfPCell(new Phrase("5 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell nbB500 = new PdfPCell(new Phrase(txt_nbB500.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB200 = new PdfPCell(new Phrase(txt_nbB200.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB100 = new PdfPCell(new Phrase(txt_nbB100.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB50 = new PdfPCell(new Phrase(txt_nbB50.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB20 = new PdfPCell(new Phrase(txt_nbB20.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB10 = new PdfPCell(new Phrase(txt_nbB10.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbB5 = new PdfPCell(new Phrase(txt_nbB5.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell totB500 = new PdfPCell(new Phrase(txt_totB500.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB200 = new PdfPCell(new Phrase(txt_totB200.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB100 = new PdfPCell(new Phrase(txt_totB100.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB50 = new PdfPCell(new Phrase(txt_totB50.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB20 = new PdfPCell(new Phrase(txt_totB20.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB10 = new PdfPCell(new Phrase(txt_totB10.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totB5 = new PdfPCell(new Phrase(txt_totB5.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell t_totBillets = new PdfPCell(new Phrase("SOUS-TOTAL :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell totBillets = new PdfPCell(new Phrase(txt_totBillets.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                t_totBillets.Border = 0;

                // PIECES
                PdfPCell lP2 = new PdfPCell(new Phrase("2 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP1 = new PdfPCell(new Phrase("1 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP050 = new PdfPCell(new Phrase("50 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP020 = new PdfPCell(new Phrase("20 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP010 = new PdfPCell(new Phrase("10 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP005 = new PdfPCell(new Phrase("5 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP002 = new PdfPCell(new Phrase("2 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lP001 = new PdfPCell(new Phrase("1 ct", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell nbP2 = new PdfPCell(new Phrase(txt_nbP2.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP1 = new PdfPCell(new Phrase(txt_nbP1.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP050 = new PdfPCell(new Phrase(txt_nbP050.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP020 = new PdfPCell(new Phrase(txt_nbP020.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP010 = new PdfPCell(new Phrase(txt_nbP010.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP005 = new PdfPCell(new Phrase(txt_nbP005.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP002 = new PdfPCell(new Phrase(txt_nbP002.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbP001 = new PdfPCell(new Phrase(txt_nbP001.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell totP2 = new PdfPCell(new Phrase(txt_totP2.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP1 = new PdfPCell(new Phrase(txt_totP1.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP050 = new PdfPCell(new Phrase(txt_totP050.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP020 = new PdfPCell(new Phrase(txt_totP020.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP010 = new PdfPCell(new Phrase(txt_totP010.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP005 = new PdfPCell(new Phrase(txt_totP005.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP002 = new PdfPCell(new Phrase(txt_totP002.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totP001 = new PdfPCell(new Phrase(txt_totP001.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell t_totPieces = new PdfPCell(new Phrase("SOUS-TOTAL :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                t_totPieces.Border = 0;
                PdfPCell totPieces = new PdfPCell(new Phrase(txt_totPieces.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                // ROULEAUX
                PdfPCell lR2 = new PdfPCell(new Phrase("2 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR1 = new PdfPCell(new Phrase("1 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR050 = new PdfPCell(new Phrase("50 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR020 = new PdfPCell(new Phrase("20 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR010 = new PdfPCell(new Phrase("10 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR005 = new PdfPCell(new Phrase("5 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR002 = new PdfPCell(new Phrase("2 cts", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell lR001 = new PdfPCell(new Phrase("1 ct", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell nbR2 = new PdfPCell(new Phrase(txt_nbR2.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR1 = new PdfPCell(new Phrase(txt_nbR1.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR050 = new PdfPCell(new Phrase(txt_nbR050.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR020 = new PdfPCell(new Phrase(txt_nbR020.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR010 = new PdfPCell(new Phrase(txt_nbR010.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR005 = new PdfPCell(new Phrase(txt_nbR005.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR002 = new PdfPCell(new Phrase(txt_nbR002.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell nbR001 = new PdfPCell(new Phrase(txt_nbR001.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell totR2 = new PdfPCell(new Phrase(txt_totR2.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR1 = new PdfPCell(new Phrase(txt_totR1.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR050 = new PdfPCell(new Phrase(txt_totR050.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR020 = new PdfPCell(new Phrase(txt_totR020.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR010 = new PdfPCell(new Phrase(txt_totR010.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR005 = new PdfPCell(new Phrase(txt_totR005.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR002 = new PdfPCell(new Phrase(txt_totR002.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));
                PdfPCell totR001 = new PdfPCell(new Phrase(txt_totR001.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.NORMAL)));

                PdfPCell t_totRouleaux = new PdfPCell(new Phrase("SOUS-TOTAL :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                t_totRouleaux.Border = 0;
                PdfPCell totRouleaux = new PdfPCell(new Phrase(txt_totRouleaux.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                // couleurs de fond
                hBT.BackgroundColor = BaseColor.BLACK;
                hBQ.BackgroundColor = BaseColor.BLACK;
                hBM.BackgroundColor = BaseColor.BLACK;
                hPT.BackgroundColor = BaseColor.BLACK;
                hPQ.BackgroundColor = BaseColor.BLACK;
                hPM.BackgroundColor = BaseColor.BLACK;
                hRT.BackgroundColor = BaseColor.BLACK;
                hRQ.BackgroundColor = BaseColor.BLACK;
                hRM.BackgroundColor = BaseColor.BLACK;

                // Hauteurs de cellules
                lP2.MinimumHeight = 20;
                lP1.MinimumHeight = 20;
                lP050.MinimumHeight = 20;
                lP020.MinimumHeight = 20;
                lP010.MinimumHeight = 20;
                lP005.MinimumHeight = 20;
                lP002.MinimumHeight = 20;
                lP001.MinimumHeight = 20;
                totPieces.MinimumHeight = 20;

                // Alignements
                lB500.HorizontalAlignment = 2;
                lB200.HorizontalAlignment = 2;
                lB100.HorizontalAlignment = 2;
                lB50.HorizontalAlignment = 2;
                lB20.HorizontalAlignment = 2;
                lB10.HorizontalAlignment = 2;
                lB5.HorizontalAlignment = 2;

                nbB500.HorizontalAlignment = 1;
                nbB200.HorizontalAlignment = 1;
                nbB100.HorizontalAlignment = 1;
                nbB50.HorizontalAlignment = 1;
                nbB20.HorizontalAlignment = 1;
                nbB10.HorizontalAlignment = 1;
                nbB5.HorizontalAlignment = 1;

                totB500.HorizontalAlignment = 2;
                totB200.HorizontalAlignment = 2;
                totB100.HorizontalAlignment = 2;
                totB50.HorizontalAlignment = 2;
                totB20.HorizontalAlignment = 2;
                totB10.HorizontalAlignment = 2;
                totB5.HorizontalAlignment = 2;

                lP2.HorizontalAlignment = 2;
                lP1.HorizontalAlignment = 2;
                lP050.HorizontalAlignment = 2;
                lP020.HorizontalAlignment = 2;
                lP010.HorizontalAlignment = 2;
                lP005.HorizontalAlignment = 2;
                lP002.HorizontalAlignment = 2;
                lP001.HorizontalAlignment = 2;

                nbP2.HorizontalAlignment = 1;
                nbP1.HorizontalAlignment = 1;
                nbP050.HorizontalAlignment = 1;
                nbP020.HorizontalAlignment = 1;
                nbP010.HorizontalAlignment = 1;
                nbP005.HorizontalAlignment = 1;
                nbP002.HorizontalAlignment = 1;
                nbP001.HorizontalAlignment = 1;

                totP2.HorizontalAlignment = 2;
                totP1.HorizontalAlignment = 2;
                totP050.HorizontalAlignment = 2;
                totP020.HorizontalAlignment = 2;
                totP010.HorizontalAlignment = 2;
                totP005.HorizontalAlignment = 2;
                totP002.HorizontalAlignment = 2;
                totP001.HorizontalAlignment = 2;

                lR2.HorizontalAlignment = 2;
                lR1.HorizontalAlignment = 2;
                lR050.HorizontalAlignment = 2;
                lR020.HorizontalAlignment = 2;
                lR010.HorizontalAlignment = 2;
                lR005.HorizontalAlignment = 2;
                lR002.HorizontalAlignment = 2;
                lR001.HorizontalAlignment = 2;

                nbR2.HorizontalAlignment = 1;
                nbR1.HorizontalAlignment = 1;
                nbR050.HorizontalAlignment = 1;
                nbR020.HorizontalAlignment = 1;
                nbR010.HorizontalAlignment = 1;
                nbR005.HorizontalAlignment = 1;
                nbR002.HorizontalAlignment = 1;
                nbR001.HorizontalAlignment = 1;

                totR2.HorizontalAlignment = 2;
                totR1.HorizontalAlignment = 2;
                totR050.HorizontalAlignment = 2;
                totR020.HorizontalAlignment = 2;
                totR010.HorizontalAlignment = 2;
                totR005.HorizontalAlignment = 2;
                totR002.HorizontalAlignment = 2;
                totR001.HorizontalAlignment = 2;

                // sous-totaux
                t_totBillets.HorizontalAlignment = 2;
                totBillets.HorizontalAlignment = 2;
                t_totBillets.Colspan = 2;

                t_totPieces.HorizontalAlignment = 2;
                totPieces.HorizontalAlignment = 2;
                t_totPieces.Colspan = 2;

                t_totRouleaux.HorizontalAlignment = 2;
                totRouleaux.HorizontalAlignment = 2;
                t_totRouleaux.Colspan = 2;

                // construction du tableau
                table.AddCell(hBT);
                table.AddCell(hBQ);
                table.AddCell(hBM);
                table.AddCell(emptyCell);
                table.AddCell(hPT);
                table.AddCell(hPQ);
                table.AddCell(hPM);
                table.AddCell(emptyCell);
                table.AddCell(hRT);
                table.AddCell(hRQ);
                table.AddCell(hRM);

                table.AddCell(lB500);
                table.AddCell(nbB500);
                table.AddCell(totB500);
                table.AddCell(emptyCell);
                table.AddCell(lP2);
                table.AddCell(nbP2);
                table.AddCell(totP2);
                table.AddCell(emptyCell);
                table.AddCell(lR2);
                table.AddCell(nbR2);
                table.AddCell(totR2);

                table.AddCell(lB200);
                table.AddCell(nbB200);
                table.AddCell(totB200);
                table.AddCell(emptyCell);
                table.AddCell(lP1);
                table.AddCell(nbP1);
                table.AddCell(totP1);
                table.AddCell(emptyCell);
                table.AddCell(lR1);
                table.AddCell(nbR1);
                table.AddCell(totR1);

                table.AddCell(lB100);
                table.AddCell(nbB100);
                table.AddCell(totB100);
                table.AddCell(emptyCell);
                table.AddCell(lP050);
                table.AddCell(nbP050);
                table.AddCell(totP050);
                table.AddCell(emptyCell);
                table.AddCell(lR050);
                table.AddCell(nbR050);
                table.AddCell(totR050);

                table.AddCell(lB50);
                table.AddCell(nbB50);
                table.AddCell(totB50);
                table.AddCell(emptyCell);
                table.AddCell(lP020);
                table.AddCell(nbP020);
                table.AddCell(totP020);
                table.AddCell(emptyCell);
                table.AddCell(lR020);
                table.AddCell(nbR020);
                table.AddCell(totR020);

                table.AddCell(lB20);
                table.AddCell(nbB20);
                table.AddCell(totB20);
                table.AddCell(emptyCell);
                table.AddCell(lP010);
                table.AddCell(nbP010);
                table.AddCell(totP010);
                table.AddCell(emptyCell);
                table.AddCell(lR010);
                table.AddCell(nbR010);
                table.AddCell(totR010);

                table.AddCell(lB10);
                table.AddCell(nbB10);
                table.AddCell(totB10);
                table.AddCell(emptyCell);
                table.AddCell(lP005);
                table.AddCell(nbP005);
                table.AddCell(totP005);
                table.AddCell(emptyCell);
                table.AddCell(lR005);
                table.AddCell(nbR005);
                table.AddCell(totR005);

                table.AddCell(lB5);
                table.AddCell(nbB5);
                table.AddCell(totB5);
                table.AddCell(emptyCell);
                table.AddCell(lP002);
                table.AddCell(nbP002);
                table.AddCell(totP002);
                table.AddCell(emptyCell);
                table.AddCell(lR002);
                table.AddCell(nbR002);
                table.AddCell(totR002);


                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(lP001);
                table.AddCell(nbP001);
                table.AddCell(totP001);
                table.AddCell(emptyCell);
                table.AddCell(lR001);
                table.AddCell(nbR001);
                table.AddCell(totR001);

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(t_totBillets);
                table.AddCell(totBillets);
                table.AddCell(emptyCell);
                table.AddCell(t_totPieces);
                table.AddCell(totPieces);
                table.AddCell(emptyCell);
                table.AddCell(t_totRouleaux);
                table.AddCell(totRouleaux);

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);
                table.AddCell(emptyCell);

                doc.Add(table);

                // tableau secondaire
                PdfPTable table2 = new PdfPTable(4);

                // largeur du tableau
                table2.TotalWidth = 560f;
                table2.LockedWidth = true;

                float[] widths2 = new float[] { 1.1f, 1.1f, 0.6f, 1.5f };
                table2.SetWidths(widths2);

                PdfPCell t_montantCoffre = new PdfPCell(new Phrase("Montant coffre :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell montantCoffre = new PdfPCell(new Phrase(txt_totCoffre.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell t_totalEspeces = new PdfPCell(new Phrase("Total espèces :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell totalEspeces = new PdfPCell(new Phrase(txt_totEspeces.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell t_montantDepot = new PdfPCell(new Phrase("Montant à déposer :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell montantDepot = new PdfPCell(new Phrase(txt_montantDepot.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell t_totalCaisse = new PdfPCell(new Phrase("Total en caisse :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell totalCaisse = new PdfPCell(new Phrase(txt_totCaisse.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell t_diffCaisse = new PdfPCell(new Phrase("Différence :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell diffCaisse = new PdfPCell(new Phrase(txt_diffCaisse.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.RED)));

                // bordures
                t_montantCoffre.Border = 0;
                t_totalEspeces.Border = 0;
                t_montantDepot.Border = 0;
                t_totalCaisse.Border = 0;
                t_diffCaisse.Border = 0;

                // Hauteurs de cellules
                t_montantCoffre.MinimumHeight = 20;
                t_totalEspeces.MinimumHeight = 20;
                t_montantDepot.MinimumHeight = 20;
                t_totalCaisse.MinimumHeight = 20;
                t_diffCaisse.MinimumHeight = 20;

                // Alignements
                t_montantCoffre.HorizontalAlignment = 2;
                t_totalCaisse.HorizontalAlignment = 2;
                t_totalEspeces.HorizontalAlignment = 2;
                t_montantDepot.HorizontalAlignment = 2;
                t_diffCaisse.HorizontalAlignment = 2;
                montantCoffre.HorizontalAlignment = 2;
                totalCaisse.HorizontalAlignment = 2;
                totalEspeces.HorizontalAlignment = 2;
                montantDepot.HorizontalAlignment = 2;
                diffCaisse.HorizontalAlignment = 2;

                table2.AddCell(emptyCell);
                table2.AddCell(t_montantCoffre);
                table2.AddCell(montantCoffre);
                table2.AddCell(emptyCell);

                table2.AddCell(emptyCell);
                table2.AddCell(t_totalEspeces);
                table2.AddCell(totalEspeces);
                table2.AddCell(emptyCell);

                table2.AddCell(emptyCell);
                table2.AddCell(t_montantDepot);
                table2.AddCell(montantDepot);
                table2.AddCell(emptyCell);

                table2.AddCell(emptyCell);
                table2.AddCell(t_totalCaisse);
                table2.AddCell(totalCaisse);
                table2.AddCell(emptyCell);

                table2.AddCell(emptyCell);
                table2.AddCell(t_diffCaisse);
                table2.AddCell(diffCaisse);
                table2.AddCell(emptyCell);

                doc.Add(table2);

                // tableau du dépot banque
                PdfPTable table3 = new PdfPTable(5);

                // largeur du tableau
                table3.TotalWidth = 360f;
                table3.LockedWidth = true;

                float[] widths3 = new float[] { 1.0f, 1.4f, 1.4f, 1.4f, 1.0f };
                table3.SetWidths(widths3);

                PdfPCell t_titreDepot = new PdfPCell(new Phrase("DEPOT EN BANQUE", FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD)));
                t_titreDepot.Colspan = 3;
                t_titreDepot.Border = 0;
                t_titreDepot.HorizontalAlignment = 1;
                PdfPCell hDBT = new PdfPCell(new Phrase("BILLETS", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hDBT.HorizontalAlignment = 1;
                hDBT.MinimumHeight = 22;
                PdfPCell hDBQ = new PdfPCell(new Phrase("QTE", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hDBQ.HorizontalAlignment = 1;
                PdfPCell hDBM = new PdfPCell(new Phrase("MONTANT", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                hDBM.HorizontalAlignment = 1;

                PdfPCell DlB500 = new PdfPCell(new Phrase("500 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB200 = new PdfPCell(new Phrase("200 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB100 = new PdfPCell(new Phrase("100 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB50 = new PdfPCell(new Phrase("50 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB20 = new PdfPCell(new Phrase("20 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB10 = new PdfPCell(new Phrase("10 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DlB5 = new PdfPCell(new Phrase("5 €", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell DnbB500 = new PdfPCell(new Phrase(txt_nbDepotB500.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB200 = new PdfPCell(new Phrase(txt_nbDepotB200.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB100 = new PdfPCell(new Phrase(txt_nbDepotB100.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB50 = new PdfPCell(new Phrase(txt_nbDepotB50.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB20 = new PdfPCell(new Phrase(txt_nbDepotB20.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB10 = new PdfPCell(new Phrase(txt_nbDepotB10.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DnbB5 = new PdfPCell(new Phrase(txt_nbDepotB5.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell DtotB500 = new PdfPCell(new Phrase(txt_totDepotB500.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB200 = new PdfPCell(new Phrase(txt_totDepotB200.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB100 = new PdfPCell(new Phrase(txt_totDepotB100.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB50 = new PdfPCell(new Phrase(txt_totDepotB50.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB20 = new PdfPCell(new Phrase(txt_totDepotB20.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB10 = new PdfPCell(new Phrase(txt_totDepotB10.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                PdfPCell DtotB5 = new PdfPCell(new Phrase(txt_totDepotB5.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                PdfPCell t_totDepotBanque = new PdfPCell(new Phrase("TOTAL DEPOT BANQUE :", FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));
                t_totDepotBanque.Border = 0;
                t_totDepotBanque.Colspan = 2;
                PdfPCell totDepotBanque = new PdfPCell(new Phrase(txt_totDepotBanque.Text, FontFactory.GetFont("Courier", 12, iTextSharp.text.Font.BOLD)));

                // couleurs de fond
                hDBT.BackgroundColor = BaseColor.BLACK;
                hDBQ.BackgroundColor = BaseColor.BLACK;
                hDBM.BackgroundColor = BaseColor.BLACK;

                // alignements
                DlB500.HorizontalAlignment = 2;
                DlB200.HorizontalAlignment = 2;
                DlB100.HorizontalAlignment = 2;
                DlB50.HorizontalAlignment = 2;
                DlB20.HorizontalAlignment = 2;
                DlB10.HorizontalAlignment = 2;
                DlB5.HorizontalAlignment = 2;

                DnbB500.HorizontalAlignment = 1;
                DnbB200.HorizontalAlignment = 1;
                DnbB100.HorizontalAlignment = 1;
                DnbB50.HorizontalAlignment = 1;
                DnbB20.HorizontalAlignment = 1;
                DnbB10.HorizontalAlignment = 1;
                DnbB5.HorizontalAlignment = 1;

                DtotB500.HorizontalAlignment = 2;
                DtotB200.HorizontalAlignment = 2;
                DtotB100.HorizontalAlignment = 2;
                DtotB50.HorizontalAlignment = 2;
                DtotB20.HorizontalAlignment = 2;
                DtotB10.HorizontalAlignment = 2;
                DtotB5.HorizontalAlignment = 2;

                t_totDepotBanque.HorizontalAlignment = 2;
                totDepotBanque.HorizontalAlignment = 2;

                // hauteurs de cellules
                DlB500.MinimumHeight = 20;
                DlB200.MinimumHeight = 20;
                DlB100.MinimumHeight = 20;
                DlB50.MinimumHeight = 20;
                DlB20.MinimumHeight = 20;
                DlB10.MinimumHeight = 20;
                DlB5.MinimumHeight = 20;
                t_totDepotBanque.MinimumHeight = 20;
                totDepotBanque.MinimumHeight = 20;


                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(t_titreDepot); // Titre du tableau
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(hDBT);
                table3.AddCell(hDBQ);
                table3.AddCell(hDBM);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB500);
                table3.AddCell(DnbB500);
                table3.AddCell(DtotB500);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB200);
                table3.AddCell(DnbB200);
                table3.AddCell(DtotB200);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB100);
                table3.AddCell(DnbB100);
                table3.AddCell(DtotB100);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB50);
                table3.AddCell(DnbB50);
                table3.AddCell(DtotB50);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB20);
                table3.AddCell(DnbB20);
                table3.AddCell(DtotB20);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB10);
                table3.AddCell(DnbB10);
                table3.AddCell(DtotB10);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(DlB5);
                table3.AddCell(DnbB5);
                table3.AddCell(DtotB5);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);
                table3.AddCell(emptyCell);

                table3.AddCell(emptyCell);
                table3.AddCell(t_totDepotBanque);
                table3.AddCell(totDepotBanque);
                table3.AddCell(emptyCell);

                doc.Add(table3);

                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                doc.Add(new Phrase("\n"));
                Paragraph printDateTime = new Paragraph("Imprimé le " + DateTime.Now.ToString("dd/MM/yyyy") + " à " + DateTime.Now.ToString("HH:mm:ss") + "    ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.ITALIC));
                printDateTime.Alignment = Element.ALIGN_RIGHT;
                doc.Add(printDateTime);


                // ouverture du fichier PDF
                //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@PDF_Directory + PDF_FileName, "");
                //System.Diagnostics.Process.Start(@PDF_Directory + PDF_FileName);
                
                //PDFViewer frm = new PDFViewer();
                //frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }

        private void btn_testPOO_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            printPDF();
            PDFViewer pdf = new PDFViewer();
            pdf.ShowDialog();
        }

        private void grp_billets_Enter(object sender, EventArgs e)
        {

        }

        private void menuCalcul_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void miseÀJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
