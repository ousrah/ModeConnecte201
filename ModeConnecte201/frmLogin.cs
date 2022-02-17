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
using System.IO;
using System.Configuration;
using Newtonsoft.Json;

namespace ModeConnecte201
{
 
    public partial class frmLogin : Form
    {  
        private byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
    private byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");

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

        public string DecryptSym(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            // Cet objet est utilisé pour déchiffrer les données.
            // Il reçoit les données chiffrées sous la forme d'un tableau de bytes.
            // Les données déchiffrées sont également retournées sous la forme d'un tableau de bytes
            var decryptor = TDES.CreateDecryptor(key, iv);

            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

            return Encoding.Default.GetString(decryptedTextAsByte);
        }



        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            /*    string cs = ConfigurationManager.ConnectionStrings["librairieConnectionString"].ConnectionString;
                string[] t = cs.Split(';');
                string pass = t[3];
                pass = pass.Replace(" ", "");
                pass = pass.Substring(9);

                cs = t[0] + ";" + t[1] + ";" + t[2] + ";password=" + DecryptSym(System.Convert.FromBase64String(pass), cle, iv);
              */

            StreamReader sr = new StreamReader("config.cfg");
            string p = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(p);
            sr.Close();

            MessageBox.Show("bienvenu dans " + c.name + " version : " + c.version);

            String newCs = DecryptSym(System.Convert.FromBase64String(c.cs), cle, iv);


            SqlConnection cn = new SqlConnection(newCs);
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
