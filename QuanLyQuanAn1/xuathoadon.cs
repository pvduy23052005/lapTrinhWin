using QuanLyQuanAn1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1
{
    public partial class xuathoadon: Form
    {
        public xuathoadon()
        {
            InitializeComponent();
        }
        ketnoi db = new ketnoi();
        private void xuathoadon_Load(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
  
        private void button1_Click(object sender, EventArgs e)
        {
      
        
            DataTable dt = db.dsquanan("Select Bill.id from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name =  N'"+cblayban.Text+"'and Bill.gio IS NULL");
            string k = dt.Rows[0]["id"].ToString();   int h = Convert.ToInt32(k);
            MessageBox.Show(h.ToString());

            string timeValue = dateTimePicker1.Value.ToString("HH:mm:ss");
            db.dsupdate("UPDATE Bill SET Bill.gio = CONVERT(TIME, '" + timeValue + "') ,Bill.status = '1' WHERE Bill.id = '" + h+"'");

            DataTable x = db.dsquanan("select Tablefood.id from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name  = N'" + cblayban.Text + "' and  Bill.id = '" +h+" '");
            MessageBox.Show(cblayban.Text);
            string g = x.Rows[0]["id"].ToString();
            int l = Convert.ToInt32(g);


            DataTable ds = db.dsquanan("SELECT Food.name AS [món ăn],BillInfo.count AS [số lượng],Food.price AS [giá],    (BillInfo.count * Food.price) AS [tổng tiền] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "' and  Bill.id = '"+h+"'");
            dataGridView1.DataSource = ds;

            DataTable dss = db.dsquanan("SELECT SUM(BillInfo.count * Food.price) AS sumtien FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "'  and  Bill.id= '"+h+"' ");
            textBox1.Text = dss.Rows[0]["sumtien"].ToString();

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cblayban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
