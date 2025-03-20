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

namespace QuanLyQuanAn1
{
    public partial class XuatKho : Form
    {
        public XuatKho()
        {
            InitializeComponent();
        }

        private void numSoLuongXuat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void XuatKho_Load(object sender, EventArgs e)
        {
           LoadXuatKho();
            cbTenNguyenLieuXuat.DataSource = XuatKhoDAO.Instance.DataTenNguyenLieu();
            cbTenNguyenLieuXuat.DisplayMember = "tenNguyenlieu";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        void LoadXuatKho()
        {
            dataXuatKho.DataSource = XuatKhoDAO.Instance.LoadXuatKho();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string TenNl = cbTenNguyenLieuXuat.Text;
            float SoluongXuat;
            string ngayxuat = dateXuatKho.Value.ToString("MM/dd/yyyy");
            string ghichu = txtGhichu.Text;
            if(TenNl == "")
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu!");
                return;
            }
            if(!float.TryParse(txtSoLuongXuat.Text , out SoluongXuat))
            {
                MessageBox.Show("Vui lòng chọn số lượng xuất hợp lệ");
                return;
            }
            XuatKhoDAO.Instance.UpdateKhoNguyenLieu(TenNl, SoluongXuat);
            XuatKhoDAO.Instance.XuatKho(TenNl , SoluongXuat , ngayxuat , ghichu);
            LoadXuatKho();
            frmKho frm = (frmKho)this.Owner;
            frm.LoadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dataXuatKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataXuatKho.Rows[e.RowIndex];
                txtIDXuatKho.Text = row.Cells[0].Value.ToString();
                cbTenNguyenLieuXuat.Text = row.Cells[1].Value.ToString();
                txtSoLuongXuat.Text = row.Cells[2].Value.ToString();
                dateXuatKho.Text = row.Cells[3].Value.ToString();
                txtGhichu.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnSuaXuatKho_Click(object sender, EventArgs e)
        {
        //    float soluongcu= 0, soluongmoi;
        //    string TenNguyenlieu="";
        //    string ngayxuat = "";
        //    string ghichu = "";
        //    if(dataXuatKho.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dataXuatKho.SelectedRows[0]; 
        //        TenNguyenlieu = row.Cells[1].Value.ToString().Trim();
        //        soluongcu = float.Parse(row.Cells[2].Value.ToString());
        //        ngayxuat = row.Cells[3].Value.ToString();
        //        ghichu = row.Cells[4].Value.ToString();
        //    }
        //    soluongmoi =float.Parse( txtSoLuongXuat.Text);
        //    soluongmoi -= soluongcu;
        //    int IDNL = XuatKhoDAO.Instance.GetNguyenLieuId(TenNguyenlieu);
        //    XuatKhoDAO.Instance.UpdateKhoNguyenLieu(TenNguyenlieu, soluongcu);
        //    XuatKhoDAO.Instance.UpdateXuatKho( TenNguyenlieu, soluongmoi );
            
        //    XuatKhoDAO.Instance.XuatKho(TenNguyenlieu , soluongmoi , ngayxuat , ghichu);
        //    LoadXuatKho();
        //    frmKho frm = (frmKho)this.Owner;
        //    frm.LoadData();
        }

        private void btnXoaXuatKho_Click(object sender, EventArgs e)
        {
            if (dataXuatKho.CurrentRow != null)
            {
                string idnhapkho = dataXuatKho.CurrentRow.Cells[0].Value.ToString();
                if (XuatKhoDAO.Instance.XoaXuatKho(int.Parse(idnhapkho)))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadXuatKho();
                }
            }
        }
    }
}
