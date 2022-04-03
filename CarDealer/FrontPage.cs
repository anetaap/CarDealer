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
        private Settings _settings;
        private Reservation _reservation;
        public Form1()
        {
            InitializeComponent();

            _settings = new Settings();

            _addition = new Addition(this, _settings);
            _reservation = new Reservation(this, _settings);
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
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            _reservation.Show();
        }
    }
}