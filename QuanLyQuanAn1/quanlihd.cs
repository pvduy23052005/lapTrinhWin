using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanAn1
{
    public partial class quanlihd: Form
    {
        public quanlihd()
        {
            InitializeComponent();
        }
        ketnoi db = new ketnoi();
        private void quanlihd_Load(object sender, EventArgs e)
        {
            DataTable x = db.dsquanan("select id from Tablefood where Tablefood.name  = N'" + cblayban.Text + "'");
            MessageBox.Show(cblayban.Text);
            string g = x.Rows[0]["id"].ToString();
            int h = Convert.ToInt32(g);


            DataTable ds = db.dsquanan("SELECT Food.name AS [món ăn],BillInfo.count AS [số lượng],Food.price AS [giá],    (BillInfo.count * Food.price) AS [tổng tiền] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + h + "'");
            dataGridView1.DataSource = ds;

            DataTable dt = db.dsquanan("SELECT SUM(BillInfo.count * Food.price) AS sumtien FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + h + "'");
            textBox1.Text = dt.Rows[0]["sumtien"].ToString();


            DataTable l = db.dsquanan("select Bill.id from Bill,Tablefood where Bill.idTable =Tablefood.id  and   Tablefood.name  = N'" + cblayban.Text + "'");
            string idbill = l.Rows[0]["id"].ToString();
            textBox2.Text = idbill;
        }
    }
}
