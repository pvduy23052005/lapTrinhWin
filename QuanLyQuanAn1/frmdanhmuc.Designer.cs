namespace QuanLyQuanAn1
{
    partial class frmdanhmuc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.Xóa = new System.Windows.Forms.Button();
            this.datadanhmuc = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblIDdanhmuc = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblten = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datadanhmuc)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datadanhmuc);
            this.panel1.Location = new System.Drawing.Point(-3, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 373);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(446, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 373);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Xóa);
            this.panel3.Controls.Add(this.btnsua);
            this.panel3.Controls.Add(this.btnthem);
            this.panel3.Location = new System.Drawing.Point(-3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 65);
            this.panel3.TabIndex = 2;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(15, 6);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(76, 44);
            this.btnthem.TabIndex = 0;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(126, 6);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(76, 44);
            this.btnsua.TabIndex = 1;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            // 
            // Xóa
            // 
            this.Xóa.Location = new System.Drawing.Point(248, 6);
            this.Xóa.Name = "Xóa";
            this.Xóa.Size = new System.Drawing.Size(76, 44);
            this.Xóa.TabIndex = 2;
            this.Xóa.Text = "btnxoa";
            this.Xóa.UseVisualStyleBackColor = true;
            this.Xóa.Click += new System.EventHandler(this.button3_Click);
            // 
            // datadanhmuc
            // 
            this.datadanhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datadanhmuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datadanhmuc.Location = new System.Drawing.Point(0, 0);
            this.datadanhmuc.Name = "datadanhmuc";
            this.datadanhmuc.RowHeadersWidth = 51;
            this.datadanhmuc.RowTemplate.Height = 24;
            this.datadanhmuc.Size = new System.Drawing.Size(442, 373);
            this.datadanhmuc.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.lblIDdanhmuc);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 58);
            this.panel4.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(196, 22);
            this.textBox1.TabIndex = 1;
            // 
            // lblIDdanhmuc
            // 
            this.lblIDdanhmuc.AutoSize = true;
            this.lblIDdanhmuc.Location = new System.Drawing.Point(21, 15);
            this.lblIDdanhmuc.Name = "lblIDdanhmuc";
            this.lblIDdanhmuc.Size = new System.Drawing.Size(23, 16);
            this.lblIDdanhmuc.TabIndex = 0;
            this.lblIDdanhmuc.Text = "ID:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.lblten);
            this.panel5.Location = new System.Drawing.Point(0, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(326, 58);
            this.panel5.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(196, 22);
            this.textBox2.TabIndex = 1;
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.Location = new System.Drawing.Point(21, 15);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(34, 16);
            this.lblten.TabIndex = 0;
            this.lblten.Text = "Tên:";
            // 
            // frmdanhmuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmdanhmuc";
            this.Text = "frmdanhmuc";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datadanhmuc)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Xóa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView datadanhmuc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblIDdanhmuc;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblten;
    }
}