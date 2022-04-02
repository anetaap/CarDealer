using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Addition : Form
    {
        private Form1 _frontpage;
        private Dictionary<int, List<String>> _imagenames;
        private List<String> _filenames = new List<string>();

        public Addition(Form1 form1, Settings settings)
        {
            InitializeComponent();

            _frontpage = form1;

            _imagenames = settings.Imagenames;
        }

        private void Addition_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String saveDirectory = @"C:\Users\aneta_p\Documents\Studia\Semestr_4\PZ2\CarDealer\CarDealer\Images";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    String fileName = Path.GetFileName(openFileDialog1.FileName);
                    String fileSavePath = Path.Combine(saveDirectory, fileName);
                    if (openFileDialog1.FileName != null) 
                        File.Copy(openFileDialog1.FileName, fileSavePath, true);

                    _filenames.Add(fileName);
                }
                _imagenames[_imagenames.Count] = _filenames;
            }
        }
    }
}