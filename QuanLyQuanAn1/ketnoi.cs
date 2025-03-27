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
        public SqlConnection Connection { get; internal set; }

        // string hung = "Data Source=LAPTOP-94IP7ASU\\PHUNGVANDUY;Initial Catalog=quanLyQuanAn;Integrated Security=True";

        string hung = "Data Source=LAPTOP-94IP7ASU\\PHUNGVANDUY;Initial Catalog=LeQuyDuonggg;Integrated Security=True";

        // string hung = "Data Source=LAPTOP-JOKOO9J7\\SQLEXPRESS;Initial Catalog=LeQuyDuong1;Integrated Security=True;";

        //     string hung = "Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=LeQuyDuonggg;Integrated Security=True;";

        public DataTable dsquanan(string sql)
        {
            try
            {

                SqlConnection con = new SqlConnection(hung);
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

                SqlConnection con = new SqlConnection(hung);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("thành công");
                }
                    con.Close();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
        }

        public void updateTaleStatus( string update)
        {
            SqlConnection con = new SqlConnection(hung);
            con.Open();
            SqlCommand cmd = new SqlCommand(update, con);
            con.Close();
        }


        internal void dsupdate(SqlCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
