namespace CalculCaisse
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.menuMainFrm = new System.Windows.Forms.MenuStrip();
            this.miseÀJourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.préférencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misesÀJourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.update = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMainFrm.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMainFrm
            // 
            this.menuMainFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miseÀJourToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuMainFrm.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuMainFrm.Location = new System.Drawing.Point(0, 0);
            this.menuMainFrm.Name = "menuMainFrm";
            this.menuMainFrm.Size = new System.Drawing.Size(998, 24);
            this.menuMainFrm.TabIndex = 1;
            this.menuMainFrm.Text = "Menu";
            // 
            // miseÀJourToolStripMenuItem
            // 
            this.miseÀJourToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivesToolStripMenuItem,
            this.préférencesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitterToolStripMenuItem});
            this.miseÀJourToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.miseÀJourToolStripMenuItem.MergeIndex = 1;
            this.miseÀJourToolStripMenuItem.Name = "miseÀJourToolStripMenuItem";
            this.miseÀJourToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.miseÀJourToolStripMenuItem.Text = "Fichier";
            // 
            // archivesToolStripMenuItem
            // 
            this.archivesToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.archivesToolStripMenuItem.MergeIndex = 1;
            this.archivesToolStripMenuItem.Name = "archivesToolStripMenuItem";
            this.archivesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.archivesToolStripMenuItem.Text = "Archives";
            this.archivesToolStripMenuItem.Click += new System.EventHandler(this.archivesToolStripMenuItem_Click);
            // 
            // préférencesToolStripMenuItem
            // 
            this.préférencesToolStripMenuItem.Enabled = false;
            this.préférencesToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.préférencesToolStripMenuItem.MergeIndex = 4;
            this.préférencesToolStripMenuItem.Name = "préférencesToolStripMenuItem";
            this.préférencesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.préférencesToolStripMenuItem.Text = "Préférences...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem2.MergeIndex = 5;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.quitterToolStripMenuItem.MergeIndex = 100;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.misesÀJourToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolStripMenuItem1.MergeIndex = 10;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Enabled = false;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aideToolStripMenuItem.Text = "Aide ?";
            // 
            // misesÀJourToolStripMenuItem
            // 
            this.misesÀJourToolStripMenuItem.Name = "misesÀJourToolStripMenuItem";
            this.misesÀJourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.misesÀJourToolStripMenuItem.Text = "Mises à jour...";
            this.misesÀJourToolStripMenuItem.Click += new System.EventHandler(this.misesÀJourToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aProposToolStripMenuItem.Text = "A propos...";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTime,
            this.update});
            this.statusStrip.Location = new System.Drawing.Point(0, 586);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(998, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // dateTime
            // 
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(0, 17);
            // 
            // update
            // 
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(0, 17);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 608);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuMainFrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMainFrm;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calcul caisse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.menuMainFrm.ResumeLayout(false);
            this.menuMainFrm.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainFrm;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem miseÀJourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem préférencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misesÀJourToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel dateTime;
        private System.Windows.Forms.ToolStripStatusLabel update;
    }
}

