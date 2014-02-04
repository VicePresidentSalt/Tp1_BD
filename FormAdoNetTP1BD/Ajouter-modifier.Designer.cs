namespace FormAdoNet
{
    partial class Ajouter_modifier
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
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_CANCEL = new System.Windows.Forms.Button();
            this.DTP_Embauche = new System.Windows.Forms.DateTimePicker();
            this.LB_Date = new System.Windows.Forms.Label();
            this.LBL_Salaire = new System.Windows.Forms.Label();
            this.LBL_Prenom = new System.Windows.Forms.Label();
            this.LBL_Nom = new System.Windows.Forms.Label();
            this.LBL_NumEMP = new System.Windows.Forms.Label();
            this.TB_Salaire = new System.Windows.Forms.TextBox();
            this.TB_Prenom = new System.Windows.Forms.TextBox();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_NoEMP = new System.Windows.Forms.TextBox();
            this.LB_Dept = new System.Windows.Forms.Label();
            this.CB_DEPT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_EMPRESP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.Location = new System.Drawing.Point(60, 213);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 14;
            this.BTN_OK.Text = "Ok";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCEL.Location = new System.Drawing.Point(141, 213);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(75, 23);
            this.BTN_CANCEL.TabIndex = 15;
            this.BTN_CANCEL.Text = "Annuler";
            this.BTN_CANCEL.UseVisualStyleBackColor = true;
            // 
            // DTP_Embauche
            // 
            this.DTP_Embauche.Location = new System.Drawing.Point(124, 125);
            this.DTP_Embauche.Name = "DTP_Embauche";
            this.DTP_Embauche.Size = new System.Drawing.Size(123, 20);
            this.DTP_Embauche.TabIndex = 9;
            // 
            // LB_Date
            // 
            this.LB_Date.AutoSize = true;
            this.LB_Date.Location = new System.Drawing.Point(28, 126);
            this.LB_Date.Name = "LB_Date";
            this.LB_Date.Size = new System.Drawing.Size(91, 13);
            this.LB_Date.TabIndex = 8;
            this.LB_Date.Text = "Date d\'embauche";
            // 
            // LBL_Salaire
            // 
            this.LBL_Salaire.AutoSize = true;
            this.LBL_Salaire.Location = new System.Drawing.Point(80, 104);
            this.LBL_Salaire.Name = "LBL_Salaire";
            this.LBL_Salaire.Size = new System.Drawing.Size(39, 13);
            this.LBL_Salaire.TabIndex = 6;
            this.LBL_Salaire.Text = "Salaire";
            // 
            // LBL_Prenom
            // 
            this.LBL_Prenom.AutoSize = true;
            this.LBL_Prenom.Location = new System.Drawing.Point(76, 78);
            this.LBL_Prenom.Name = "LBL_Prenom";
            this.LBL_Prenom.Size = new System.Drawing.Size(43, 13);
            this.LBL_Prenom.TabIndex = 4;
            this.LBL_Prenom.Text = "Prenom";
            // 
            // LBL_Nom
            // 
            this.LBL_Nom.AutoSize = true;
            this.LBL_Nom.Location = new System.Drawing.Point(90, 52);
            this.LBL_Nom.Name = "LBL_Nom";
            this.LBL_Nom.Size = new System.Drawing.Size(29, 13);
            this.LBL_Nom.TabIndex = 2;
            this.LBL_Nom.Text = "Nom";
            // 
            // LBL_NumEMP
            // 
            this.LBL_NumEMP.AutoSize = true;
            this.LBL_NumEMP.Enabled = false;
            this.LBL_NumEMP.Location = new System.Drawing.Point(51, 26);
            this.LBL_NumEMP.Name = "LBL_NumEMP";
            this.LBL_NumEMP.Size = new System.Drawing.Size(67, 13);
            this.LBL_NumEMP.TabIndex = 0;
            this.LBL_NumEMP.Text = "No. Employe";
            // 
            // TB_Salaire
            // 
            this.TB_Salaire.Location = new System.Drawing.Point(124, 101);
            this.TB_Salaire.MaxLength = 6;
            this.TB_Salaire.Name = "TB_Salaire";
            this.TB_Salaire.Size = new System.Drawing.Size(123, 20);
            this.TB_Salaire.TabIndex = 7;
            this.TB_Salaire.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Salaire_KeyPress);
            // 
            // TB_Prenom
            // 
            this.TB_Prenom.Location = new System.Drawing.Point(124, 75);
            this.TB_Prenom.Name = "TB_Prenom";
            this.TB_Prenom.Size = new System.Drawing.Size(123, 20);
            this.TB_Prenom.TabIndex = 5;
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(124, 49);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(123, 20);
            this.TB_Nom.TabIndex = 3;
            this.TB_Nom.TextChanged += new System.EventHandler(this.TB_Nom_TextChanged);
            // 
            // TB_NoEMP
            // 
            this.TB_NoEMP.Enabled = false;
            this.TB_NoEMP.Location = new System.Drawing.Point(124, 23);
            this.TB_NoEMP.Name = "TB_NoEMP";
            this.TB_NoEMP.Size = new System.Drawing.Size(123, 20);
            this.TB_NoEMP.TabIndex = 1;
            // 
            // LB_Dept
            // 
            this.LB_Dept.AutoSize = true;
            this.LB_Dept.Location = new System.Drawing.Point(22, 154);
            this.LB_Dept.Name = "LB_Dept";
            this.LB_Dept.Size = new System.Drawing.Size(96, 13);
            this.LB_Dept.TabIndex = 10;
            this.LB_Dept.Text = "Code Departement";
            // 
            // CB_DEPT
            // 
            this.CB_DEPT.FormattingEnabled = true;
            this.CB_DEPT.Location = new System.Drawing.Point(124, 150);
            this.CB_DEPT.Name = "CB_DEPT";
            this.CB_DEPT.Size = new System.Drawing.Size(123, 21);
            this.CB_DEPT.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "No. Employe Resp.";
            // 
            // CB_EMPRESP
            // 
            this.CB_EMPRESP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_EMPRESP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_EMPRESP.FormattingEnabled = true;
            this.CB_EMPRESP.Location = new System.Drawing.Point(124, 177);
            this.CB_EMPRESP.Name = "CB_EMPRESP";
            this.CB_EMPRESP.Size = new System.Drawing.Size(123, 21);
            this.CB_EMPRESP.TabIndex = 13;
            this.CB_EMPRESP.Text = "0";
            // 
            // Ajouter_modifier
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_CANCEL;
            this.ClientSize = new System.Drawing.Size(276, 248);
            this.Controls.Add(this.CB_EMPRESP);
            this.Controls.Add(this.CB_DEPT);
            this.Controls.Add(this.DTP_Embauche);
            this.Controls.Add(this.LB_Date);
            this.Controls.Add(this.LB_Dept);
            this.Controls.Add(this.LBL_Salaire);
            this.Controls.Add(this.LBL_Prenom);
            this.Controls.Add(this.LBL_Nom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_NumEMP);
            this.Controls.Add(this.TB_Salaire);
            this.Controls.Add(this.TB_Prenom);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.TB_NoEMP);
            this.Controls.Add(this.BTN_CANCEL);
            this.Controls.Add(this.BTN_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ajouter_modifier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Ajouter_modifier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_CANCEL;
        private System.Windows.Forms.DateTimePicker DTP_Embauche;
        private System.Windows.Forms.Label LB_Date;
        private System.Windows.Forms.Label LBL_Salaire;
        private System.Windows.Forms.Label LBL_Prenom;
        private System.Windows.Forms.Label LBL_Nom;
        private System.Windows.Forms.Label LBL_NumEMP;
        private System.Windows.Forms.TextBox TB_Salaire;
        private System.Windows.Forms.TextBox TB_Prenom;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_NoEMP;
        private System.Windows.Forms.Label LB_Dept;
        private System.Windows.Forms.ComboBox CB_DEPT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_EMPRESP;
    }
}