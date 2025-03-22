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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanAn1
{
   
    public partial class xuathoadon: Form
    {
       
        public xuathoadon()
        {
            InitializeComponent();
        }
        ketnoi db = new ketnoi();
        string k;
        string laytt;
        public static bool  ktratt = false;
        private void xuathoadon_Load(object sender, EventArgs e)
        {
            string chuoi = " and Bill.gio IS NULL";
            if (quanlihd.ktra != true)
            {
                
                DataTable dt = db.dsquanan("Select Bill.id,Bill.status from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name =  N'" + cblayban.Text + "'" + chuoi);
                k = dt.Rows[0]["id"].ToString();
                laytt = dt.Rows[0]["status"].ToString();
            }
            else
            {
                
                DataTable dt = db.dsquanan("Select Bill.id,Bill.gio , Bill.status, Bill.DateCheckIn from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name =  N'" + cblayban.Text + "' and Bill.id = '"+ textBox2.Text+ "'");
                k = dt.Rows[0]["id"].ToString();
                if (!DBNull.Value.Equals(dt.Rows[0]["gio"]))
                {
                    DateTime timeValue = DateTime.Parse(dt.Rows[0]["gio"].ToString());
                    DateTime dateValue = DateTime.Parse(dt.Rows[0]["DateCheckIn"].ToString());
                    dateTimePicker1.Value = timeValue;
                    dateTimePicker2.Value = dateValue;
                }
                laytt = dt.Rows[0]["status"].ToString();

            }
                 int h = Convert.ToInt32(k);
            MessageBox.Show(h.ToString());
            textBox2.Text = k;
            if(Convert.ToInt32(laytt) == 0)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

                DataTable x = db.dsquanan("select Tablefood.id from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name  = N'" + cblayban.Text + "' and  Bill.id = '" + h + " '");
            MessageBox.Show(cblayban.Text);
            string g = x.Rows[0]["id"].ToString();
            int l = Convert.ToInt32(g);


            DataTable ds = db.dsquanan("SELECT Food.name AS [món ăn],BillInfo.count AS [số lượng],Food.price AS [giá],    (BillInfo.count * Food.price) AS [tổng tiền] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "' and  Bill.id = '" + h + "'");
            dataGridView1.DataSource = ds;

            DataTable dss = db.dsquanan("SELECT SUM(BillInfo.count * Food.price) AS sumtien FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "'  and  Bill.id= '" + h + "' ");
            textBox1.Text = dss.Rows[0]["sumtien"].ToString();
            
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
            ktratt = true;
          
            DataTable x = db.dsquanan("select Tablefood.id from Bill,Tablefood  where Bill.idTable = Tablefood.id and Tablefood.name  = N'" + cblayban.Text + "' and  Bill.id = '" +h+" '");
            MessageBox.Show(cblayban.Text);
            string g = x.Rows[0]["id"].ToString();
            int l = Convert.ToInt32(g);
            

            DataTable ds = db.dsquanan("SELECT Food.name AS [món ăn],BillInfo.count AS [số lượng],Food.price AS [giá],    (BillInfo.count * Food.price) AS [tổng tiền] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "' and  Bill.id = '"+h+"'");
            dataGridView1.DataSource = ds;

            DataTable dss = db.dsquanan("SELECT SUM(BillInfo.count * Food.price) AS sumtien FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.id = '" + l + "'  and  Bill.id= '"+h+"' ");
            textBox1.Text = dss.Rows[0]["sumtien"].ToString();
            Close();
           
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

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
