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
                string query = "INSERT INTO BillInfo (idBill, idFood, count) VALUES ("+ idBill +" , "+idFood +" , "+count+")";
                ketNoi.dsupdate(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool CheckMonBillInfo( int idBill, int idFood , int idTable )
        {
            string query = "SELECT BillInfo.id  FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = "+idBill +" and BillInfo.idFood = "+idFood+" and Bill.idTable = " + idTable+ " ; \r\n";

            DataTable data = ketNoi.dsquanan(query);

                

            if (data.Rows.Count > 0)
            {
                return false; // da co mon an trong bill
            }
            return true; // chua co mon trong bill . 
        }


        // tra ve false thi cap nhat mon , tra ve true thi them mon moi .
        public void UpdateCountBillInfo(int idBill , int idFood , int idTable  , int soLuong )
        {

            string query = "SELECT BillInfo.id , BillInfo.count FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = " + idBill + " and BillInfo.idFood = " + idFood + " and Bill.idTable = '" + idTable + "' ; \r\n";

            DataTable CountMonAn = ketNoi.dsquanan(query);

            int count = Convert.ToInt32(CountMonAn.Rows[0][1]);

            int idBillInfo = Convert.ToInt32(CountMonAn.Rows[0][0]);

            MessageBox.Show("idBillInfo : " + idBillInfo);


            // tang so luong do an len . 
            count = count + soLuong;

            string update = "update BillInfo set count =" + count + " where  BillInfo.id = " + idBillInfo + " ";

            ketNoi.dsupdate(update);
        }
    }
}
