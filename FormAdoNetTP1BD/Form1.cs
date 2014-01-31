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
    public partial class GestionDisque : Form
    {
        private const int ANNEEMIN = 1920;
        private int ANNEEMAX = DateTime.Today.Year;

        public GestionDisque()
        {
            InitializeComponent();
        }

        private OracleConnection conn = new OracleConnection();
        private DataSet Data = new DataSet();

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

        private void Getinfos()
        {
            try
            {
                string SQL = "SELECT * FROM DISQUES";

                OracleDataAdapter Oraad = new OracleDataAdapter(SQL, conn);

                if (Data.Tables.Contains("Resultats"))
                {
                    Data.Tables["Resultat"].Clear();
                }
                Oraad.Fill(Data, "Resultats");
                Oraad.Dispose();

                BindingSource Source = new BindingSource(Data, "Resultats");

                DataDisques.DataSource = Source;
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message.ToString());
            }

        }

        private void Lister()
        {
            try
            {
                LB_Dept.Items.Clear();
                string sql = "select Nomdept from departements";
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
            catch (Exception ex)
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
                    MessageBox.Show("Connecté");
                    Getinfos();
                }
            }
            catch
            {
                MessageBox.Show(conn.State.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            UpdateControls();
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
                string sqlLISTES = "select nodisque, titredisque, dureeminutedisque, anneedisque, d.nocie from disques d" + " inner join compagniesdisque cd on d.nocie = cd.nocie where nomcie =" +
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            string sqlIns = "insert into Employes(Nomemp, Prenomemp, salaireemp, dateembauche, codedept, numempresp) values (" + "'" + TB_Nom.Text + "'," + TB_Prenom.Text + "," + TB_Salaire.Text + "," + DTP_Embauche.Value.ToShortDateString() + +"," + ")";
            try
            {
                OracleCommand orainsert = new OracleCommand(sqlIns, conn);
                orainsert.CommandType = CommandType.Text;
                orainsert.ExecuteNonQuery();

                vider();
            }
            catch (Exception ex)
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
            string sqldel = "delete from DISQUES where NODISQUE = " + TB_NoEMP.Text;
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
            try
            {
                string sqlModifier = "Update Disques set TitreDisque =:TitreDisque, DureeMinutesDisque =:DureeMinutesDisque, " +
                "AnnéeDisque =:AnnéeDisque, NoCie =:NoCie Where NoDisque =:NoDisque";
                OracleCommand oraUpdate = new OracleCommand(sqlModifier, conn);
                OracleParameter paramTitre = new OracleParameter(":TitreDisque", OracleDbType.Varchar2, 30);
                OracleParameter paramDuree = new OracleParameter(":DureeMinutesDisque", OracleDbType.Int32);
                OracleParameter paramAnnee = new OracleParameter(":AnnéeDisque", OracleDbType.Int32);
                OracleParameter paramCie = new OracleParameter(":NoCie", OracleDbType.Int32);
                OracleParameter paramDisc = new OracleParameter(":NoDisque", OracleDbType.Int32);
                paramTitre.Value = TB_Nom.Text;
                paramDuree.Value = TB_Prenom.Text;
                paramAnnee.Value = TB_Salaire.Text;
                paramDisc.Value = int.Parse(TB_NoEMP.Text);
                if (!Verification())
                {
                    oraUpdate.Parameters.Add(paramTitre);
                    oraUpdate.Parameters.Add(paramDuree);
                    oraUpdate.Parameters.Add(paramAnnee);
                    oraUpdate.Parameters.Add(paramCie);
                    oraUpdate.Parameters.Add(paramDisc);
                    oraUpdate.ExecuteNonQuery();
                    MessageBox.Show("Le disque a été modifié");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private bool Verification()
        {
            if (Convert.ToInt32(TB_Salaire.Text) < ANNEEMIN || Convert.ToInt32(TB_Salaire.Text) > ANNEEMAX)
            {
                MessageBox.Show("L'année doit être entre 1920 et " + ANNEEMAX);
                return true;
            }
            if (Convert.ToInt32(TB_Prenom.Text) < 0)
            {
                MessageBox.Show("La durée d'un disque doit être positive");
                return true;
            }
            return false;
        }

    }
}

