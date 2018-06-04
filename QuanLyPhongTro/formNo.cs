using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class formNo : Form
    {
        List<string> _PhongNo;
        string selected;

        public formNo(List<string> PhongNo)
        {
            InitializeComponent();
            _PhongNo = PhongNo;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void formNo_Load(object sender, EventArgs e)
        {

            foreach(string a in _PhongNo)
            {
                if(a != "")
                {
                    listView1.Items.Add(a);
                }
            }

            listView1.Sorting = SortOrder.Ascending;
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn xóa " + selected,"Có", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _PhongNo.Remove(selected);
                SaveNo();
                listView1.Clear();
                foreach (string a in _PhongNo)
                {
                    listView1.Items.Add(a);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }

        public void SaveNo()
        {
            while (_PhongNo.Contains(""))
            {
                _PhongNo.Remove("");
            }
            File.WriteAllText("no.txt", String.Empty);
            foreach (string key in _PhongNo)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("no.txt", true))
                {
                    file.Write(key + "@");
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            selected = listView1.SelectedItems[0].SubItems[0].Text;
        }
    }
}
