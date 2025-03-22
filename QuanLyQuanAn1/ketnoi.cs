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

        public DataTable dsquanan(string sql)
        {

            try
            {

                string t = "Data Source=LAPTOP-94IP7ASU\\PHUNGVANDUY;Initial Catalog=quanLyQuanAn;Integrated Security=True";


                //string t = "Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=Duong;Integrated Security=True";

                // string t = "Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True";

                
                SqlConnection con = new SqlConnection(t);
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
            {   // cua duy dcm ko xoa nhe !.
                string t = "Data Source=LAPTOP-94IP7ASU\\PHUNGVANDUY;Initial Catalog=quanLyQuanAn;Integrated Security=True";

                SqlConnection con = new SqlConnection(t);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Đéo thành công");
                }
                    con.Close();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
        }

        internal void dsupdate(SqlCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
