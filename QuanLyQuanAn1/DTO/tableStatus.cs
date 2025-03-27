using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1.DTO
{
    public class tableStatus
    {
        public void ChangeStatus(int idTable, string status)
        {


            ketnoi ketNoi = new ketnoi();

            string update = "UPDATE Tablefood SET status = N'" + status + "' where Tablefood.id = " + idTable + " ";
            ketNoi.updateTaleStatus(update);

        }

    }
}


