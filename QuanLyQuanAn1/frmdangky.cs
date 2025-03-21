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
    public partial class frmdangky : Form
    {
        public frmdangky()
        {
            InitializeComponent();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string tendangnhap = txtdangnhap.Text;
            string tenhienthi = txthienthi.Text;
            string matkhau = txtmatkhau.Text;
            string nhaplaimatkhau = txtNhaplaimatkhau.Text;
            bool check = true;
           
            if(tendangnhap == "")
            {
                errorProvider1.SetError(txtdangnhap, "Mời bạn nhập tên đăng nhập");
                check = false;
            }
            if(tenhienthi == "")
            {
                errorProvider1.SetError(txthienthi, "Mời bạn nhập tên hiển thị");
                check = false;
            }
            if (matkhau == "")
            {
                errorProvider1.SetError(txtmatkhau, "Mời bạn nhập mật khẩu");
                check = false;
            }
            
            if(nhaplaimatkhau == "")
            {
                errorProvider1.SetError(txtNhaplaimatkhau, "Mời bạn nhập mật khẩu");
                check = false;
            }
            if(matkhau != nhaplaimatkhau)
            {
                errorProvider1.SetError(txtNhaplaimatkhau, "Mời bạn nhập mật khẩu đúng");
                txtNhaplaimatkhau.Text = "";
                check = false;
                return;
            }
            
            

            if (check == false)
            {
                MessageBox.Show("Bạn đăng ký không thành công");
                

            }
            else
            {
                string queryKTra = "select count(*) from Account where username = @username ";
                object KiemTra = DataProvider.Singleton.ExeCuteS(queryKTra, new object[] { tendangnhap });
                if (KiemTra != null && (int)KiemTra > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã có!");
                }
                else
                {
                    try
                    {
                        string queryInsert = "INSERT INTO Account ( username , displayname , password ) VALUES ( @username , @displayname , @password )";
                        int kt = DataProvider.Singleton.ExeCuteNon(queryInsert, new object[] { tendangnhap , tenhienthi , matkhau });

                        if (kt != 0)
                        {
                            MessageBox.Show("Đăng ký thành công");
                            Close();
                               
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtloai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthienthi_TextChanged(object sender, EventArgs e)
        {       

        }

        private void frmdangky_Load(object sender, EventArgs e)
        {

        }
    }
}
