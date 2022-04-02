using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Addition : Form
    {
        private Form1 _frontPage;

        private int _id;
        
        private Dictionary<int, List<String>> _imageNames;
        private Dictionary<int, List<String>> _cars;

        private List<String> _fileNames = new List<string>();
        private List<String> _carDetails = new List<string>();
        
        public Addition(Form1 form1, Settings settings)
        {
            InitializeComponent();

            _frontPage = form1;

            _imageNames = settings.Imagenames;
            _cars = settings.Cars;

            _id = _imageNames.Count;
        }

        private void Addition_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String saveDirectory = $@"../../Images\{_id}";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    String fileName = Path.GetFileName(openFileDialog1.FileName);
                    String fileSavePath = Path.Combine(saveDirectory,fileName);
                    if (openFileDialog1.FileName != null)
                    {
                        File.Copy(openFileDialog1.FileName, fileSavePath, true);
                    }

                    _fileNames.Add(fileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frontPage.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _imageNames[_id] = _fileNames;
            
            _carDetails.Add(textBox1.Text);
            _carDetails.Add(textBox2.Text);
            _carDetails.Add(textBox3.Text);
            _carDetails.Add(textBox4.Text);
            _carDetails.Add(textBox4.Text);
            _carDetails.Add(textBox5.Text);
            _carDetails.Add(textBox6.Text);
            _carDetails.Add(textBox7.Text);
            _carDetails.Add(textBox8.Text);
            _carDetails.Add(textBox9.Text);
            

            _cars[_id] = _carDetails;
        }
    }
}