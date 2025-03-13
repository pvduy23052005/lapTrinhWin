using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        // load account khi mở form
        private void frmtaikhoan_Load(object sender, EventArgs e)
        {





            string query = "SELECT * FROM Account";
            DataTable dt = DataProvider.Singleton.ExeCuteQuery(query);
            dataAccount.DataSource = dt;

        }
        // chọn dòng nào datagridview sẽ hiện lên bên phải
        private void dataAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dataAccount.SelectedRows.Count > 0)
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
            bool isValid = true;

            string tendangnhap = txtTenDangNhap.Text.Trim();
            string tenhienthi = txtTenHienThi.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            string loai = cbLoai.Text.Trim();

            
            if (string.IsNullOrEmpty(tendangnhap))
            {
                errorProvider1.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tenhienthi))
            {
                errorProvider1.SetError(txtTenHienThi, "Vui lòng nhập tên hiển thị");
                isValid = false;
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                isValid = false;
            }
            if (loai != "0" && loai != "1")
            {
                errorProvider1.SetError(cbLoai, "Loại chỉ có thể là 0 hoặc 1");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Thêm tài khoản không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem tài khoản đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM Account WHERE Username = @username ";
            int kiemtra = (int)DataProvider.Singleton.ExeCuteS(checkQuery, new object[] { tendangnhap });

            if (kiemtra > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            try
            {
                string insertQuery = "INSERT INTO Account (Username, Displayname, PassWord, Type) VALUES ( @username , @displayname , @password , @type )";
                int add = DataProvider.Singleton.ExeCuteNon(insertQuery, new object[] { tendangnhap, tenhienthi, matkhau, loai });

                if (add == 0)
                {
                    MessageBox.Show("Thêm tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dt = (DataTable)dataAccount.DataSource;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Username"] = tendangnhap;
                        newRow["Displayname"] = tenhienthi;
                        newRow["PassWord"] = matkhau;
                        newRow["Type"] = loai;
                        dt.Rows.Add(newRow);
                    }
                   
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //đóng chương trình
        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
        }
        // sửa dữ liệu
        private void btnsua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = true;

            string tendangnhap = txtTenDangNhap.Text.Trim();
            string tenhienthi = txtTenHienThi.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            string loai = cbLoai.Text.Trim();

            if (string.IsNullOrEmpty(tendangnhap))
            {
                errorProvider1.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập");
                isValid = false;
            }
            if (string.IsNullOrEmpty(tenhienthi))
            {
                errorProvider1.SetError(txtTenHienThi, "Vui lòng nhập tên hiển thị");
                isValid = false;
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                isValid = false;
            }
            if (loai != "0" && loai != "1")
            {
                errorProvider1.SetError(cbLoai, "Vui lòng nhập đúng loại");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Cập nhật tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "UPDATE Account SET Displayname = @displayname , PassWord = @password , Type = @type WHERE Username = @user ";
                int kt = DataProvider.Singleton.ExeCuteNon(query, new object[] { tenhienthi, matkhau, loai, tendangnhap });

                if (kt == 0)
                {
                    MessageBox.Show("Sửa tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sửa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    DataTable dt = (DataTable)dataAccount.DataSource;
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Username"].ToString() == tendangnhap)
                            {
                                row["Displayname"] = tenhienthi;
                                row["PassWord"] = matkhau;
                                row["Type"] = loai;
                                break;
                            }
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                string username = "";
                if (dataAccount.SelectedRows.Count > 0)
                {
                    DataGridViewRow dataGridViewRows = dataAccount.SelectedRows[0];
                   if ( dataGridViewRows.Cells[0].Value.ToString() != null){
                        username = dataGridViewRows.Cells[0].Value.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa!");
                    return;
                }
                string query = "delete from Account where username = @username ";
                int checkquery = (int)DataProvider.Singleton.ExeCuteNon(query , new object[] { username });
                if (checkquery == 0)
                {
                    MessageBox.Show("Xóa tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thành công!");


                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
