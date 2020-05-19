using Admin_Monitor.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Monitor
{
    public partial class Form1 : Form
    {
        MonitorClient monitor = new MonitorClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startTime = textBox1.Text;
            string endTime = textBox2.Text;
            string delay = monitor.GetAverageDelay();
            int cacheNumber = monitor.GetCacheNumber();
            string NumberofClient = monitor.GetTheNumberOfClient(startTime, endTime);
            string NumberofRequestOfClient = monitor.GetRequestOfClient(startTime, endTime);
            string NumberofRequestOfVelib = monitor.GetRequestToVelib(startTime, endTime);
            textBox3.Text = delay;
            textBox4.Text = cacheNumber.ToString();
            textBox5.Text = NumberofClient;
            textBox6.Text = NumberofRequestOfClient;
            textBox7.Text = NumberofRequestOfVelib;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
