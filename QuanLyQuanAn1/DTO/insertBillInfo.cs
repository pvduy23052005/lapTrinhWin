using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanAn1.DTO
{
    public class insertBillInfo
    {


        ketnoi ketNoi = new ketnoi();

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
                string query = "INSERT INTO BillInfo (idBill, idFood, count) VALUES (" + idBill + ", " + idFood + ", " + count + ")";
                ketNoi.dsupdate(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool CheckMonBillInfo(int idBill, int idFood)
        {
            string query = "select * from BillInfo where idBill = '" + idBill + "' and idFood = '" + idFood + "'";

            DataTable data = ketNoi.dsquanan(query);

            if (data.Rows.Count > 0)
            {
                return false; // da co mon an trong bill
            }
            return true; // chua co mon trong bill . 
        }


        // tra ve false thi cap nhat mon , tra ve true thi them mon moi .
        public void UpdateCountBillInfo(int idBillInfo)
        {

            string query = "select count from BillInfo idBillInfo = '" + idBillInfo + "'";

            DataTable CountMonAn = ketNoi.dsquanan(query);

            int count = Convert.ToInt32(CountMonAn.Rows[0][0]);

            // tang so luong do an len . 
            count++;

            string update = "update BillInfo set count ='" + count + "' where  BillInfo.id = '" + idBillInfo + "' ";

        }
    }
}
