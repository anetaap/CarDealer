using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Form1 : Form
    {
        private Addition _addition;
        private Reservation _reservation;
        private Configuration _configuration;
        public Form1()
        {
            InitializeComponent();
            
            _reservation = new Reservation(this);
            _configuration = new Configuration(this);
            _addition = new Addition(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            Hide();
            _addition.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            _configuration.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            _reservation.Show();
        }
    }
}