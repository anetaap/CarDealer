﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Addition : Form
    {
        private Form1 _frontPage;
        private Settings _settings;

        private int _id;
        private String _saveDirectory;

        private Dictionary<int, List<String>> _imageNames;
        private Dictionary<int, List<String>> _cars;

        private List<String> _fileNames = new List<string>();
        private List<String> _carDetails = new List<string>();
        
        public Addition(Form1 form1, Settings settings)
        {
            InitializeComponent();

            _frontPage = form1;
            _settings = settings;

            _imageNames = _settings.Imagenames;
            _cars = _settings.Cars;

            _id = _imageNames.Count;
            _saveDirectory = $@"../../Images\{_id}";
        }

        private void Addition_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(_saveDirectory))
                    {
                        Directory.CreateDirectory(_saveDirectory);
                    }

                    String fileName = Path.GetFileName(openFileDialog1.FileName);
                    String fileSavePath = Path.Combine(_saveDirectory,fileName);
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
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            _imageNames[_id] = _fileNames;
            
            _settings.ImageNamesToJson();
            _settings.CarsToJson();
            
            Close();
            _frontPage.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            foreach (string fileName in _fileNames)
            {
                File.Delete(Path.Combine(_saveDirectory,fileName));
            }
            _fileNames.Clear();
        }
    }
}