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
        public static bool ktra = false;
        public quanlihd()
        {
            InitializeComponent();
        }
        ketnoi db = new ketnoi();
        string layid,name;
        private void quanlihd_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            DataTable ds = db.dsquanan(" select distinct  Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày],Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id  ");

            dataGridView1.DataSource = ds;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            xuathoadon f = new xuathoadon();
            f.button1.Visible = false;
            ktra = true;//kiem tra trong xuathoa don
            f.textBox2.Text = layid;
            f.cblayban.Text = name;
            f.Show();
            
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           layid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable ds = db.dsquanan("SELECT distinct Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày], Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.name = N'" + comboBox1.Text + "' ");
            dataGridView1.DataSource = ds;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable ds = db.dsquanan(" select distinct  Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày],Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id  ");

            dataGridView1.DataSource = ds;
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            db.dsupdate("delete from BillInfo where BillInfo.idBill = '"+layid+"'");
            db.dsupdate("delete from Bill where Bill.id = '" + layid + "'");
            DataTable ds = db.dsquanan(" select distinct  Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày],Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id  ");

            dataGridView1.DataSource = ds;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                DataTable ds = db.dsquanan("SELECT distinct Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày], Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.name = N'" + comboBox1.Text + "' and Bill.status = 1 ");
                dataGridView1.DataSource = ds;
            }
            else
            {
                DataTable ds = db.dsquanan("SELECT distinct Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày], Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id and  Bill.status = 1");
                dataGridView1.DataSource = ds;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                DataTable ds = db.dsquanan("SELECT distinct Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày], Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id    AND Tablefood.name = N'" + comboBox1.Text + "' and Bill.status = 0 ");
                dataGridView1.DataSource = ds;
            }
            else
            {
                DataTable ds = db.dsquanan("SELECT distinct Bill.id as[idbill],tablefood.name as [tên bàn], Bill.gio as [giờ] , Bill.DateCheckIn as [ngày], Bill.status as [trạng thái] FROM    Tablefood, Bill, BillInfo, Food WHERE   Tablefood.id = Bill.idTable    AND BillInfo.idBill = Bill.id   AND BillInfo.idFood = Food.id  and Bill.status = 0 ");
                dataGridView1.DataSource = ds;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}
