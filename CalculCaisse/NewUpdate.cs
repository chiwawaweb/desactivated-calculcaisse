using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CalculCaisse
{
    public partial class NewUpdate : Form
    {

        static String updatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\updates\";

        public NewUpdate()
        {
            InitializeComponent();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {

            // URL du nouveau fichier
            string updateURL = "http://calculcaisse.chiwawaweb.com/lastupdate";

            Directory.CreateDirectory(updatePath);

            lbl_majdispo.Visible = false;
            lbl_majdownload.Visible = false;
            btn_yes.Visible = false;
            btn_no.Visible = false;
            progressBar.Visible = true;
            lbl_majencours.Visible = true;

            download(updateURL, updatePath+"calculcaisse_update.exe");
        }

        public void download(string URL, string path)
        {
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += (s, e) =>
            {
                progressBar.Value = e.ProgressPercentage;
            };
            wc.DownloadFileCompleted += (s, e) =>
            {
                progressBar.Visible = false;
                // any other code to process the file
                btn_next.Visible = true;
                lbl_majencours.Text = "Le téléchargement de la mise à jour est terminé...";
            };
            wc.DownloadFileAsync(new Uri(URL), path);
            
        }

        private void NewUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            // ferme la boîte de dialogue
            this.Close();

            Process p = new Process();
            p.StartInfo.FileName = updatePath + "calculcaisse_update.exe";
            p.Start();

            Application.Exit();

        }
    }
}
