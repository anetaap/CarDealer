using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class WishList : Form
    {
        private Settings _settings;

        private int _id;
        private String _name;
        
        private List<String> _wishList = new List<string>();
        
        private Dictionary<String, List<String>> _wishLists;
        public WishList(Settings settings, int id)
        {
            InitializeComponent();
            
            _settings = settings;
            _id = id;

            _wishLists = _settings.WishList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _name = textBox1.Text;

            if (_wishLists.ContainsKey(_name))
            {
                _wishList = _wishLists[_name];
                if(!_wishList.Contains(_id.ToString()))
                    _wishList.Add(_id.ToString());
            }
            else
            {
                _wishList = new List<string>();
                _wishList.Add(_id.ToString());
                _settings.WishList[_name] = _wishList;
            }
            
            _settings.WishListToJson();
            Close();
        }
    }
}