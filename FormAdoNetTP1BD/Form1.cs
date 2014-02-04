using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace FormAdoNet
{
    public partial class GestionEmploye : Form
    {

        public GestionEmploye()
        {
            InitializeComponent();
        }

        private OracleConnection conn = new OracleConnection();
        private DataSet Data = new DataSet();
        private string Codedept = null;

        private void UpdateControls()
        {
            if (conn.State.ToString() == "Open")
            {

                BTN_First.Enabled = true;
                BTN_Mod.Enabled = true;
                BTN_Supprimer.Enabled = true;
                TB_NoEMP.Enabled = true;
                TB_Prenom.Enabled = true;
                TB_Salaire.Enabled = true;
                TB_Nom.Enabled = true;
                LB_Dept.Enabled = true;
                BTN_Add.Enabled = true;
                BTN_Fin.Enabled = true;
                BTN_Prec.Enabled = true;
                BTN_Suivant.Enabled = true;
                BTN_First.Enabled = true;
            }
            else
            {
                BTN_First.Enabled = false;
                BTN_Suivant.Enabled = false;
                BTN_Prec.Enabled = false;
                BTN_Fin.Enabled = false;
                BTN_First.Enabled = false;
                BTN_Mod.Enabled = false;
                BTN_Supprimer.Enabled = false;
                TB_NoEMP.Enabled = false;
                TB_Prenom.Enabled = false;
                TB_Salaire.Enabled = false;
                TB_Nom.Enabled = false;
                LB_Dept.Items.Clear();
                LB_Dept.Enabled = false;
                BTN_Add.Enabled = false;
            }
        }

        private void UpdateTextBox()
        {
            TB_NoEMP.DataBindings.Add("text", Data, "Resultats.Numemp");
            TB_Nom.DataBindings.Add("text", Data, "Resultats.Nomemp");
            TB_Prenom.DataBindings.Add("text", Data, "Resultats.Prenomemp");
            TB_Salaire.DataBindings.Add("text", Data, "Resultats.Salaireemp");
            DTP_Embauche.DataBindings.Add("text", Data, "Resultats.DateEmbauche");
        }
        private void ClearBindings()
        {
            TB_NoEMP.DataBindings.Clear();
            TB_NoEMP.Clear();
            TB_Nom.DataBindings.Clear();
            TB_Nom.Clear();
            TB_Prenom.DataBindings.Clear();
            TB_Prenom.Clear();
            TB_Salaire.DataBindings.Clear();
            TB_Salaire.Clear();
            DTP_Embauche.DataBindings.Clear();
            DTP_Embauche.Value = DateTime.Now;

        }


        private void Lister()
        {
            try
            {
                LB_Dept.Items.Clear();
                string sql = "select nomdept from departements";
                OracleCommand oraCMD = new OracleCommand(sql, conn);
                oraCMD.CommandType = CommandType.Text;

                OracleDataReader oraRead = oraCMD.ExecuteReader();

                while (oraRead.Read())
                {
                    LB_Dept.Items.Add(oraRead.GetString(0));
                }
                LB_Dept.SelectedIndex = 0;
                oraRead.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void Connect()
        {
            try
            {
                string Dsource = "(DESCRIPTION="
               + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
               + "(HOST=205.237.244.251)(PORT=1521)))"
               + "(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

                String ChaineConnexion = "Data Source=" + Dsource
                + ";User Id=CoteFran ; Password =oracle1";
                conn.ConnectionString = ChaineConnexion;

                conn.Open();

                UpdateControls();

                if (conn.State.ToString() == "Open")
                {
                    UpdateControls();
                }
            }
            catch (OracleException Ex)
            {
                switch (Ex.Number)
                {
                    case 12170:
                        MessageBox.Show("La base de données est indisponible,réessayer plus tard", "Erreur 12170", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12543:
                        MessageBox.Show("Connexion impossible,Vérifiez votre connection internet", "Erreur 12543", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(Ex.Message.ToString());
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            UpdateControls();
            Lister();
        }


        private void BTN_Quitter_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void TB_Chiffre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_Duree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ':'
        && (sender as TextBox).Text.IndexOf(':') > -1)
            {
                e.Handled = true;
            }
        }

        private void ListeCompagnie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OracleCommand oraSelect = conn.CreateCommand();
                oraSelect.CommandText = "select codedept from departements where nomdept = '" + LB_Dept.Text + "'";
                using (OracleDataReader oraReader = oraSelect.ExecuteReader())
                {
                    if (oraReader.Read())
                    {
                        Codedept = oraReader.GetString(0);
                    }
                }
                
                
                string sqlLISTES = "select numemp, nomemp, prenomemp, salaireemp, dateembauche from employes e" + " inner join departements d on d.codedept = e.codedept where nomdept =" +
                    "'" + LB_Dept.Text + "'";
                OracleDataAdapter oraliste = new OracleDataAdapter(sqlLISTES, conn);

                if (Data.Tables.Contains("Resultats"))
                {
                    Data.Tables["Resultats"].Clear();
                }
                oraliste.Fill(Data, "Resultats");

                ClearBindings();

                UpdateTextBox();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            string sqlIns = "insert into Employes(Nomemp, Prenomemp, salaireemp, dateembauche, codedept, numempresp) values (" + "'" + TB_Nom.Text + "'," + TB_Prenom.Text + "," + TB_Salaire.Text + "," + DTP_Embauche.Value.ToShortDateString() + "," + ")";
            try
            {
                OracleCommand orainsert = new OracleCommand(sqlIns, conn);
                orainsert.CommandType = CommandType.Text;
                orainsert.ExecuteNonQuery();

                vider();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void vider()
        {
            TB_NoEMP.Clear();
            TB_Nom.Clear();
            TB_Prenom.Clear();
            TB_Salaire.Clear();
        }
        private void premier_Click(object sender, EventArgs e)
        {
            this.BindingContext[Data, "Resultats"].Position = 0;
        }

        private void dernier_Click(object sender, EventArgs e)
        {
            this.BindingContext[Data, "Resultats"].Position =
            this.BindingContext[Data, "Resultats"].Count - 1;

        }
        private void suivant_Click(object sender, EventArgs e)
        {
            this.BindingContext[Data, "Resultats"].Position++;

        }

        private void precedent_Click(object sender, EventArgs e)
        {
            this.BindingContext[Data, "Resultats"].Position--;
        }

        private void BTN_Supprimer_Click(object sender, EventArgs e)
        {
            string sqldel = "delete from Employes where numemp = " + TB_NoEMP.Text;
            try
            {
                OracleCommand orainsert = new OracleCommand(sqldel, conn);
                orainsert.CommandType = CommandType.Text;
                orainsert.ExecuteNonQuery();

                vider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BTN_Mod_Click(object sender, EventArgs e)
        {
            Ajouter_modifier Modifier = new Ajouter_modifier();

            Modifier.conn = this.conn;
            Modifier.Text = "Modification";
            Modifier.Numemp = TB_NoEMP.Text;
            Modifier.nomEmp = TB_Nom.Text;
            Modifier.prenomEmp = TB_Prenom.Text;
            Modifier.salaire = TB_Salaire.Text;
            Modifier.Embauche = DTP_Embauche.Value.ToString();
            Modifier.CodeDept = Codedept;
            Modifier.Empresp = CB_EMPRESP.Text;
            
            if(Modifier.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string sqlModifier = "Update employes set nomemp =:Nomemp, prenomemp =:Prenomemp, " +
                    "salaireemp =:Salaireemp, DateEmbauche = :Date, codedept = :CodeDept , NumempResp = :NumEmpResp Where Numemp =:NumEmp";

                    OracleCommand oraUpdate = new OracleCommand(sqlModifier, conn);
                    OracleParameter paramNom = new OracleParameter(":Nomemp", OracleDbType.Varchar2, 40);
                    OracleParameter paramPrenom = new OracleParameter(":Prenomemp", OracleDbType.Varchar2, 40);
                    OracleParameter paramSalaire = new OracleParameter(":Salaireemp", OracleDbType.Int32,8);
                    OracleParameter paramDate = new OracleParameter(":Date", OracleDbType.Date);
                    OracleParameter paramCodedept = new OracleParameter(":CodeDept", OracleDbType.Char,5);
                    OracleParameter paramNumResp = new OracleParameter(":NumEmpResp", OracleDbType.Int32, 5);
                    OracleParameter paramNumemp = new OracleParameter(":NumEmp", OracleDbType.Int32, 5);

                    paramNom.Value = Modifier.nomEmp;
                    paramPrenom.Value = TB_Prenom.Text;
                    paramSalaire.Value = TB_Salaire.Text;
                    paramDate.Value = DTP_Embauche.Value;
                    paramCodedept.Value = Modifier.CodeDept;
                    paramNumResp.Value = Modifier.Empresp;
                    paramNumemp.Value = Modifier.Numemp;


                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

