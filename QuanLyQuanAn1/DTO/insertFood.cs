using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1.DTO
{
    public class insertFood
    {

        

        public int getIdFood(string tenDoAn)
        {
            try
            {
                ketnoi ketnoi = new ketnoi();
                string query = "select *from Food where name = N'" + tenDoAn + "'";


                DataTable idFood = ketnoi.dsquanan(query);

                return Convert.ToInt32(idFood.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có món" +  ex.Message);
                return -1;
            }
        }
    }
}
