using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormChangeTienPhong : Form
    {
        string _name;
        int _tien;
        int _dien;
        int _nuoc;
        public FormChangeTienPhong(string name, int tien, int dien, int nuoc)
        {
            InitializeComponent();
            _name = name;
            _tien = tien;
            _dien = dien;
            _nuoc = nuoc;
        }

        private void FormChangeTienPhong_Load(object sender, EventArgs e)
        {
            textBoxTienPhong.Text = _tien.ToString();
            labelTenPhong.Text = _name;
            textBoxDien.Text = _dien.ToString();
            textBoxNuoc.Text = _nuoc.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBoxTienPhong.Text != "") && (textBoxDien.Text != "") && (textBoxNuoc.Text != ""))
            {
                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).changeMoney(int.Parse(textBoxTienPhong.Text.ToString()), int.Parse(textBoxDien.Text.ToString()), int.Parse(textBoxNuoc.Text.ToString()));
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập thiếu thông tin, kiểm tra lại !");
            }
        }

        private void textBoxTienPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxDien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxNuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void labelTienPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
