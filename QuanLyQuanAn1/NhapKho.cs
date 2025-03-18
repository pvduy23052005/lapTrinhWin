using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn1.DAO;
using QuanLyQuanAn1.DTO;

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
            frmKho frm =(frmKho)this.Owner;
            frm.LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
