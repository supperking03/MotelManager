namespace QuanLyPhongTro
{
    partial class FormDoiDienNuoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDien = new System.Windows.Forms.TextBox();
            this.textBoxNuoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDien
            // 
            this.textBoxDien.Location = new System.Drawing.Point(88, 76);
            this.textBoxDien.Name = "textBoxDien";
            this.textBoxDien.Size = new System.Drawing.Size(100, 20);
            this.textBoxDien.TabIndex = 0;
            this.textBoxDien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDien_KeyPress);
            // 
            // textBoxNuoc
            // 
            this.textBoxNuoc.Location = new System.Drawing.Point(88, 112);
            this.textBoxNuoc.Name = "textBoxNuoc";
            this.textBoxNuoc.Size = new System.Drawing.Size(100, 20);
            this.textBoxNuoc.TabIndex = 1;
            this.textBoxNuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNuoc_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Điện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nước";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thay Đổi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDoiDienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNuoc);
            this.Controls.Add(this.textBoxDien);
            this.Name = "FormDoiDienNuoc";
            this.Text = "FormDoiDienNuoc";
            this.Load += new System.EventHandler(this.FormDoiDienNuoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDien;
        private System.Windows.Forms.TextBox textBoxNuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}