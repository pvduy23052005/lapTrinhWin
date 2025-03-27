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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.VisualStyles;
using Button = System.Windows.Forms.Button;
using System.Text.RegularExpressions;

namespace QuanLyQuanAn1
{
    public partial class frmtable : Form
    {
        public frmtable()
        {
            InitializeComponent();
        }
        ketnoi ketNoi = new ketnoi();
        insertBill insertBill = new insertBill();
        insertFood insertFood = new insertFood();
        insertBillInfo insertBillInfo = new insertBillInfo();
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
        public Color luumauxanh;
        public Color luumaunhan;


        // cap nhat danh sach ban . 
        public void LoadTable()
        {
            List<table> tableList = tableDAO.Instance.LoadTableList();

            
            // duyet qua cac tung doi tuong .   
            foreach (table item in tableList)
            {
                // tao ra 1 button de hien thi  . 
                Button btn = new System.Windows.Forms.Button()
                {
                    // xet thuoc tinh cao rong . 
                    Width = 95,
                    Height = 95
                };

 
                btn.Click += btn_Click;
                
                //cho them1 the tag .
                btn.Tag = item;


                string query = "SELECT Billinfo.id , Tablefood.id , Bill.id, \r\n Food.name , \r\n    Food.price , \r\n   BillInfo.count ,Food.price * BillInfo.count as [Tổng tiền]  FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + item.ID + "'and Bill.gio IS NULL ; \r\n";
                DataTable data = ketNoi.dsquanan(query);

                tableStatus tableStatus = new tableStatus();
                if ( data.Rows.Count > 0)
                {
                    btn.Text = item.Name + "\n (Có người)";
                    btn.BackColor = Color.LightPink;
                    tableStatus.ChangeStatus(item.ID, "coNguoi");
                }
                else
                {
                    btn.Text = item.Name + "\n(Trống)";
                    btn.BackColor = Color.LightGreen;
                    tableStatus.ChangeStatus(item.ID, "Trong");
                }


                //btn.BackColor = Color.LightGreen;

                luumauxanh = btn.BackColor;

                // them vao du lieu ra 
                flowLayoutPanel1.Controls.Add(btn);

                
            }

        }
        public Button luu = null;
        // bat su kien hien thi hien thi danh sach mon an . 
        private void btn_Click(object sender, EventArgs e)
        {

            int tableId = ((sender as Button).Tag as table).ID;
            string nameTable = ((sender as Button).Tag as table).Name;
            try
            {

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                     if(control is Button btn)
                    {
                        if(Regex.IsMatch(btn.Text , "(Trống)"))
                        {
                            btn.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btn.BackColor = Color.LightPink;
                        }
                    }
                }

                // Lấy button được nhấp và đổi màu sang hồng
                Button clickedButton = (Button)sender;
                if (clickedButton != null)
                {
                    

                     clickedButton.BackColor = Color.Orange;



                }


               


                //  MessageBox.Show(tableId.ToString());
                dataGridView1.Tag = (sender as Button).Tag;
                string query = "SELECT Billinfo.id , Tablefood.id , Bill.id, \r\n Food.name , \r\n    Food.price , \r\n   BillInfo.count ,Food.price * BillInfo.count as [Tổng tiền]  FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + tableId + "'and Bill.gio IS NULL ; \r\n";
                DataTable table = ketNoi.dsquanan(query);

                dataGridView1.DataSource = table;

                
                if (dataGridView1.Columns.Count >= 3)   
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            
        }

