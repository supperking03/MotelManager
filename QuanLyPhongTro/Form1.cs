using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Form1 : Form
    {

        RoomManager rm = new RoomManager();
        int HeSoDien;
        int HeSoNuoc;
        List<string> PhongNo = new List<string>();

        public void LoadNo()
        {
            // lấy dữ liệu từ file txt
            FileStream fs = new FileStream("no.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string a = sr.ReadToEnd();
            string[] g = new string[2];
            g = a.Split('@');
            fs.Close();


            for (int i = 0; i < g.Length; i++)
            {
                try
                {
                    PhongNo.Add(g[i]);
                }
                catch { }

            }
        }

        public void SaveNo()
        {
            while (PhongNo.Contains(""))
            {
                PhongNo.Remove("");
            }


            File.WriteAllText("no.txt", String.Empty);
            foreach (string key in PhongNo)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("no.txt", true))
                {
                    file.Write(key + "@");
                }
            }
        }


        void findMonth()
        {
            int month = DateTime.Today.Month;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {

                if (comboBox1.Items[i].ToString() == month.ToString())
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }


        }

        public Form1()
        {
            InitializeComponent();
            populate();
            findMonth();
            //listViewRoom.View = View.Details;
            ////construct columns
            //listViewRoom.Columns.Add("Tìm", 250);
            //listViewRoom.Dock = DockStyle.Fill;
            //listViewRoom.Dock = DockStyle.Fill;
            //  listViewRoom.View = View.Details;
            //listViewRoom.FullRowSelect = true;
            //listViewRoom.CellForm

        }

        public void changeDienNuoc(int dien, int nuoc)
        {
            File.WriteAllText("diennuoc.txt", String.Empty);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("diennuoc.txt", true))
            {
                file.Write(dien.ToString() + "@" + nuoc.ToString() + "@");
            }
            HeSoDien = dien;
            HeSoNuoc = nuoc;
        }

        void loadDienNuoc()
        {
            // lấy dữ liệu từ file txt
            FileStream fs = new FileStream("diennuoc.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string a = sr.ReadToEnd();
            string[] g = new string[2];
            g = a.Split('@');
            fs.Close();

            HeSoDien = int.Parse(g[0]);
            HeSoNuoc = int.Parse(g[1]);
        }

        public void populate()
        {

            listViewRoom.Items.Clear();
            rm.Load();
            string[] keys = rm.arrRoom.Keys.ToArray();
            foreach (string a in keys)
            {
                listViewRoom.Items.Add(a);

            }

            listViewRoom.Sorting = SortOrder.Ascending;
            listViewRoom.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonTinhTien.Enabled = false;
            buttonInHoaDon.Enabled = false;
            LoadNo();

        }





        public void changeMoney(int a, int dien, int nuoc)
        {
            rm.arrRoom[selected].tienPhong = a;
            rm.arrRoom[selected].dien = dien;
            rm.arrRoom[selected].nuoc = nuoc;

            totalSave();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formAddRoom far = new formAddRoom();
            far.Show();
        }

        public void addRoom(string ten, int tienPhong, int dien, int nuoc)
        {
            try
            {
                RoomDetail room = new RoomDetail();
                room.tienPhong = tienPhong;
                room.dien = dien;
                room.nuoc = nuoc;
                rm.arrRoom.Add(ten, room);
            }
            catch
            {
                MessageBox.Show("Thêm phòng thât bại, Phòng đã được thuê rồi !");
            }

        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Back)
            //{
            //    listViewRoom.Items.Clear();
            //    refresh();
            //    populate();
            //}
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rm.arrRoom.Remove(selected);
                totalSave();
                populate();
            }
            catch { }

        }
        string selected;
        private void listViewRoom_Click(object sender, EventArgs e)
        {
            buttonTinhTien.Enabled = true;

            try
            {
                selected = listViewRoom.SelectedItems[0].SubItems[0].Text;
                HeSoDien = rm.arrRoom[selected].dien;
                HeSoNuoc = rm.arrRoom[selected].nuoc;
            }
            catch { }



            UpdateBill(selected);

            foreach (ListViewItem item in listViewRoom.Items)
            {
                if (item.Text == lastSelected)
                {
                    item.BackColor = listViewRoom.BackColor;
                }
                if (item.Text == selected)
                {
                    item.BackColor = SystemColors.Highlight;
                }
            }
            lastSelected = selected;

        }

        private void UpdateBill(string selected)
        {
            RoomDetail room = new RoomDetail();
            room = rm.arrRoom[selected];

            textBoxDienCu.Text = room.dienCu.ToString();
            textBoxNuocCu.Text = room.nuocCu.ToString();
            labelTienPhong.Text = room.tienPhong.ToString();
            labelTenPhong.Text = " PHÒNG " + selected;


            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            int value;
            if (int.TryParse(labelTienPhong.Text, out value))
                labelTienPhong.Text = String.Format(cul, "{0:C0}", value);
            else
                labelTienPhong.Text = String.Empty;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            lastSelected = "no";
            foreach (ListViewItem item in listViewRoom.Items)
            {
                if (item.Text == selected)
                {
                    item.BackColor = Color.Khaki;
                }
            }


            if ((textBoxDienCu.Text != "") && (textBoxDienMoi.Text != "") && (textBoxNuocCu.Text != "") && (textBoxNuocMoi.Text != ""))
            {
                labelKyDien.Text = (int.Parse(textBoxDienMoi.Text.ToString()) - int.Parse(textBoxDienCu.Text.ToString())).ToString() + " Ký";
                labelKhoiNuoc.Text = (int.Parse(textBoxNuocMoi.Text.ToString()) - int.Parse(textBoxNuocCu.Text.ToString())).ToString() + " Khối";
                labelTienDien.Text = ((int.Parse(textBoxDienMoi.Text.ToString()) - int.Parse(textBoxDienCu.Text.ToString())) * HeSoDien).ToString();
                labelTienNuoc.Text = ((int.Parse(textBoxNuocMoi.Text.ToString()) - int.Parse(textBoxNuocCu.Text.ToString())) * HeSoNuoc).ToString();

                if (((int.Parse(textBoxDienMoi.Text.ToString()) - int.Parse(textBoxDienCu.Text.ToString())) <= 0) || ((int.Parse(textBoxNuocMoi.Text.ToString()) - int.Parse(textBoxNuocCu.Text.ToString())) <= 0))
                {
                    MessageBox.Show("Âm tiền, Kiểm tra số điện nước");
                    return;
                }

                RoomDetail room = new RoomDetail();
                room = rm.arrRoom[selected];
                labelTienPhong.Text = room.tienPhong.ToString();
                labelTongTien.Text = (int.Parse(room.tienPhong.ToString()) + ((int.Parse(textBoxDienMoi.Text.ToString()) - int.Parse(textBoxDienCu.Text.ToString())) * HeSoDien) + ((int.Parse(textBoxNuocMoi.Text.ToString()) - int.Parse(textBoxNuocCu.Text.ToString())) * HeSoNuoc)).ToString();
            }
            else
            {
                MessageBox.Show("Nhập thiếu thông tin !");
            }
            chuanhoatien();
            update();
            rm.save();

            if (buttonInHoaDon.Enabled == false)
            {
                buttonInHoaDon.Enabled = true;
            }

        }

        public void totalSave()
        {
            rm.save();
        }

        private void update()
        {
            try
            {
                rm.arrRoom[selected].dienCu = int.Parse(textBoxDienMoi.Text.ToString());
                rm.arrRoom[selected].nuocCu = int.Parse(textBoxNuocMoi.Text.ToString());
            }
            catch
            { }
        }

        private void textBoxDienMoi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDienMoi_Leave(object sender, EventArgs e)
        {
            //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            //int value;
            //if (int.TryParse(textBoxDienMoi.Text, out value))
            //    textBoxDienMoi.Text = String.Format(cul, "{0:C0}", value);
            //else
            //    textBoxDienMoi.Text = String.Empty;
        }

        private void labelTienDien_Click(object sender, EventArgs e)
        {

        }

        private void labelTienDien_TextChanged(object sender, EventArgs e)
        {

        }

        private void chuanhoatien()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            int value;
            if (int.TryParse(labelTienDien.Text, out value))
                labelTienDien.Text = String.Format(cul, "{0:C0}", value);
            else
                labelTienDien.Text = String.Empty;


            int value2;
            if (int.TryParse(labelTienNuoc.Text, out value2))
                labelTienNuoc.Text = String.Format(cul, "{0:C0}", value2);
            else
                labelTienNuoc.Text = String.Empty;

            int value3;
            if (int.TryParse(labelTienPhong.Text, out value3))
                labelTienPhong.Text = String.Format(cul, "{0:C0}", value3);
            else
                labelTienPhong.Text = String.Empty;

            int value4;
            if (int.TryParse(labelTongTien.Text, out value4))
                labelTongTien.Text = String.Format(cul, "{0:C0}", value4);
            else
                labelTongTien.Text = String.Empty;
        }

        private void textBoxDienCu_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDienCu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBoxDienCu.ReadOnly == true)
            {
                textBoxDienCu.ReadOnly = false;
            }
            else
            {
                textBoxDienCu.ReadOnly = true;
            }
        }

        private void textBoxNuocMoi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                FormChangeTienPhong fctp = new FormChangeTienPhong(selected, rm.arrRoom[selected].tienPhong, rm.arrRoom[selected].dien,rm.arrRoom[selected].nuoc);
                fctp.Show();
            }
            catch { }

        }

        private void buttonThayDoi_Click(object sender, EventArgs e)
        {
            FormDoiDienNuoc fddn = new FormDoiDienNuoc(HeSoDien, HeSoNuoc);
            fddn.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewRoom.Items)
            {
                if (item.Text == selected)
                {
                    if (item.BackColor == listViewRoom.BackColor)
                    {
                        item.BackColor = Color.Khaki;
                    }
                    else
                    {
                        item.BackColor = listViewRoom.BackColor;
                    }
                }
            }
        }
        public string lastSelected;
        private void listViewRoom_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            buttonInHoaDon.Enabled = false;
            textBoxDienMoi.Text = "0";
            textBoxNuocMoi.Text = "0";
            labelTongTien.Text = "0";
            labelTienDien.Text = "0";
            labelTienNuoc.Text = "0";
            labelKyDien.Text = "0";
            labelKhoiNuoc.Text = "0";
        }

        private void buttonInHoaDon_Click(object sender, EventArgs e)
        {
            if (!PhongNo.Contains(selected + "_Tháng" + comboBox1.Text.ToString()))
            {
                PhongNo.Add(selected + "_Tháng" + comboBox1.Text.ToString());
                SaveNo();
            }
            else
            {
                MessageBox.Show("Phòng này đã tồn tại trong DANH SÁCH NỢ ! Vui lòng XÓA phòng trong DANH SÁCH NỢ trước khi cập nhật!");
                return;
            }
            try
            {
                PrintDialog _PrintDialog = new PrintDialog();
                PrintDocument _PrintDocument = new PrintDocument();

                _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

                _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
                                                                                                               //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                DialogResult result = _PrintDialog.ShowDialog();

                //if (result == DialogResult.OK)
                //{
                //    _PrintDocument.DocumentName = "tháng" + comboBox1.Text + labelTenPhong.Text + "_" + "_" + DateTime.Now.ToString("h:mm:ss tt");
                //    _PrintDocument.Print();
                //}
                _PrintDocument.DocumentName = "tháng" + comboBox1.Text + labelTenPhong.Text + "_" + "_" + DateTime.Now.ToString("h:mm:ss tt");
                _PrintDocument.Print();



                DrawImg();

            }
            catch (Exception)
            {

            }
           

        }

        private void _CreateReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 15);
            Font smallfont = new Font("Courier New", 9);


            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            float FontHeight = font.GetHeight();
            int startX = 5;
            int startY = 60;
            int offset = 30;


            //for (int i = 0; i <= 500; i++)
            //{
            //    graphic.DrawString(((char)170).ToString(), smallfont, new SolidBrush(Color.Black), 275, i);
            //}

            //Introduce Vuon hoa kieng ba cang

            graphic.DrawString(".", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 60, startY - 20);


            graphic.DrawString("Hóa Đơn Tính Tiền", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 60, startY);
            graphic.DrawString("\n\nPhòng: " + selected, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), 10, startY);
            graphic.DrawString("\n\n\nTháng " + comboBox1.Text, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), 10, startY);


            startY += 70;
            int startXofIntroduce = startX;
            offset -= 10;
            Bitmap original = (Bitmap)Image.FromFile("line.png");
            Bitmap resized = new Bitmap(original, new Size(original.Width / 6, original.Height / 4));
            Image imgBaCang = (Image)resized;
            graphic.DrawImage(imgBaCang, 140, startY + offset - 20);
            graphic.DrawString("Tiền Điện\n", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("\n\nSố cũ :" + textBoxDienCu.Text + "\nSố mới :" + textBoxDienMoi.Text + "\n" + labelKyDien.Text + " x " + HeSoDien.ToString() + "đ", smallfont, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("\n\n\n\n\n_________________", smallfont, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("\n\n\n\n\n\n\n" + labelTienDien.Text, smallfont, new SolidBrush(Color.Black), startX, startY + offset);


            graphic.DrawString("Tiền Nước\n", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX + 140, startY + offset);
            graphic.DrawString("\n\nSố cũ :" + textBoxNuocCu.Text + "\nSố mới :" + textBoxNuocMoi.Text + "\n" + labelKhoiNuoc.Text + " x " + HeSoNuoc.ToString() + "đ", smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);

            graphic.DrawString("\n\n\n\n\n_________________", smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);
            graphic.DrawString("\n\n\n\n\n\n\n" + labelTienNuoc.Text, smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);

            startY += 80;


            graphic.DrawString("Tiền Phòng", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset * 4);
            graphic.DrawString("            : " + labelTienPhong.Text, smallfont, new SolidBrush(Color.Black), startX, startY + offset * 4);

            graphic.DrawString("-----------------------------------------------------------------", smallfont, new SolidBrush(Color.Black), startX, startY + offset * 5);

            graphic.DrawString("Tổng Cộng :", new Font("Courier New", 13, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset * 6);
            graphic.DrawString("            " + labelTongTien.Text, new Font("Courier New", 13, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset * 6);

            graphic.DrawString("\n\n\n\nGhi Chú:", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset * 5);

        }

        private void DrawImg()
        {
            Bitmap img = new Bitmap(Convert.ToInt32(301), Convert.ToInt32(414), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var graphic = Graphics.FromImage(img))
            {
                graphic.Clear(Color.White);

                Font font = new Font("Courier New", 15);
                Font smallfont = new Font("Courier New", 9);


                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                float FontHeight = font.GetHeight();
                int startX = 5;
                int startY = 60;
                int offset = 30;


                //for (int i = 0; i <= 500; i++)
                //{
                //    graphic.DrawString(((char)170).ToString(), smallfont, new SolidBrush(Color.Black), 275, i);
                //}

                //Introduce Vuon hoa kieng ba cang

                graphic.DrawString(".", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 60, startY - 20);


                graphic.DrawString("Hóa Đơn Tính Tiền", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 60, startY);
                graphic.DrawString("\n\nPhòng: " + selected, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), 10, startY);
                graphic.DrawString("\n\n\nTháng " + comboBox1.Text, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), 10, startY);


                startY += 70;
                int startXofIntroduce = startX;
                offset -= 10;
                Bitmap original = (Bitmap)Image.FromFile("line.png");
                Bitmap resized = new Bitmap(original, new Size(original.Width / 6, original.Height / 4));
                Image imgBaCang = (Image)resized;
                graphic.DrawImage(imgBaCang, 140, startY + offset - 20);
                graphic.DrawString("Tiền Điện\n", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("\n\nSố cũ :" + textBoxDienCu.Text + "\nSố mới :" + textBoxDienMoi.Text + "\n" + labelKyDien.Text + " x " + HeSoDien.ToString() + "đ", smallfont, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("\n\n\n\n\n_________________", smallfont, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("\n\n\n\n\n\n\n" + labelTienDien.Text, smallfont, new SolidBrush(Color.Black), startX, startY + offset);


                graphic.DrawString("Tiền Nước\n", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX + 140, startY + offset);
                graphic.DrawString("\n\nSố cũ :" + textBoxNuocCu.Text + "\nSố mới :" + textBoxNuocMoi.Text + "\n" + labelKhoiNuoc.Text + " x " + HeSoNuoc.ToString() + "đ", smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);

                graphic.DrawString("\n\n\n\n\n_________________", smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);
                graphic.DrawString("\n\n\n\n\n\n\n" + labelTienNuoc.Text, smallfont, new SolidBrush(Color.Black), startX + 140, startY + offset);

                startY += 80;


                graphic.DrawString("Tiền Phòng", new Font(smallfont, FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset * 4);
                graphic.DrawString("            : " + labelTienPhong.Text, smallfont, new SolidBrush(Color.Black), startX, startY + offset * 4);

                graphic.DrawString("-----------------------------------------------------------------", smallfont, new SolidBrush(Color.Black), startX, startY + offset * 5);

                graphic.DrawString("Tổng Cộng :", new Font("Courier New", 13, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset * 6);
                graphic.DrawString("            " + labelTongTien.Text, new Font("Courier New", 13, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset * 6);

                graphic.DrawString("\n\n\n\nGhi Chú:", new Font("Courier New", 10, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), new SolidBrush(Color.Black), startX, startY + offset * 5);
            }

            string name = "tháng" + comboBox1.Text.Trim().ToString() + "_" + labelTenPhong.Text.Trim().ToString() + " lúc " + DateTime.Now.Hour.ToString() +"_"+ DateTime.Now.Minute.ToString() +"_"+ DateTime.Now.Second.ToString(); /*+ "_" + "_" + DateTime.Now.ToString("h:mm:sstt");*/
            name = name.Trim().ToString();
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BanLuu\\";
            img.Save(path+name+".bmp",System.Drawing.Imaging.ImageFormat.Bmp); 
        }

        private void labelTienPhong_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDienCu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxNuocCu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath)+ "\\BanLuu\\");
        }

        private void buttonPhongNo_Click(object sender, EventArgs e)
        {
            formNo fn = new formNo(PhongNo);
            fn.Show();
        }

        private void listViewRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
