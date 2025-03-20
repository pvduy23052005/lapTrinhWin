using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1.DAO
{
   public class XuatKhoDAO
    {

        private static XuatKhoDAO instance;

        public static XuatKhoDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatKhoDAO();
                return instance;
            }
            set => instance = value;
        }
        public int GetNguyenLieuId(string TenNguyenLieu)
        {
            string query = "SELECT id FROM KhoNguyenLieu WHERE tenNguyenLieu = @tennguyenlieu ";
            object result = DataProvider.Singleton.ExeCuteS(query, new object[] { TenNguyenLieu });
            if (result == null || result == DBNull.Value)
            {
                return -1;
            }
            return (int)result;
        }

        public DataTable DataTenNguyenLieu()
        {
            DataTable dt = new DataTable();
            string query = "select tenNguyenLieu from KhoNguyenLieu";
            dt = DataProvider.Singleton.ExeCuteQuery(query);
            return dt;
        }
        public DataTable LoadXuatKho()
        {
            DataTable data = new DataTable();
            string query = "select XuatKho.id , KhoNguyenLieu.tenNguyenLieu , XuatKho.soLuongXuat , XuatKho.ngayXuat , XuatKho.ghichu from XuatKho , KhoNguyenLieu  where XuatKho.idNguyenLieu = KhoNguyenLieu.id";
            data = DataProvider.Singleton.ExeCuteQuery(query);
            return data;
        }
        public void UpdateKhoNguyenLieu(string ten, float soluong)
        {
            string query = "UPDATE KhoNguyenLieu SET soLuong = soLuong - @soLuong WHERE tenNguyenLieu = @TenNguyenLieu ";
            DataProvider.Singleton.ExeCuteNon(query, new object[] { soluong, ten });

        }

        public void InsertXuatKho(int idNguyenLieu, float soLuongxuat, string ngayxuat, string ghichu)
        {

            if (idNguyenLieu == -1)
            {
                MessageBox.Show("Lỗi: Không tìm thấy nguyên liệu trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO XuatKho (idNguyenLieu, soLuongXuat, ngayxuat, ghichu) VALUES ( @idNguyenLieu , @soLuongxuat , @ngayxuat , @ghichu )";
            DataProvider.Singleton.ExeCuteNon(query, new object[] { idNguyenLieu, soLuongxuat, ngayxuat, ghichu });
        }
        public void UpdateXuatKho(string TenNl, float soluongxuat)
        {
            int idNguyenLieu = GetNguyenLieuId(TenNl);
            string query = "update  xuatkho set soluongxuat = @soluongxuat where idnguyenlieu = @idnguyenlieu ";
            DataProvider.Singleton.ExeCuteNon(query, new object[] { idNguyenLieu, soluongxuat });
        }
        public void XuatKho(string TenNl, float SoLuongXuat, string ngayxuat, string ghichu)
        {
            try
            {
                int idNguyenLieu = GetNguyenLieuId(TenNl);


                UpdateKhoNguyenLieu(TenNl, SoLuongXuat);



                InsertXuatKho(idNguyenLieu, SoLuongXuat, ngayxuat, ghichu);

                MessageBox.Show("Xuất kho thành công");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public bool XoaXuatKho(int id)
        {
            string query = "DELETE FROM XuatKho WHERE id = @id ";
            int result = DataProvider.Singleton.ExeCuteNon(query, new object[] { id });
            return result > 0;
        }
        public bool XoaKho(int id)
        {

            string query = "DELETE FROM XuatKho WHERE idnguyenlieu = @id ";
            int result = DataProvider.Singleton.ExeCuteNon(query, new object[] { id });
            return result > 0;
        }
    }
}
