using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;

namespace QuanLyQuanAn1
{
    public partial class frmkho : Form
    {
        public frmkho()
        {
            InitializeComponent();
        }

        
        public void LoadData()
        {
            string query = "SELECT id, tenNguyenLieu, soLuong, donViTinh, giaNhap, ngayNhap FROM KhoNguyenLieu";
            DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(query);
           
        }

        private void frmkho_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void XoaFoodIter(int idFood)
        {
            string query = "delete from FoodIngredient where idFood = @idfood ";
            int xoa = DataProvider.Singleton.ExeCuteNon(query, new object[] { idFood });
        }
        void XoaFood(int IDnguyenlieu)
        {
            int IDFood = GetIdFood(IDnguyenlieu);
            XoaBillInfo(IDFood);
            string query = "delete from Food where id = @idfood ";
            int xoa = DataProvider.Singleton.ExeCuteNon(query, new object[] { IDFood });
        }
        void XoaBillInfo(int idFood)
        {
            string query = "delete from billinfo where idfood = @idfood ";
            int xoa = DataProvider.Singleton.ExeCuteNon(query, new object[] { idFood });
        }
        int GetIdFood(int IdNguyenLieu)
        {
            string query = "select idFood from FoodIngredient where idnguyenlieu = @idNguyenlieu ";
            object xoa = DataProvider.Singleton.ExeCuteS(query, new object[] { IdNguyenLieu });
            if (xoa == null) return -1;
            return Convert.ToInt32(xoa);
        }
        private void btnXoaKhoNguyenLieu_Click(object sender, EventArgs e)
        {
            
        }

        

        private void btnTimKiemKho_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiemKho.Text;
            string query = "select *from KhoNguyenLieu where tenNguyenLieu like @tenguyenlieu ";
            DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(query, new object[] { "%" + timkiem + "%" });
        }

        private void btnNhapKho_Click_1(object sender, EventArgs e)
        {
            NhapKho frm = new NhapKho();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnThemKhoNguyenLieu_Click_1(object sender, EventArgs e)
        {
            int check = 1;
            int id;
            string TenNguyenLieu = txtTenNguyenLieu.Text;
            float soluong;
            string DonViTinh = cbDonVi.Text;
            float GiaNhap;
            string Date = DateNgayNhap.Value.ToString("MM/dd/yyyy");
            if (!int.TryParse(txtIDNguyenLieu.Text, out id))
            {
                errorProvider1.SetError(txtIDNguyenLieu, "Vui lòng nhập ID hợp lệ!");
                check = 0;
            }
            if (TenNguyenLieu == "")
            {
                errorProvider1.SetError(txtTenNguyenLieu, "Vui lòng nhập tên nguyên liệu!");
                check = 0;
            }
            if (!float.TryParse(txtSoLuong.Text, out soluong))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng hợp lệ!");
                check = 0;
            }
            if (DonViTinh == "")
            {
                errorProvider1.SetError(cbDonVi, "Vui lòng nhập đơn vị hợp lệ!");
                check = 0;
            }
            if (!float.TryParse(txtGiaNhap.Text, out GiaNhap))
            {
                errorProvider1.SetError(txtGiaNhap, "Vui lòng nhập giá hợp lệ!");
                check = 0;
            }
            if (check == 0)
            {
                MessageBox.Show("Thêm không thành công");
                return;
            }
            try
            {

                string querycheck = "select count(*) from KhoNguyenLieu where id = @id ";
                int checkID = (int)DataProvider.Singleton.ExeCuteS(querycheck, new object[] { id });
                if (checkID == 0)
                {
                    string insert = "INSERT INTO KhoNguyenLieu (tenNguyenLieu, soLuong, donViTinh, giaNhap, ngayNhap) VALUES (@tennguyenlieu, @soluong, @donvitinh, @gianhap, @date)";
                    DataProvider.Singleton.ExeCuteNon(insert, new object[] { TenNguyenLieu, soluong, DonViTinh, GiaNhap, Date });
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatKho_Click_1(object sender, EventArgs e)
        {

            XuatKho xuatKho = new XuatKho();
            xuatKho.Owner = this;
            xuatKho.ShowDialog();
        }

        private void DataKho_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DataKho.SelectedRows.Count > 0)
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

        private void btnTimKiemKho_Click_1(object sender, EventArgs e)
        {
            string timkiem = txtTimKiemKho.Text;
            string query = "select *from khoNguyenLieu where tennguyenlieu like @ten ";
            DataKho.DataSource = DataProvider.Singleton.ExeCuteQuery(query , new object[] {"%" + timkiem +"%"});
        }

        private void btnXoaKhoNguyenLieu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DataKho.SelectedRows.Count > 0)
                {
                    int id = int.Parse(txtIDNguyenLieu.Text);

                    XoaFoodIter(id);
                    XoaFood(id);
                    XuatKhoDAO.Instance.XoaKho(id);
                    NhapKhoDAO.Instance.XoaKho(id);
                    XoaFoodIter(id);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            int check = 1;
            int id;
            string TenNguyenLieu = txtTenNguyenLieu.Text;
            float soluong;
            string DonViTinh = cbDonVi.Text;
            float GiaNhap;
            string Date = DateNgayNhap.Value.ToString("MM/dd/yyyy");
            if (!int.TryParse(txtIDNguyenLieu.Text, out id))
            {
                errorProvider1.SetError(txtIDNguyenLieu, "Vui lòng nhập ID hợp lệ!");
                check = 0;
            }
            if (TenNguyenLieu == "")
            {
                errorProvider1.SetError(txtTenNguyenLieu, "Vui lòng nhập tên nguyên liệu!");
                check = 0;
            }
            if (!float.TryParse(txtSoLuong.Text, out soluong))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng hợp lệ!");
                check = 0;
            }
            if (DonViTinh == "")
            {
                errorProvider1.SetError(cbDonVi, "Vui lòng nhập đơn vị hợp lệ!");
                check = 0;
            }
            if (!float.TryParse(txtGiaNhap.Text, out GiaNhap))
            {
                errorProvider1.SetError(txtGiaNhap, "Vui lòng nhập giá hợp lệ!");
                check = 0;
            }
            if (check == 0)
            {
                MessageBox.Show("Sửa không thành công");
                return;
            }
            try
            {

                string query = "UPDATE KhoNguyenLieu SET tenNguyenLieu = @TenNguyenLieu , soLuong = @SoLuong , donViTinh = @DonViTinh , giaNhap = @GiaNhap , ngayNhap = @NgayNhap WHERE id = @ID ";

                int result = DataProvider.Singleton.ExeCuteNon(query, new object[] { TenNguyenLieu, soluong, DonViTinh, GiaNhap, Date, id });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); 
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
