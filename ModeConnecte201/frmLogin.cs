using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ModeConnecte201
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        static public string hash(string chaine)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(chaine);

            SHA512 sha512 = SHA512Cng.Create();

            byte[] hash = sha512.ComputeHash(textAsByte);

            return Convert.ToBase64String(hash);

        }
        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
            string req = "select * from utilisateur where login ='"+ txtLogin.Text+"' ";
            SqlCommand com = new SqlCommand(req, cn);
            SqlDataReader dr = com.ExecuteReader();
            bool passport = false;
            if (dr.Read())
                if (dr["password"].ToString()==hash(txtPwd.Text))
                passport = true;
              
  
            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;


            if (passport)
            {
                this.Hide();
                Form1 f = new Form1();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("login ou mot de passe incorrect");

            }


        }
    }
}
