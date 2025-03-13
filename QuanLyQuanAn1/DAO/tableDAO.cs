using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using QuanLyQuanAn1.DTO;
using System.Data.SqlClient;
using System.Data.Common;


namespace QuanLyQuanAn1.DAO
{
    public class tableDAO
    {

        private static tableDAO instance;
        public static tableDAO Instance
        {
            get { if (instance == null) instance = new tableDAO(); return tableDAO.instance; }
            private set { tableDAO.instance = value; }
        }

        public static int tableWidth = 50;
        public static int tableHeight = 50;


        
        public tableDAO() {}


        public List<table> LoadTableList()
        {
            List<table> tableList = new List<table>();

            string connectionString = "Data Source=LAPTOP-94IP7ASU\\PHUNGVANDUY;Initial Catalog=quanLyQuanAn;Integrated Security=True";

 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Tablefood", connection);

    
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();

                adapter.Fill(data);
                connection.Close();

                foreach (DataRow item in data.Rows)
                {
                    table table = new table(item); 
                    tableList.Add(table);
                }
            }


            return tableList;
        }

    }
}
