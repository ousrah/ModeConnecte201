using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ModeConnecte201
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
            SqlConnection cn2 = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn2.Open();


            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
            // dataGridView1.Rows.Clear();
            listBox1.Items.Clear();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["nomouvr"]);
                //  dataGridView1.Rows.Add(dr["numouvr"], dr["nomouvr"]);
            }

            SqlCommand com2 = new SqlCommand("select * from editeur", cn2);


            SqlDataReader dr2 = com2.ExecuteReader();
            listBox2.Items.Clear();
            while (dr2.Read())
            {
                listBox2.Items.Add(dr2["nomed"]);

            }


            dr2.Close();
            dr2 = null;


            dr.Close();
            dr = null;
            com = null;
            com2 = null;
            cn.Close();
            cn = null;
            cn2.Close();
            cn2 = null;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
            SqlCommand com = new SqlCommand("select count(*) from ouvrage", cn);
            int nb = Convert.ToInt32(com.ExecuteScalar());

            textBox1.Text = nb.ToString();
            com = null;
            cn.Close();
            cn = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
            SqlCommand com = new SqlCommand("insert into ouvrage values (54215487,'test mode connecte',2022,1,'CLET')", cn);
            com.ExecuteNonQuery();


            com = null;
            cn.Close();
            cn = null;

        }
    }
}
