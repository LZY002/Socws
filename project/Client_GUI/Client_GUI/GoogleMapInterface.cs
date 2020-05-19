using Client_GUI.ServiceReference1;
using Client_GUI.ServiceReference2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_GUI
{
    public partial class GoogleMapInterface : Form

    {
        VelibServiceClient velibService = new VelibServiceClient();
        GoogleMapServiceClient google = new GoogleMapServiceClient();
        
        public GoogleMapInterface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string departure = textBox1.Text;
            string destination = textBox2.Text;
            string city = textBox4.Text;
            List<string> routes = new List<string>(google.GetRoute(city,departure, destination));
            string res = "";
            foreach(string route in routes)
            {
                res = res+ route+ Environment.NewLine;
            }
            textBox3.Text = res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
