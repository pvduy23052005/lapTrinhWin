using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;

namespace QuanLyQuanAn1
{
    public partial class frmtaikhoan : Form
    {
        
        public frmtaikhoan()
        {
          
            InitializeComponent();
            
           
        }

        private void frmtaikhoan_Load(object sender, EventArgs e)
        {
            
            
            {
                
                string query = "select *from Account";
                dataAccount.DataSource = DataProvider.Singleton.ExeCuteQuery(query);
            }
            
        }

        private void dataAccount_SelectionChanged(object sender, EventArgs e)
        {
            if(dataAccount.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataAccount.SelectedRows[0];
                txtTenDangNhap.Text = row.Cells[0].Value.ToString();
                txtTenHienThi.Text = row.Cells[1].Value.ToString();
                txtMatKhau.Text = row.Cells[2].Value.ToString();
                cbLoai.Text = row.Cells[3].Value.ToString();
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int check = 1;
            string tendangnhap = txtTenDangNhap.Text;
            string tenhienthi = txtTenHienThi.Text;
            string matkhau = txtMatKhau.Text;
            string loai = cbLoai.Text;
            if(tendangnhap == "")
            {
                errorProvider1.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập");
                check = 0;
            }
            if(tenhienthi == "")
            {
                errorProvider1.SetError(txtTenHienThi, "Vui lòng nhập tên hiển thị");
                check = 0;
            }
            if (matkhau == "")
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                check = 0;
            }
            if (loai == "")
            {
                errorProvider1.SetError(cbLoai, "Vui lòng nhập loại");
                check = 0;
            }
            if(loai != "0" && loai != "1")
            {
                errorProvider1.SetError(cbLoai, "Vui lòng nhập đúng loại");
                check = 0;
            }
            if(check  == 0)
            {
                MessageBox.Show("Thêm tài khoản không thành công");
            }
            else
            {
                string dem = "select count(*) from Account where Username = @username ";
                int kiemtra = (int)DataProvider.Singleton.ExeCuteS(dem, new object[] { tendangnhap });
                if(kiemtra == 0)
                {
                    string query = "insert into Account values( @username , @displayname , @password , @type )";
                    int add = DataProvider.Singleton.ExeCuteNon(query, new object[] { tendangnhap, tenhienthi, matkhau, loai, });
                    if(add == 0)
                    {
                        MessageBox.Show("Thêm tài khoản không thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã có vui lòng nhập lại!");
                }
            }
        }
    }
}
