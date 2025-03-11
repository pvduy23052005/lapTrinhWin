using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn1.DAO
{
    internal class DataProvider
    {
        private static DataProvider singleton;
       

        internal static DataProvider Singleton {

            get
            {
                if(singleton == null) singleton = new DataProvider();
                return singleton;
            }
           private set => singleton = value; 
        }
        private DataProvider() { }
        DataTable datatable = new DataTable();
        private string connectionString = "Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        public DataTable ExeCuteQuery(string query , object[] parameter = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string query = "select *from Account";
                SqlCommand cmd = new SqlCommand(query, connection);

                //cmd.Parameters.AddWithValue("@username" , id);
                if(parameter != null )
                {
                    int i = 0;
                    string[] lst = query.Split(' ');
                    foreach (var s in lst )
                    {
                        if (s.Contains('@')) // cos chuwa parameter
                        {
                            cmd.Parameters.AddWithValue(s , parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datatable);
                connection.Close();
            }
           return datatable;
        }

        public int ExeCuteNon(string query, object[] parameter = null)
        {
            int data = 0;// trả  ra số dòng thành công
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                //string query = "select *from Account";
                SqlCommand cmd = new SqlCommand(query, connection);

                //cmd.Parameters.AddWithValue("@username" , id);
                if (parameter != null)
                {
                    int i = 0;
                    string[] lst = query.Split(' ');
                    foreach (var s in lst)
                    {
                        if (s.Contains('@')) // cos chuwa parameter
                        {
                            cmd.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                
                connection.Close();
            }
            return data;
        }


        public object ExeCuteS(string query, object[] parameter = null)
        {
            object data = 0;// trả  ra số dòng thành công
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                //string query = "select *from Account";
                SqlCommand cmd = new SqlCommand(query, connection);

                //cmd.Parameters.AddWithValue("@username" , id);
                if (parameter != null)
                {
                    int i = 0;
                    string[] lst = query.Split(' ');
                    foreach (var s in lst)
                    {
                        if (s.Contains('@')) // cos chuwa parameter
                        {
                            cmd.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();

                connection.Close();
            }
            return data;
        }














    }
}
