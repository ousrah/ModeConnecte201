using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ModeConnecte201
{
    public partial class FichierConfig : Form
    {
        public FichierConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config c = new config();
            c.cs = "CQhCGBucYtWhIUvsYjqGz2x02z8ikMzLmrB1RN9m30JjwIc37bEZJ/v6Kumkh8Yv5hQvJrPzGpRjXgd/uFNCkl4RBINYBO6lN8+w3JtvbLkiS9bH4oh5BA==";
            c.version = "1.0 beta";
            c.name = "librairie manager";
            StreamWriter sw = new StreamWriter("config.cfg");
            sw.Write(Newtonsoft.Json.JsonConvert.SerializeObject(c));
            sw.Close();



        }
    }
}
