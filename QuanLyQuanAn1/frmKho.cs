using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;

namespace QuanLyQuanAn1
{
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            XuatKho xuatKho = new XuatKho();
            xuatKho.Owner = this;
            xuatKho.ShowDialog();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            NhapKho frm = new NhapKho();
            frm.Owner = this; 
            frm.ShowDialog();
        }

        private void btnThemKhoNguyenLieu_Click(object sender, EventArgs e)
        {
            int check = 1;
            int id ;
            string TenNguyenLieu = txtTenNguyenLieu.Text;
            float soluong;
            string DonViTinh = cbDonVi.Text;
            float GiaNhap;
            string Date = DateNgayNhap.Value.ToString("MM/dd/yyyy");
            if(!int.TryParse(txtIDNguyenLieu.Text ,out  id))
            {
                errorProvider1.SetError(txtIDNguyenLieu, "Vui lòng nhập ID hợp lệ!");
                check = 0;
            }
            if(TenNguyenLieu == "")
            {
                errorProvider1.SetError(txtTenNguyenLieu, "Vui lòng nhập tên nguyên liệu!");
                check = 0;
            }
            if(!float.TryParse(txtSoLuong.Text , out soluong))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng hợp lệ!");
                check = 0;
            }
            if(DonViTinh == "")
            {
                errorProvider1.SetError(cbDonVi, "Vui lòng nhập đơn vị hợp lệ!");
                check = 0;
            }
            if(!float.TryParse(txtGiaNhap.Text , out GiaNhap))
            {
                errorProvider1.SetError(txtGiaNhap, "Vui lòng nhập giá hợp lệ!");
                check = 0;
            }
            if(check == 0)
            {
                MessageBox.Show("Thêm không thành công");
                return;
            }
            try
            {
               
                string querycheck = "select count(*) from KhoNguyenLieu where id = @id ";
                int checkID = (int)DataProvider.Singleton.ExeCuteS(querycheck, new object[] { id });
                if(checkID == 0)
                {
                    string insert = "insert into KhoNguyenLieu values (   @tennguyenlieu , @soluong , @donvitinh , @gianhap , @date )";
                    DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(insert , new object[] {  TenNguyenLieu , soluong, DonViTinh , GiaNhap , Date }   );
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                if (checkID == 1)
                {
                    MessageBox.Show("Đã có ID");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string query = "select *from KhoNguyenLieu";
            DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(query);
        }

        private void btnXoaKhoNguyenLieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataKho.SelectedRows.Count > 0)
                {
                    int id = int.Parse(txtIDNguyenLieu.Text);
                    XuatKhoDAO.Instance.XoaKho(id);
                    NhapKhoDAO.Instance.XoaKho(id);
                    string delete = "delete from KhoNguyenLieu where id = @id  ";
                    DataProvider.Singleton.ExeCuteNon(delete, new object[] { id });
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng để xóa");
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataKho_SelectionChanged(object sender, EventArgs e)
        {
            if(DataKho.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DataKho.SelectedRows[0];
                txtIDNguyenLieu.Text = row.Cells[0].Value.ToString();
                txtTenNguyenLieu.Text = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();
                cbDonVi.Text = row.Cells[3].Value.ToString();
                txtGiaNhap.Text = row.Cells[4].Value.ToString();
                DateNgayNhap.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnTimKiemKho_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiemKho.Text;
            string query = "select *from KhoNguyenLieu where tenNguyenLieu like @tenguyenlieu ";
            DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(query , new object[] { "%" + timkiem + "%" });
        }
    }
}
