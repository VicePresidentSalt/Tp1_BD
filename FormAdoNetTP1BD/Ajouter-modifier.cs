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
    public partial class Ajouter_modifier : Form
    {
        public OracleConnection conn = null;
        public Ajouter_modifier()
        {
            InitializeComponent();
        }

        public string Numemp
        {
            get
            {
                return TB_NoEMP.Text;
            }
            set
            {
                TB_NoEMP.Text = value;
            }
        }
        public string nomEmp
        {
            get
            {
                return TB_Nom.Text;
            }
            set
            {
                TB_Nom.Text = value;
            }
        }

        public string prenomEmp
        {
            get
            {
                return TB_Prenom.Text;
            }
            set
            {
                TB_Prenom.Text = value;
            }
        }
        public string Embauche
        {
            get
            {
                return DTP_Embauche.Value.ToString(); 
            }
            set
            {
                DTP_Embauche.Value = DateTime.Parse(value);
            }
        }

        public string salaire
        {
            get 
            {
                return TB_Salaire.ToString();
            }
            set 
            {
                TB_Salaire.Text = value;
            }
        }

        public string CodeDept
        {
            get
            {
                return CB_DEPT.Text;
            }
            set
            {
                CB_DEPT.Text = value;
            }
        }

        public string Empresp
        {
            get
            {
                return CB_EMPRESP.Text;
            }
            set
            {
                CB_EMPRESP.Text = value;
            }
        }

        private void TB_Salaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Ajouter_modifier_Load(object sender, EventArgs e)
        {
            if (conn != null)
            {
                OracleCommand oraSelect = conn.CreateCommand();
                oraSelect.CommandText = "SELECT codedept FROM departements";
                using (OracleDataReader oraReader = oraSelect.ExecuteReader())
                {
                    while (oraReader.Read())
                    {
                        CB_DEPT.Items.Add(oraReader.GetString(0));
                    }
                }

                OracleCommand oraSelectEMP = conn.CreateCommand();
                oraSelectEMP.CommandText = "SELECT NUMEMP FROM EMPLOYES";
                using (OracleDataReader orareademp = oraSelectEMP.ExecuteReader())
                {
                    while(orareademp.Read())
                    {
                        CB_EMPRESP.Items.Add(orareademp.GetInt32(0));
                    }
                }
            }
        }

        private void TB_Nom_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }
        private void updateControls()
        {
            if(TB_Nom.Text =="")
            {
                BTN_OK.Enabled = false;
            }
            else
            {
                BTN_OK.Enabled = true;
            }
        }
    }
}
