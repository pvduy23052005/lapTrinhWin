using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;
using QuanLyQuanAn1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyQuanAn1
{
    public partial class frmtable : Form
    {
        public frmtable()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccount frmaccount = new frmaccount();
            Hide();
            frmaccount.ShowDialog();
            Show();
           
        }


        // cap nhat danh sach ban . 
        public void LoadTable()
        {
            List<table> tableList = tableDAO.Instance.LoadTableList();

            
            // duyet qua cac tung doi tuong .   
            foreach (table item in tableList)
            {
                // tao ra 1 button de hien thi  . 
                Button btn = new Button()
                {
                    // xet thuoc tinh cao rong . 
                    Width = 95,
                    Height = 95
                };

                // thêm event Click . 
                btn.Click += btn_Click;
                //cho them1 the tag .
                btn.Tag = item;


                // tạo 1 ky tự cho button . 
                btn.Text = item.ID +  item.Name + Environment.NewLine + item.Status ;

                // ban nao trong thi may xanh . 
                if( item.Status == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                }else // ban nao ko con thi mau hồng . 
                {
                    btn.BackColor = Color.LightPink;
                }

                // them vao du lieu ra 
                 flowLayoutPanel1.Controls.Add(btn);
                
            }

        }

        public int getIdTable (int id )
        {
            return id;
        }
        // bat su kien hien thi hien thi danh sach mon an . 
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi ketNoi = new ketnoi();
                int tableId = ((sender as Button).Tag as table).ID;
                dataGridView1.Tag = (sender as Button).Tag;

                string query = "SELECT \r\n Food.name , \r\n    Food.price , \r\n    BillInfo.count FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '"+tableId + "' ; \r\n";
                
                DataTable table = ketNoi.dsquanan(query);

                // neu co mon moi hien thi . 
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.DataSource = table;

                }
                else
                {
                    MessageBox.Show("Không có món ăn cho bàn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex){
  
                MessageBox.Show(ex.Message);
            }  
        }

        


        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdoanhthu frmdoanhthu = new frmdoanhthu();
            frmdoanhthu.Show() ;
        }

        private void thứcĂnToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmthucan frmthucan = new frmthucan();
            frmthucan.Show();
        }


        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmlogin.userType == 1) // Chỉ cho quản trị viên mở form tài khoản
            {
                frmtaikhoan frm = new frmtaikhoan();
                frm.Show();
            }
            else if (frmlogin.userType == 0)
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadTable() { }
        private void doanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdanhmuc frmdanhmuc = new frmdanhmuc();
            frmdanhmuc.Show();
        }

        private void lsvthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            xuathoadon f = new xuathoadon();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndoiban_Click(object sender, EventArgs e)
        {

        }


        // btn them mon cho ban an . 
        private void btnthem_Click(object sender, EventArgs e)
        {
            // lay ra nhu .
            table table = dataGridView1.Tag as table;

            ketnoi ketNoi = new ketnoi();
            insertBill insertBill = new insertBill();
            insertFood insertFood = new insertFood();
            insertBillInfo insertBillInfo = new insertBillInfo(); 

            // goi ham insert bill .
            insertBill.InsertBill(table.ID);

            try
            {
                // lay ra id cua bill vua moi khi them moi mon .
                int idBill = insertBill.getIdBill();
                // lay ve ifFood tu ma minh chon . 
                int idFood = insertFood.getIdFood(cmbmon.SelectedItem.ToString());
                if (idFood != -1)
                {
                    // goi ham inerBillInfo .  
                    insertBillInfo.InsertBillInfo(idBill, idFood, 2);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món");
                }

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

            // load lai du lieu bang . 
             string query = "SELECT \r\n Food.name, \r\n    Food.price, \r\n    BillInfo.count, \r\n    Food.price * BillInfo.count AS [tổng tiền]\r\nFROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + table.ID + "' ; \r\n";
            DataTable loadData = ketNoi.dsquanan(query);
            dataGridView1.DataSource = loadData;
        }


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbmon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void frmtable_Load(object sender, EventArgs e)
        {
            label2.BackColor = Color.Transparent;
            LoadTable();
            // tao 1 class ket noi . 
            ketnoi ketNoi = new ketnoi();

            cmbmon.Items.Clear();

            string query = "select * from FoodCategory";

            DataTable kt = ketNoi.dsquanan(query);

            // duyet qua tung rao roi add .
            foreach (DataRow row in kt.Rows)
            {
                cmbloai.Items.Add(row["name"]);
            }
        }

        private void lblloai_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbloai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbloai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // lay ra id 
            string ten = cmbloai.SelectedItem.ToString(); 
            
            string query = "select * from Food where idCategory = (select id from FoodCategory where name = N'" + ten + "')";

            ketnoi ketNoi = new ketnoi(); 
            
            DataTable table = ketNoi.dsquanan(query);

            cmbmon.Items.Clear();

            // duyet qua tung rao roi add . .
            foreach ( DataRow row in table.Rows)
            {
                cmbmon.Items.Add(row["name"]);
            }

        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {   

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
