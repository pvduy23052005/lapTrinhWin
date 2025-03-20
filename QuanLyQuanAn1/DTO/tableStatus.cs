using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace QuanLyQuanAn1.DTO
{
    public class tableStatus
    {
       
        public void changeStatusAvailabe(int idTable)
        {
            try
            {
                ketnoi ketNoi = new ketnoi();
                string query = "UPDATE TableFood SET status = N'đã đặt' WHERE id = " + idTable;
                ketNoi.dsupdate(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void changeStatusUnAvailabe(int idTable)
        {
            try
            {
                ketnoi ketNoi = new ketnoi();
                string query = "UPDATE TableFood SET status = N'Trống' WHERE id = " + idTable;
                ketNoi.dsupdate(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
