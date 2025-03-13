using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1
{
    public partial class frmaccount : Form
    {
        public frmaccount()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        // load form account .
        private void frmaccount_Load(object sender, EventArgs e)
        {
            // cho la ten dang nhap . 
            frmlogin frmlogin = new frmlogin();
            txtTenDangNhap.Text = frmlogin.getTenDangNhap(); 
            txtPasword.Text = frmlogin.getMatKhau();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
