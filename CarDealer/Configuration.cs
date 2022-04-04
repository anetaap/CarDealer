using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Configuration : Form
    {
        private Form1 _frontPage;
        private Settings _settings= new Settings();
        public Configuration(Form1 frontPage)
        {
            InitializeComponent();

            _frontPage = frontPage;
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            _frontPage.Show();
            Hide();
        }

        //changing available items after choosing a brand
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            listBox1.Items.Clear();
            
            
            foreach (KeyValuePair<int,List<string>> car in _settings.Cars)
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
            
            
            foreach (KeyValuePair<int,List<string>> car in _settings.Cars)
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
            
            
            foreach (KeyValuePair<int,List<string>> car in _settings.Cars)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}