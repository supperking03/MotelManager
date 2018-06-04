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
    public partial class formAddRoom : Form
    {

        public formAddRoom()
        {
            InitializeComponent();       

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

        private void formAddRoom_Load(object sender, EventArgs e)
        {
        }

        private void buttonNhap_Click(object sender, EventArgs e)
        {
            if ((textBoxTienPhong.Text != "") && (textBoxTen.Text != "") && (textBoxDien.Text != "") && (textBoxNuoc.Text != ""))
            {
                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).addRoom(textBoxTen.Text.ToString(), int.Parse(textBoxTienPhong.Text.ToString()), int.Parse(textBoxDien.Text.ToString()), int.Parse(textBoxNuoc.Text.ToString()));
                }



                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).totalSave();
                }

                if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).populate();
                }
                this.Close();
            }
            else
                MessageBox.Show("Nhập thiếu thông tin, vui lòng kiểm tra lại !");
           
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
    }
}
