namespace FormAdoNet
{
    partial class GestionDisque
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionDisque));
            this.LB_Dept = new System.Windows.Forms.ListBox();
            this.BTN_First = new System.Windows.Forms.Button();
            this.BTN_Mod = new System.Windows.Forms.Button();
            this.BTN_Supprimer = new System.Windows.Forms.Button();
            this.TB_NoEMP = new System.Windows.Forms.TextBox();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_Prenom = new System.Windows.Forms.TextBox();
            this.TB_Salaire = new System.Windows.Forms.TextBox();
            this.LBL_NumEMP = new System.Windows.Forms.Label();
            this.LBL_Nom = new System.Windows.Forms.Label();
            this.LBL_Prenom = new System.Windows.Forms.Label();
            this.LBL_Salaire = new System.Windows.Forms.Label();
            this.BTN_Quitter = new System.Windows.Forms.Button();
            this.BTN_Prec = new System.Windows.Forms.Button();
            this.BTN_Suivant = new System.Windows.Forms.Button();
            this.BTN_Fin = new System.Windows.Forms.Button();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.LB_Date = new System.Windows.Forms.Label();
            this.DTP_Embauche = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // LB_Dept
            // 
            this.LB_Dept.FormattingEnabled = true;
            this.LB_Dept.Location = new System.Drawing.Point(12, 12);
            this.LB_Dept.Name = "LB_Dept";
            this.LB_Dept.Size = new System.Drawing.Size(121, 121);
            this.LB_Dept.TabIndex = 15;
            this.LB_Dept.SelectedIndexChanged += new System.EventHandler(this.ListeCompagnie_SelectedIndexChanged);
            // 
            // BTN_First
            // 
            this.BTN_First.Location = new System.Drawing.Point(167, 145);
            this.BTN_First.Name = "BTN_First";
            this.BTN_First.Size = new System.Drawing.Size(53, 23);
            this.BTN_First.TabIndex = 9;
            this.BTN_First.Text = "Debut";
            this.BTN_First.UseVisualStyleBackColor = true;
            this.BTN_First.Click += new System.EventHandler(this.premier_Click);
            // 
            // BTN_Mod
            // 
            this.BTN_Mod.Location = new System.Drawing.Point(364, 102);
            this.BTN_Mod.Name = "BTN_Mod";
            this.BTN_Mod.Size = new System.Drawing.Size(75, 23);
            this.BTN_Mod.TabIndex = 11;
            this.BTN_Mod.Text = "Modifier";
            this.BTN_Mod.UseVisualStyleBackColor = true;
            this.BTN_Mod.Click += new System.EventHandler(this.BTN_Mod_Click);
            // 
            // BTN_Supprimer
            // 
            this.BTN_Supprimer.Location = new System.Drawing.Point(364, 74);
            this.BTN_Supprimer.Name = "BTN_Supprimer";
            this.BTN_Supprimer.Size = new System.Drawing.Size(75, 23);
            this.BTN_Supprimer.TabIndex = 10;
            this.BTN_Supprimer.Text = "Suprimer";
            this.BTN_Supprimer.UseVisualStyleBackColor = true;
            this.BTN_Supprimer.Click += new System.EventHandler(this.BTN_Supprimer_Click);
            // 
            // TB_NoEMP
            // 
            this.TB_NoEMP.Location = new System.Drawing.Point(241, 17);
            this.TB_NoEMP.Name = "TB_NoEMP";
            this.TB_NoEMP.Size = new System.Drawing.Size(100, 20);
            this.TB_NoEMP.TabIndex = 5;
            this.TB_NoEMP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Chiffre_KeyPress);
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(241, 43);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(100, 20);
            this.TB_Nom.TabIndex = 6;
            // 
            // TB_Prenom
            // 
            this.TB_Prenom.Location = new System.Drawing.Point(241, 69);
            this.TB_Prenom.Name = "TB_Prenom";
            this.TB_Prenom.Size = new System.Drawing.Size(100, 20);
            this.TB_Prenom.TabIndex = 7;
            this.TB_Prenom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Duree_KeyPress);
            // 
            // TB_Salaire
            // 
            this.TB_Salaire.Location = new System.Drawing.Point(241, 95);
            this.TB_Salaire.MaxLength = 4;
            this.TB_Salaire.Name = "TB_Salaire";
            this.TB_Salaire.Size = new System.Drawing.Size(100, 20);
            this.TB_Salaire.TabIndex = 8;
            this.TB_Salaire.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Chiffre_KeyPress);
            // 
            // LBL_NumEMP
            // 
            this.LBL_NumEMP.AutoSize = true;
            this.LBL_NumEMP.Location = new System.Drawing.Point(168, 20);
            this.LBL_NumEMP.Name = "LBL_NumEMP";
            this.LBL_NumEMP.Size = new System.Drawing.Size(67, 13);
            this.LBL_NumEMP.TabIndex = 17;
            this.LBL_NumEMP.Text = "No. Employe";
            // 
            // LBL_Nom
            // 
            this.LBL_Nom.AutoSize = true;
            this.LBL_Nom.Location = new System.Drawing.Point(207, 46);
            this.LBL_Nom.Name = "LBL_Nom";
            this.LBL_Nom.Size = new System.Drawing.Size(29, 13);
            this.LBL_Nom.TabIndex = 18;
            this.LBL_Nom.Text = "Nom";
            // 
            // LBL_Prenom
            // 
            this.LBL_Prenom.AutoSize = true;
            this.LBL_Prenom.Location = new System.Drawing.Point(193, 72);
            this.LBL_Prenom.Name = "LBL_Prenom";
            this.LBL_Prenom.Size = new System.Drawing.Size(43, 13);
            this.LBL_Prenom.TabIndex = 19;
            this.LBL_Prenom.Text = "Prenom";
            // 
            // LBL_Salaire
            // 
            this.LBL_Salaire.AutoSize = true;
            this.LBL_Salaire.Location = new System.Drawing.Point(197, 98);
            this.LBL_Salaire.Name = "LBL_Salaire";
            this.LBL_Salaire.Size = new System.Drawing.Size(39, 13);
            this.LBL_Salaire.TabIndex = 20;
            this.LBL_Salaire.Text = "Salaire";
            // 
            // BTN_Quitter
            // 
            this.BTN_Quitter.Location = new System.Drawing.Point(12, 145);
            this.BTN_Quitter.Name = "BTN_Quitter";
            this.BTN_Quitter.Size = new System.Drawing.Size(75, 23);
            this.BTN_Quitter.TabIndex = 11;
            this.BTN_Quitter.Text = "Quitter";
            this.BTN_Quitter.UseVisualStyleBackColor = true;
            this.BTN_Quitter.Click += new System.EventHandler(this.BTN_Quitter_Click);
            // 
            // BTN_Prec
            // 
            this.BTN_Prec.Location = new System.Drawing.Point(226, 145);
            this.BTN_Prec.Name = "BTN_Prec";
            this.BTN_Prec.Size = new System.Drawing.Size(62, 23);
            this.BTN_Prec.TabIndex = 22;
            this.BTN_Prec.Text = "Prec";
            this.BTN_Prec.UseVisualStyleBackColor = true;
            this.BTN_Prec.Click += new System.EventHandler(this.precedent_Click);
            // 
            // BTN_Suivant
            // 
            this.BTN_Suivant.Location = new System.Drawing.Point(294, 145);
            this.BTN_Suivant.Name = "BTN_Suivant";
            this.BTN_Suivant.Size = new System.Drawing.Size(62, 23);
            this.BTN_Suivant.TabIndex = 22;
            this.BTN_Suivant.Text = "Suiv";
            this.BTN_Suivant.UseVisualStyleBackColor = true;
            this.BTN_Suivant.Click += new System.EventHandler(this.suivant_Click);
            // 
            // BTN_Fin
            // 
            this.BTN_Fin.Location = new System.Drawing.Point(362, 145);
            this.BTN_Fin.Name = "BTN_Fin";
            this.BTN_Fin.Size = new System.Drawing.Size(62, 23);
            this.BTN_Fin.TabIndex = 22;
            this.BTN_Fin.Text = "Fin";
            this.BTN_Fin.UseVisualStyleBackColor = true;
            this.BTN_Fin.Click += new System.EventHandler(this.dernier_Click);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(364, 46);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(75, 23);
            this.BTN_Add.TabIndex = 10;
            this.BTN_Add.Text = "Ajouter";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // LB_Date
            // 
            this.LB_Date.AutoSize = true;
            this.LB_Date.Location = new System.Drawing.Point(145, 120);
            this.LB_Date.Name = "LB_Date";
            this.LB_Date.Size = new System.Drawing.Size(91, 13);
            this.LB_Date.TabIndex = 20;
            this.LB_Date.Text = "Date d\'embauche";
            // 
            // DTP_Embauche
            // 
            this.DTP_Embauche.Location = new System.Drawing.Point(241, 119);
            this.DTP_Embauche.Name = "DTP_Embauche";
            this.DTP_Embauche.Size = new System.Drawing.Size(100, 20);
            this.DTP_Embauche.TabIndex = 23;
            // 
            // GestionDisque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 178);
            this.Controls.Add(this.DTP_Embauche);
            this.Controls.Add(this.BTN_Fin);
            this.Controls.Add(this.BTN_Suivant);
            this.Controls.Add(this.BTN_Prec);
            this.Controls.Add(this.LB_Date);
            this.Controls.Add(this.LBL_Salaire);
            this.Controls.Add(this.LBL_Prenom);
            this.Controls.Add(this.LBL_Nom);
            this.Controls.Add(this.LBL_NumEMP);
            this.Controls.Add(this.TB_Salaire);
            this.Controls.Add(this.TB_Prenom);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.TB_NoEMP);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.BTN_Supprimer);
            this.Controls.Add(this.BTN_Quitter);
            this.Controls.Add(this.BTN_Mod);
            this.Controls.Add(this.BTN_First);
            this.Controls.Add(this.LB_Dept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionDisque";
            this.Text = "Gestion des disques";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Dept;
        private System.Windows.Forms.Button BTN_First;
        private System.Windows.Forms.Button BTN_Mod;
        private System.Windows.Forms.Button BTN_Supprimer;
        private System.Windows.Forms.TextBox TB_NoEMP;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_Prenom;
        private System.Windows.Forms.TextBox TB_Salaire;
        private System.Windows.Forms.Label LBL_NumEMP;
        private System.Windows.Forms.Label LBL_Nom;
        private System.Windows.Forms.Label LBL_Prenom;
        private System.Windows.Forms.Label LBL_Salaire;
        private System.Windows.Forms.Button BTN_Quitter;
        private System.Windows.Forms.Button BTN_Prec;
        private System.Windows.Forms.Button BTN_Suivant;
        private System.Windows.Forms.Button BTN_Fin;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.Label LB_Date;
        private System.Windows.Forms.DateTimePicker DTP_Embauche;
    }
}