        private void lsvthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnThanhtoan_Click(object sender, EventArgs e)
        {



            table table = dataGridView1.Tag as table;


            if (table.Status != "Trống")
            {
                if (table == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idBill = insertBill.GetCurrentBillId(table.ID);

                // Mở form xuất hóa đơn
                xuathoadon f = new xuathoadon();
                DataTable travename = ketNoi.dsquanan("select name from Tablefood where id = '" + table.ID + "'");
                string layname = travename.Rows[0]["name"].ToString();
                f.cblayban.Text = layname;

                f.ShowDialog();
                table.Status = xuathoadon.laystatic;


                string query = "SELECT \r\n Food.name , \r\n    Food.price , \r\n    BillInfo.count FROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + table.ID + "' and Bill.gio IS NULL ; \r\n";
                DataTable dt = ketNoi.dsquanan(query);
                dataGridView1.DataSource = dt;
                if (xuathoadon.ktratt == true)
                {
                    insertBill.InsertBill(table.ID);

                    xuathoadon.ktratt = false;
                }
                flowLayoutPanel1.Controls.Clear();
                LoadTable();

            }
            else
            {
                MessageBox.Show("Bàn không có người, không thể thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndoiban_Click(object sender, EventArgs e)
        {

        }
        void CapNhatKho()
        {
            string Mon = cmbmon.Text;
            int idFood = FoodDAO.Instance.GetIDFood(Mon);
            int soLuong = (int)soLuongMon.Value;

           
            DataTable nguyenLieuList = GetListNguyenLieuByFood(idFood);

            foreach (DataRow row in nguyenLieuList.Rows)
            {
                int idNguyenLieu = Convert.ToInt32(row[0]);
                float soLuongCan = Convert.ToSingle(row[1]);

                
                float khoiluongthucan = soLuongCan * soLuong;

                
                if (!FoodDAO.Instance.KiemTraKho(idFood, soLuong))
                {
                    MessageBox.Show("Không đủ nguyên liệu trong kho", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool result = FoodDAO.Instance.CapNhatKho(idNguyenLieu, khoiluongthucan);

                
                XuatKhoDAO.Instance.InsertXuatKho(idNguyenLieu, khoiluongthucan, DateTime.Now.ToString(), "Dùng để cho " + Mon + " Ngày " + DateTime.Now.ToString());
            }
        }

        public int GetSoLuongCanChoMon(int IdFood)
        {
            string query = "select soluongcan from FoodIngredient where idNguyenLieu = @idnguyenlieu ";
            object result = DataProvider.Singleton.ExeCuteS(query, new object[] { IdFood });
            if (result == null)
            {
                return -1;
            }
            return Convert.ToInt32(result);
        }

        // btn them mon cho ban an . 
        private void btnthem_Click(object sender, EventArgs e)
        {
            // lay ra nhu .
            table table = dataGridView1.Tag as table;

           if(table == null)
            {
                MessageBox.Show("vui lòng chọn bàn để thêm");
                return;
            }
        
         
            // goi ham insert bill .
            //   insertBill.InsertBill(table.ID);

            try
            {



                int idBill = insertBill.GetCurrentBillId(table.ID);
              //  MessageBox.Show(idBill.ToString());
                int idFood = insertFood.getIdFood(cmbmon.SelectedItem.ToString());

                int so_luong_mon = Convert.ToInt32( soLuongMon.Value);
                
                if (idFood != -1)
                {


                    //if (!FoodDAO.Instance.KiemTraKho(idFood , so_luong_mon))
                    //{
                    //    MessageBox.Show("Không đủ nguyên liệu trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    cmbloai.Text = "";
                    //    cmbmon.Text = "";
                    //    return;
                    //}


                    //CapNhatKho();

                    // goi ham ínertBil

                    //if (insertBillInfo.CheckMonBillInfo( idBill  , idFood) == false)
                    //{
                    //    insertBillInfo.UpdateCountBillInfo();
                    //}else
                    //{
                    //    insertBillInfo.InsertBillInfo(idBill, idFood, so_luong_mon);
                    //}


                    insertBillInfo.InsertBillInfo(idBill, idFood, so_luong_mon);



                    //frmkho frm = (frmkho)this.Owner;
                    //frm.LoadData();

                    soLuongMon.Value = 1;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món");
                }

            }
            
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }


            //  MessageBox.Show(table.ID.ToString());
            // load lai du lieu bang . 
            string query = "SELECT \r\n BillInfo.id ,Food.name, \r\n    Food.price, \r\n    BillInfo.count, \r\n    Food.price * BillInfo.count AS [tổng tiền]\r\nFROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + table.ID + "' and Bill.gio IS NULL ; \r\n";
            DataTable loadData = ketNoi.dsquanan(query);
            dataGridView1.DataSource = loadData;
            //dataGridView1.Columns[0].Visible = false;
            flowLayoutPanel1.Controls.Clear();
            LoadTable();
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
            ketNoi.dsupdate("update tableFood set status = N'đầy' where id = 1 ");
            LoadTable();

            
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

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkho frmkho = new frmkho();
            
            frmkho.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qunalikhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlihd f = new quanlihd();
            DataTable dt = ketNoi.dsquanan("select * from Tablefood");
            f.comboBox1.DataSource = dt;
            f.comboBox1.DisplayMember = "name";
            f.comboBox1.ValueMember = "id";
            this.Hide();
            f.ShowDialog();
            this.Show();

        }
        private void doimau(object sender, EventArgs e)
        {
          
        }

        private void roimau(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

  

        // Tinh nang xoa . 
        string layid;
        private void button1_Click(object sender, EventArgs e)
        {
            table table = dataGridView1.Tag as table;

            if (table == null)
            {
                MessageBox.Show("vui lòng chọn bàn để thêm");
                return;
            }
            int idFood = GetIDNguyenLieu(Convert.ToInt32(layid));
            DataTable nguyenLieuList = GetListNguyenLieuByFood(idFood);

            // cap nhật nguyên liệu 
            foreach (DataRow row in nguyenLieuList.Rows)
            {
                int idNguyenLieu = Convert.ToInt32(row[0]);
                float soLuongCan = Convert.ToSingle(row[1]);

                // Tính tổng số lượng nguyên liệu cần cập nhật
                float soluong = GetCountFoodBIllInfo(Convert.ToInt32(layid)) * soLuongCan;
                Console.WriteLine(soluong);

                // Cập nhật lại kho nguyên liệu
                NhapKhoDAO.Instance.UpdateKhoNguyenLieu(idNguyenLieu, soluong);
            }


            ketNoi.dsupdate("delete from BillInfo where BillInfo.id = '" + Convert.ToInt32(layid) + "'");
            // load lai du lieu bang . 
            string query = "SELECT BillInfo.id ,\r\n Food.name, \r\n    Food.price, \r\n    BillInfo.count, \r\n    Food.price * BillInfo.count AS [tổng tiền]\r\nFROM \r\n    BillInfo\r\nINNER JOIN \r\n    Bill ON BillInfo.idBill = Bill.id\r\nINNER JOIN \r\n    Food ON BillInfo.idFood = Food.id\r\nINNER JOIN \r\n    Tablefood ON Bill.idTable = Tablefood.id\r\nWHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = '" + table.ID + "' and Bill.gio IS NULL ; \r\n";
            DataTable loadData = ketNoi.dsquanan(query);
            dataGridView1.DataSource = loadData;

            // load lai bàn ghi thêm món . 
            flowLayoutPanel1.Controls.Clear();
            LoadTable();    
            dataGridView1.Columns[0].Visible = false;
        }
        DataTable GetListNguyenLieuByFood(int idFood)
        {
            string query = "SELECT idNguyenLieu, soLuongCan FROM FoodIngredient WHERE idFood = @idfood ";
            DataTable dt = DataProvider.Singleton.ExeCuteQuery(query, new object[] { idFood });
            return dt;
        }
        int GetIdFoodBIllInfo(int idbillinfo)
        {
            string query = "select idfood from billinfo where id = @id ";
            object IdFood = DataProvider.Singleton.ExeCuteS(query, new object[] { idbillinfo });
            if (IdFood == null)
            {
                return -1;
            }
           
            return Convert.ToInt32(IdFood);
        }
        int GetIDNguyenLieu(int Idbillinfo)
        {
            int IdFood = GetIdFoodBIllInfo(Idbillinfo);
            string query = "select idNguyenLieu from FoodIngredient where idfood = @idfood ";
            object IdNguyenLieu = DataProvider.Singleton.ExeCuteS(query , new object[] { IdFood });
            if(IdNguyenLieu == null) { return -1; }
            return Convert.ToInt32(IdNguyenLieu);
        }
        float GetSoLuongCan(int IdBillinfo)
        {
            int IdFood = GetIdFoodBIllInfo(IdBillinfo);
            string query = "select soluongcan from FoodIngredient where idfood = @idfood ";
            object soluongcan = DataProvider.Singleton.ExeCuteS(query , new object[] {IdFood});
            if(soluongcan == null) return -1;
            return Convert.ToSingle(soluongcan);
        }
        int GetCountFoodBIllInfo(int idbillinfo)
        {
            string query = "select [count] from billinfo where id = @id ";
            object count = DataProvider.Singleton.ExeCuteS(query, new object[] { idbillinfo });
            if (count == null)
            {
                return -1;
            }
            

            return Convert.ToInt32(count);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            layid = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }
    }
}
