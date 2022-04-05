using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Configuration : Form
    {
        private int _id;
        private int _iterator = 0;
        private String _imageDirectory;

        private Form1 _frontPage;
        private Settings _settings = new Settings();

        private List<String> _carImages;

        public Configuration(Form1 frontPage)
        {
            InitializeComponent();

            _frontPage = frontPage;
        }

        //displaying all available cars from our database
        private void Display()
        {
            _settings.Reload();

            for (int i = 0; i < _settings.Cars.Count; i++)
            {
                String brand = _settings.Cars[i][0];
                String model = _settings.Cars[i][1];
                String engine = _settings.Cars[i][2];
                String price = _settings.Cars[i][6];

                if (!comboBox1.Items.Contains(brand))
                {
                    comboBox1.Items.Add(brand);
                }

                if (!comboBox2.Items.Contains(model))
                {
                    comboBox2.Items.Add(model);
                }

                if (!comboBox3.Items.Contains(engine))
                {
                    comboBox3.Items.Add(engine);
                }

                String informations = i + ", " + brand + ", " + model + ", " + engine + ", " + price;

                listBox1.Items.Add(informations);
            }
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            _settings.Reload();
            Display();
        }

        // BACK BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            _frontPage.Show();

            button3.PerformClick();

            Hide();
        }

        //changing available items after choosing a brand
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            listBox1.Items.Clear();


            foreach (KeyValuePair<int, List<string>> car in _settings.Cars)
            {
                if (car.Value[0] == comboBox1.Text)
                {
                    comboBox2.Items.Add(car.Value[1]);
                    comboBox3.Items.Add(car.Value[2]);

                    String informations = car.Key + ", " + car.Value[0] + ", " + car.Value[1] + ", " + car.Value[2]
                                          + ", " + car.Value[6];

                    listBox1.Items.Add(informations);

                }
            }
        }

        //changing available items after choosing a model
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            listBox1.Items.Clear();


            foreach (KeyValuePair<int, List<string>> car in _settings.Cars)
            {
                if (car.Value[1] == comboBox2.Text)
                {
                    comboBox1.Items.Add(car.Value[0]);
                    comboBox3.Items.Add(car.Value[2]);

                    String informations = car.Key + ", " + car.Value[0] + ", " + car.Value[1] + ", " + car.Value[2]
                                          + ", " + car.Value[6];

                    listBox1.Items.Add(informations);

                }
            }
        }

        //changing available items after choosing an engine
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            listBox1.Items.Clear();


            foreach (KeyValuePair<int, List<string>> car in _settings.Cars)
            {
                if (car.Value[2] == comboBox3.Text)
                {
                    comboBox1.Items.Add(car.Value[0]);
                    comboBox2.Items.Add(car.Value[1]);

                    String informations = car.Key + ", " + car.Value[0] + ", " + car.Value[1] + ", " + car.Value[2]
                                          + ", " + car.Value[6];

                    listBox1.Items.Add(informations);

                }
            }
        }

        // RESET BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            pictureBox1.Image = null;

            Display();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String carInf = listBox1.GetItemText(listBox1.SelectedItem);

            String[] array = carInf.Split(',');

            _id = int.Parse(array[0]);

            _carImages = _settings.Imagenames[_id];

            _imageDirectory = $@"../../Images\{_id}\";

            String fileName = _carImages[0];

            pictureBox1.Image = new Bitmap(Path.Combine(_imageDirectory, fileName));

            var car = _settings.Cars[_id];

            String brand = $"Brand: {car[0]}";
            String model = $"Model: {car[1]}";
            String engine = $"Engine: {car[2]}";
            String paintColor = $"Paint Color: {car[3]}";
            String yop = $"Year of production: {car[4]}";
            String carMileage = $"Car Mileage: {car[5]}";
            String price = $"Price: {car[6]}";
            String phoneNumber = $"Phone Number: {car[7]}";
            String eMail = $"E-mail: {car[8]}";

            listBox2.Items.Clear();

            listBox2.Items.Add(brand);
            listBox2.Items.Add(model);
            listBox2.Items.Add(engine);
            listBox2.Items.Add(paintColor);
            listBox2.Items.Add(yop);
            listBox2.Items.Add(carMileage);
            listBox2.Items.Add(price);
            listBox2.Items.Add(phoneNumber);
            listBox2.Items.Add(eMail);
        }

        // IMAGES DISPLAYING 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                MessageBox.Show(@"First choose a car!");
            else if (_carImages.Count > 1)
            {
                if (_iterator == 0)
                {
                    _iterator = _carImages.Count;
                }
                
                String fileName = _carImages[_iterator - 1];

                pictureBox1.Image = Image.FromFile(Path.Combine(_imageDirectory, fileName));
                
                _iterator--;
            }
        }
    }
}