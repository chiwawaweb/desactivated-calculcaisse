using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculCaisse
{
    public partial class PDFViewer : Form
    {
        public PDFViewer()
        {
            InitializeComponent();
        }

        private void PDFViewer_Load(object sender, EventArgs e)
        {
            // détermine le dossier et nom de fichier
            /* En attendant le passage de paramètres */
            String PDF_Directory = "archives\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\";
            String PDF_FileName = DateTime.Now.ToString("yyyyMMdd") + ".pdf";

            axAcroPDF1.LoadFile(PDF_Directory+PDF_FileName);
            axAcroPDF1.printWithDialog();

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            axAcroPDF1.printWithDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
