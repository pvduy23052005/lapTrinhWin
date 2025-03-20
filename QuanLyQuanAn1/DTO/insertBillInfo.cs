using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace QuanLyQuanAn1.DTO
{
    public class insertBillInfo
    {

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
                ketnoi ketNoi = new ketnoi();
                string query = "INSERT INTO BillInfo (idBill, idFood, count) VALUES (" + idBill + ", " + idFood + ", " + count + ")";
                ketNoi.dsupdate(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
