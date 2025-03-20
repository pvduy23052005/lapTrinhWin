using System;
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

namespace QuanLyQuanAn1
{
    public partial class NhapKho : Form
    {
        public NhapKho()
        {
            InitializeComponent();
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            LoadNhap();
        }
        void LoadNhap()
        {
            dataNhapKho.DataSource = NhapKhoDAO.Instance.LayDanhSachNhapKho();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataNhapKho.CurrentRow != null)
            {
                string idnhapkho = dataNhapKho.CurrentRow.Cells[0].Value.ToString();
                if (NhapKhoDAO.Instance.XoaNhapKho(int.Parse(idnhapkho)))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadNhap();
                }
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            int IdNguyenLieu = int.Parse(txtIDNguyenlieu.Text);
            string TenNl = txtTenNguyenLieu.Text;
            float soluong = float.Parse(txtSoLuong.Text);
            string DonViTinh = cbDonViTinh.Text;
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            string Date = dateNgayNhap.Value.ToString("MM/dd/yyyy");
            NhapKhoDAO.Instance.NhapKho(IdNguyenLieu, TenNl, soluong, DonViTinh, GiaNhap, Date);
            LoadNhap();
            frmkho frm = (frmkho)this.Owner;
            frm.LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIDNguyenlieu_TextChanged(object sender, EventArgs e)
        {
            txtTenNguyenLieu.Text = "";
            txtGiaNhap.Text = "";
            cbDonViTinh.Text = "";
            int IDNguyenLieu;
            if (int.TryParse(txtIDNguyenlieu.Text, out IDNguyenLieu))
            {
                int check = NhapKhoDAO.Instance.GetNguyenLieuId(IDNguyenLieu);
                if (check != -1)
                {
                    string query = "SELECT Tennguyenlieu, GIAnhap, DONVITINH FROM KHONGUYENLIEU WHERE ID = @check ";
                    string connectionStr = "Data Source=DESKTOP-7BJS2JF\\SQLEXPRESS;Initial Catalog=LeQuyDuong;Integrated Security=True";
                    SqlConnection sqlConnection = new SqlConnection(connectionStr);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@check", check);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTenNguyenLieu.Text = reader["tennguyenlieu"].ToString();
                        txtGiaNhap.Text = reader["GiaNhap"].ToString();
                        cbDonViTinh.Text = reader["donvitinh"].ToString();
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập id");
            }

        }

        private void dataNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataNhapKho.Rows[e.RowIndex];
                txtIDNhapKho.Text = row.Cells[0].Value.ToString();
                txtIDNguyenlieu.Text = row.Cells[1].Value.ToString();
                txtTenNguyenLieu.Text = row.Cells[2].Value.ToString();
                txtSoLuong.Text = row.Cells[3].Value.ToString();
                cbDonViTinh.Text = row.Cells[4].Value.ToString();
                txtGiaNhap.Text = row.Cells[5].Value.ToString();
                dateNgayNhap.Text = row.Cells[6].Value.ToString();
            }
        }
    }
}
