using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;
using QuanLyQuanAn1.DTO;

namespace QuanLyQuanAn1
{
    public partial class frmtable : Form
    {
        public frmtable()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccount frmaccount = new frmaccount();
            Hide();
            frmaccount.ShowDialog();
            Show();
           
        }

        // cap nhat danh sach ban . 
        public void LoadTable()
        {
            List<table> tableList = tableDAO.Instance.LoadTableList();

            
            // duyet qua cac tung doi tuong .   
            foreach (table item in tableList)
            {
                // tao ra 1 button de hien thi  . 
                Button btn = new Button()
                {
                    // xet thuoc tinh cao rong . 
                    Width = 95,
                    Height = 95
                };

                btn.Text = item.Name + Environment.NewLine + item.Status;

                // ban nao trong thi may xanh . 
                if( item.Status == "Available")
                {
                    btn.BackColor = Color.LightGreen;
                }else // ban nao ko con thi mau hong . 
                {
                    btn.BackColor = Color.LightPink;
                }

                // them vao du lieu ra ngoif . 
                 flowLayoutPanel1.Controls.Add(btn);
                
            }

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdoanhthu frmdoanhthu = new frmdoanhthu();
            frmdoanhthu.Show() ;
        }

        private void thứcĂnToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmthucan frmthucan = new frmthucan();
            frmthucan.Show();

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmlogin.userType == 1) // Chỉ cho quản trị viên mở form tài khoản
            {
                frmtaikhoan frm = new frmtaikhoan();
                frm.Show();
            }
            else if (frmlogin.userType == 0)
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void loadTable() { }
        private void doanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdanhmuc frmdanhmuc = new frmdanhmuc();
            frmdanhmuc.Show();
        }

        private void lsvthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            xuathoadon f = new xuathoadon();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndoiban_Click(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbmon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmtable_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void lblloai_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
