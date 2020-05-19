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
    public partial class BikeInterface : Form
    {
        VelibServiceClient velibService = new VelibServiceClient();
      
        public BikeInterface()
        {
            InitializeComponent();
            string cities = velibService.GetAllCities();
            var arr = cities.Split(Environment.NewLine.ToCharArray());
            List<string> cities_formate = new List<string>(arr);
            string res = "";
            foreach(string cname in cities_formate)
            {
                res = res + cname + Environment.NewLine;
            }
            textBox1.Text = res;
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string city_name = textBox2.Text;
            if(city_name == null)
            {
                textBox2.Text = "Please input the city name";
            }
            else
            {
                
                string station = velibService.GetAllStationsOfCity(city_name);
                var arr = station.Split(Environment.NewLine.ToCharArray());
                List<string> stations_formate = new List<string>(arr);
                string res = "";
                foreach (string stname in stations_formate)
                {
                    res = res + stname + Environment.NewLine;
                }
                textBox3.Text = res;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string station_number = textBox4.Text;
            string city_name = textBox2.Text;
            string station_information = velibService.GetInfomationsOfStation(city_name, station_number);
            var arr =station_information.Split(Environment.NewLine.ToCharArray());
            List<string> stations_formate = new List<string>(arr);
            string res = "";
            foreach (string stname in stations_formate)
            {
                res = res + stname + Environment.NewLine;
            }
            textBox5.Text = res;
        }

        private void BikeInterface_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
