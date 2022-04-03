using System;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Reservation : Form
    {
        private Form1 _frontPage;
        private Settings _settings;

        private void DisplayCars()
        {
            for (int i = 0; i < _settings.Cars.Count; i++)
            {
                int id = i;
                String brand = _settings.Cars[i][0];
                String model = _settings.Cars[i][1];
                String engine = _settings.Cars[i][2];
                String price = _settings.Cars[i][6];

                String informations = id + ", " + brand + ", " + model + ", " + engine + ", " + price;

                comboBox1.Items.Add(informations);
            }
        }
        public Reservation(Form1 frontPage, Settings settings)
        {
            _frontPage = frontPage;
            _settings = settings;
            
            InitializeComponent();

            DisplayCars();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}