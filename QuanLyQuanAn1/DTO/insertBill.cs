using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QuanLyQuanAn1.DTO
{
    public class insertBill
    {

        ketnoi ketNoi = new ketnoi();

        public void InsertBill(int tableId)
        {
            try
            {

                // Lấy ID của bàn từ đối tượng tabe ;
                ketnoi ketNoi = new ketnoi();

                // Câu truy vấn SQL với tham số hóa để tránh SQL Injection
                string query = "INSERT INTO Bill (DateCheckIn, DateCheckout, idTable, status) " +
                                "VALUES (GETDATE(), NULL, '" + tableId + "', 0)";

                // tao 1 ban ghi moi . 
                ketNoi.dsupdate(query);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị lỗi nếu có
            }
        }

        public int getIdBill()
        {

            string query = "SELECT MAX(id) FROM Bill;";
            ketnoi ketNoi = new ketnoi();

            DataTable data = ketNoi.dsquanan(query);

            // lay ra id cua bill vua moi khi them moi mon . 
            int idBill = Convert.ToInt32(data.Rows[0][0]); // Lấy ID của bàn vừa thêm

            // tra ve idBIll via them . 
            return idBill;
        }
    }
}
