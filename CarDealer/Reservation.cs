using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Reservation : Form
    {
        private Form1 _frontPage;
        private Settings _settings;

        private String _name;
        private String _id;
        private String _date;
        
        private List<String> _wishList;
        private List<String> _dates;

        private Dictionary<String, List<String>> _wishLists;
        private Dictionary<String, List<String>> _reservations;
        
        public Reservation(Form1 frontPage)
        {
            _frontPage = frontPage;
            _settings = new Settings();

            _wishLists = _settings.WishList;
            _reservations = _settings.Dates;
            
            InitializeComponent();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            _settings.Reload();
        }
        
        // DISPLAY FUNCTION
        private void DisplayCars(List<String> wishList)
        {

            foreach (string s in wishList)
            {
                int id = int.Parse(s);
                
                String brand = _settings.Cars[id][0];
                String model = _settings.Cars[id][1];
                String engine = _settings.Cars[id][2];
                String price = _settings.Cars[id][6];

                String informations = id + ", " + brand + ", " + model + ", " + engine + ", " + price;

                comboBox1.Items.Add(informations);
                
            }
        }

        // BACK BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            
            _frontPage.Show();
        }

        // APPLY BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            
            _name = textBox1.Text;
            
            if (_wishLists.ContainsKey(_name))
            {
                _wishList = _wishLists[_name];
                DisplayCars(_wishList);
            }
            else
            {
                MessageBox.Show(@"First you should add cars to your personal wish list!");
            }
        }

        //CHOOSING CAR 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            
            String carInf = comboBox1.Text;

            String[] array = carInf.Split(',');

            _id = array[0];

            if (_reservations.ContainsKey(_id))
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(@"UNAVAILABLE DATES:");

                foreach (string date in _reservations[_id])
                {
                    listBox1.Items.Add(date);
                }
            }

        }

        // CHOOSING A DATE
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        { 
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            
            String carInf = comboBox1.Text;

            String[] array = carInf.Split(',');

            _id = array[0];
            
            _date = monthCalendar1.SelectionRange.Start.Date.ToString("MM/dd/yyyy");

            if (UnavailableDates(_date) == 0)
            {
                if (_settings.Dates.ContainsKey(_id))
                {
                    _dates = _reservations[_id];
                    _dates.Add(_date);
                }
                else
                {
                    _dates = new List<string>();
                    _dates.Add(_date);
                }
            }
            else
            {
                _date = null;
            }

        }
        
        // CHECKING IF DATE IS AVAILABLE FUNCTION
        private int UnavailableDates(String chosenDate)
        {
            foreach (var item in listBox1.Items)
            {
                if (chosenDate == (string) item)
                {
                    MessageBox.Show(@"THIS DATE IS ALREADY TAKEN!");
                    return 1;
                }   
            }

            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_date == null)
            {
                MessageBox.Show(@"Choose date");
                return;
            }

            _reservations[_id] = _dates;
            _settings.Dates[_id] = _reservations[_id];

            _settings.ReservationsToJson();
            
            MessageBox.Show($@"Successfully reserved testing drive for {_date}");
        }
    }
}