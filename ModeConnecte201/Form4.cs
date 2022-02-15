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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();


            SqlCommand com = new SqlCommand("select * from ouvrage", cn);
            SqlDataReader dr = com.ExecuteReader();
  DataTable table = new DataTable();
            table.Load(dr);
    /*      
            DataColumn col1 = new DataColumn("numouvr", typeof(int));
            DataColumn col2 = new DataColumn("nomouvr", typeof(string));
            table.Columns.Add(col1);
            table.Columns.Add(col2);



            while (dr.Read())
            {
                DataRow r = table.NewRow();
                r["numouvr"] = dr["numouvr"];
                r["nomouvr"] = dr["nomouvr"];
                table.Rows.Add(r);

            }*/
    


            listBox1.DisplayMember = "nomouvr";
            listBox1.ValueMember = "numouvr";
            listBox1.DataSource = table;

            dr.Close();
            dr = null;
            com = null;

            cn.Close();
            cn = null;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(@"data source=.\sqlexpress2008;initial catalog=librairie;user id=sa;password=P@ssw0rd;");
            cn.Open();

              SqlCommand com = new SqlCommand("select * from ouvrage where numouvr = " + listBox1.SelectedValue, cn);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
            }


            dr.Close();
            dr = null;
            com = null;

            cn.Close();
            cn = null;

        }
    }
}
