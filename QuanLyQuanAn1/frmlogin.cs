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


namespace QuanLyQuanAn1
{
    public partial class frmlogin : Form
    {
        public static int userType =  -1;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // tinh nang thoat . 
        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kt = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không!",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (kt == DialogResult.No) e.Cancel = true;
        }
        // kiem tra hợp lệ mật khẩu và password
        public bool loginn(string username, string password)
        {
            string query = "SELECT * FROM Account WHERE Username = @Username AND Password = @Password";

            DataTable kt = DataProvider.Singleton.ExeCuteQuery(query, new object[] { username, password });
            if(kt.Rows.Count > 0)
            {
                userType = type(username, password);
                Console.WriteLine(userType);
                return true;
            }
            return false;
        }

        public int type( string username , string password)
        {
            

            
            string query = "SELECT Type FROM Account WHERE Username = @username AND Password = @password";
            object result = DataProvider.Singleton.ExeCuteS(query, new object[] { username, password });

            if (result != null)  
            {
                return Convert.ToInt32(result); 
            }

            return -1; 
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {


            string user = txttendangnhap.Text;
            string pass = txtpassword.Text;

            if (loginn(user, pass))
            {
                frmtable frmtable = new frmtable();
                this.Hide();
                frmtable.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("tài khoản hoặc mật khẩu không hợp lệ");

            }

            //frmtable frmtable = new frmtable();
            //this.Hide();
            //frmtable.ShowDialog();
            //this.Show();



        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            frmdangky frmdangky = new frmdangky();
            frmdangky.Show();
        }
    }
}
