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
    public partial class FormDoiDienNuoc : Form
    {
        int _dien;
        int _nuoc;
        public FormDoiDienNuoc(int dien, int nuoc)
        {
            InitializeComponent();
            _dien = dien;
            _nuoc = nuoc;
        }

        private void FormDoiDienNuoc_Load(object sender, EventArgs e)
        {
            textBoxDien.Text = _dien.ToString();
            textBoxNuoc.Text = _nuoc.ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBoxNuoc.Text != "") && (textBoxDien.Text != ""))
            {
                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).changeDienNuoc(int.Parse(textBoxDien.Text.ToString()),int.Parse(textBoxNuoc.Text.ToString()));
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu, vui lòng kiểm tra lại !");
            }
           
        }
    }
}
