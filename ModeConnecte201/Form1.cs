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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
        

            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
            // dataGridView1.Rows.Clear();
            listBox1.Items.Clear();
            while(dr.Read())
            {
                 listBox1.Items.Add(dr["nomouvr"]);
              //  dataGridView1.Rows.Add(dr["numouvr"], dr["nomouvr"]);
          }

           
          


            dr.Close();
            dr = null;
            com = null;
         
            cn.Close();
            cn = null;
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();
            SqlCommand com = new SqlCommand("select count(*) from ouvrage", cn);
            int nb =  Convert.ToInt32(com.ExecuteScalar());

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
