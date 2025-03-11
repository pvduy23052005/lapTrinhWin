using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanAn1
{
    class ketnoi
    {
        public DataTable dsquanan(string sql)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True");
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi" + ex);
                return null;

            }
        }  
        public void dsupdate(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    MessageBox.Show("thanh cong");
                }
                else
                {
                    MessageBox.Show("k thanh cong");
                }
                    con.Close();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
        }
    }
}
