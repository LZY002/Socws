using Client_GUI.ServiceReference1;
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
    public partial class HelpInterface : Form
    {
        VelibServiceClient velibService = new VelibServiceClient();
        public HelpInterface()
        {
            InitializeComponent();
            string help = velibService.GetHelp();
            textBox1.Text = help;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
