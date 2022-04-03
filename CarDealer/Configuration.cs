using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String brand = comboBox1.Text;
            String model = comboBox2.Text;
            String engine = comboBox3.Text;
            
            listBox1.Items.Clear();
        }
    }
}