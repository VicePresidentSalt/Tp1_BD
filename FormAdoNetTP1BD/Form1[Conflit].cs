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
            if (TB_User.Text == "" && TB_Pass.Text == "")
            {
                BTN_Connect.Enabled = false;
            }
            else
            {
                BTN_Connect.Enabled = true;
            }
            if (conn.State.ToString() == "Open")
            {
                BTN_Lister.Enabled = true;
                BTN_Deconnect.Enabled = true;
                BTN_Connect.Enabled = false;
                TB_User.Enabled = false;
                TB_Pass.Enabled = false;
                BTN_First.Enabled = true;
                BTN_Mod.Enabled = true;
                BTN_Supprimer.Enabled = true;
                TB_NoDisque.Enabled = true;
                TB_Duree.Enabled = true;
                TB_Annee.Enabled = true;
                TB_Titre.Enabled = true;
                ListeCompagnie.Enabled = true;
                TB_NOCIE.Enabled = true;
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
                BTN_Lister.Enabled = false;
                BTN_Deconnect.Enabled = false;
                TB_User.Enabled = true;
                TB_Pass.Enabled = true;
                BTN_First.Enabled = false;
                BTN_Mod.Enabled = false;
                BTN_Supprimer.Enabled = false;
                TB_NoDisque.Enabled = false;
                TB_Duree.Enabled = false;
                TB_Annee.Enabled = false;
                TB_Titre.Enabled = false;
                ListeCompagnie.Items.Clear();
                ListeCompagnie.Enabled = false;
                TB_NOCIE.Enabled = false;
                BTN_Add.Enabled = false;
            }
        }

        private void UpdateTextBox()
        {
            TB_NoDisque.DataBindings.Add("text", Data, "Resultats.NoDisque");
            TB_Titre.DataBindings.Add("text", Data, "Resultats.TitreDisque");
            TB_Duree.DataBindings.Add("text", Data, "Resultats.DureeMinuteDisque");
            TB_Annee.DataBindings.Add("text", Data, "Resultats.AnneeDisque");
        }
        private void ClearBindings()
        {
            TB_NoDisque.DataBindings.Clear();
            TB_NoDisque.Clear();
            TB_Titre.DataBindings.Clear();
            TB_Titre.Clear();
            TB_Duree.DataBindings.Clear();
            TB_Duree.Clear();
            TB_Annee.DataBindings.Clear();
            TB_Annee.Clear();

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
                ListeCompagnie.Items.Clear();
                string sql = "select nomCie from CompagniesDisque";
                OracleCommand oraCMD = new OracleCommand(sql, conn);
                oraCMD.CommandType = CommandType.Text;

                OracleDataReader oraRead = oraCMD.ExecuteReader();

                while (oraRead.Read())
                {
                    ListeCompagnie.Items.Add(oraRead.GetString(0));
                }
                ListeCompagnie.SelectedIndex = 0;
                oraRead.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void BTN_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                string Dsource = "(DESCRIPTION="
               + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
               + "(HOST=205.237.244.251)(PORT=1521)))"
               + "(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

                String ChaineConnexion = "Data Source=" + Dsource
                + ";User Id=" + TB_User.Text + " ; Password =" + TB_Pass.Text;
                conn.ConnectionString = ChaineConnexion;

                conn.Open();

                MessageBox.Show(conn.State.ToString());
                UpdateControls();



                if (conn.State.ToString() == "Open")
                    Getinfos();
            }
            catch
            {
                MessageBox.Show(conn.State.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void TB_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BTN_Connect_Click(sender, e);
            }
        }

        private void BTN_Lister_Click(object sender, EventArgs e)
        {
            Lister();
        }

        private void BTN_Deconnect_Click(object sender, EventArgs e)
        {
            conn.Close();
            MessageBox.Show(conn.State.ToString());
            TB_Pass.Clear();
            UpdateControls();
            TB_Pass.Focus();
            DataDisques.Enabled = false;
            DataDisques.DataBindings.Clear();

        }

        private void TB_Pass_TextChanged(object sender, EventArgs e)
        {
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
                    "'" + ListeCompagnie.Text + "'";
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
            string sqlIns = "insert into DISQUES(NODISQUE, TITREDISQUE, DUREEMINUTEDISQUE,ANNEEDISQUE,Nocie) values (" + TB_NoDisque.Text + ",'" + TB_Titre.Text + "'," + TB_Duree.Text + "," + TB_Annee.Text +","+TB_NOCIE.Text + ")";  
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
            TB_NoDisque.Clear();
            TB_Titre.Clear();
            TB_Duree.Clear();
            TB_Annee.Clear();
            TB_NOCIE.Clear();
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
            string sqldel = "delete from DISQUES where NODISQUE = " + TB_NOCIE.Text ;
            try
            {
                string sqlDelete = "Delete from Disques Where NoDisque = " + "'" + TB_NoDisque.Text + "'";
                OracleCommand oraDelete = new OracleCommand(sqlDelete, conn);
                oraDelete.ExecuteNonQuery();
                vider();
                Lister();
                MessageBox.Show("Le disque a été supprimé");
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
                paramTitre.Value = TB_Titre.Text;
                paramDuree.Value = TB_Duree.Text;
                paramAnnee.Value = TB_Annee.Text;
                paramCie.Value = TB_NOCIE.Text;
                paramDisc.Value = int.Parse(TB_NoDisque.Text);
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
            if (Convert.ToInt32(TB_Annee.Text) < ANNEEMIN || Convert.ToInt32(TB_Annee.Text) > ANNEEMAX)
            {
                MessageBox.Show("L'année doit être entre 1920 et " + ANNEEMAX);
                return true;
            }
            if (Convert.ToInt32(TB_Duree.Text) < 0)
            {
                MessageBox.Show("La durée d'un disque doit être positive");
                return true;
            }
            return false;
        }

      }
    
}

