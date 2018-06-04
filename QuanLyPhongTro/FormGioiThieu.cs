using QuanLyPhongTro;
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
    public partial class FormGioiThieu : Form
    {
        public FormGioiThieu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 hd = new Form1();
            hd.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel1.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.facebook.com/Ph%E1%BA%A7n-m%E1%BB%81m-ti%E1%BB%87n-%C3%ADch-gi%C3%A1-c%E1%BA%A3-sinh-vi%C3%AAn-2085723524987625/");
        }

        private void FormGioiThieu_Load(object sender, EventArgs e)
        {

        }
    }
}
