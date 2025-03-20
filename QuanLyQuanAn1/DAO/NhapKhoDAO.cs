using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyQuanAn1.DAO
{
    public class NhapKhoDAO
    {
        private static NhapKhoDAO instance;

        public static NhapKhoDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhapKhoDAO();
                return instance;
            }
            private set => instance = value;
        }

       
        public int GetNguyenLieuId(int idN)
        {
            string query = "SELECT id FROM KhoNguyenLieu WHERE id = @idN ";
            object result = DataProvider.Singleton.ExeCuteS(query, new object[] { idN });
            if(result == null)
            {
                return -1;
            }
            return (int)result;
        }


        public DataTable LayDanhSachNhapKho()
        {
            string query = @"
                select nhapkho.id , khonguyenlieu.id as idkhonguyenlieu , khonguyenlieu.tenNguyenLieu , nhapkho.soluongNhap , khonguyenlieu.donViTinh , nhapkho.gianhap , nhapkho.ngaynhap from nhapkho , khonguyenlieu where nhapkho.idNguyenLieu = khonguyenlieu.id ";

            return DataProvider.Singleton.ExeCuteQuery(query);
        }

        public void UpdateKhoNguyenLieu(int idNguyenLieu, float soLuong)
        {

            string query = "UPDATE KhoNguyenLieu SET soLuong = soLuong + @soLuong WHERE id = @idNguyenLieu ";
            DataProvider.Singleton.ExeCuteNon(query, new object[] { soLuong, idNguyenLieu });


        }

        public int InsertKhoNguyenLieu(string tenNL, float soLuong, string donViTinh, float giaNhap, string ngayNhap)
        {
            string query = "INSERT INTO KhoNguyenLieu (tenNguyenLieu, soLuong, donViTinh, giaNhap, ngayNhap) VALUES ( @tenNL , @soLuong , @donViTinh , @giaNhap , @ngayNhap ); SELECT SCOPE_IDENTITY()";

            object result = DataProvider.Singleton.ExeCuteS(query, new object[] { tenNL, soLuong, donViTinh, giaNhap, ngayNhap });
            if (result == null || result == DBNull.Value)
                return -1;
            return Convert.ToInt32(result);

        }

        public void InsertNhapKho(int idNguyenLieu, float soLuong, float giaNhap, string ngayNhap)
        {

            string query = "INSERT INTO NhapKho (idNguyenLieu, soLuongNhap, giaNhap, ngayNhap) VALUES ( @idNguyenLieu , @soLuong , @giaNhap , @ngayNhap )";
            DataProvider.Singleton.ExeCuteNon(query , new object[] {idNguyenLieu , soLuong , giaNhap , ngayNhap });

        }
       
        public void NhapKho(int idN, string tenNL, float soLuong, string donViTinh, float giaNhap, string  ngayNhap)
        {
           
                try
                {
                    int idNguyenLieu = GetNguyenLieuId(idN);

                    if (idNguyenLieu > 0)
                    {
                        UpdateKhoNguyenLieu(idNguyenLieu, soLuong);
                    }
                    else
                    {
                        idNguyenLieu = InsertKhoNguyenLieu(tenNL, soLuong, donViTinh, giaNhap, ngayNhap);
                    }

                    InsertNhapKho(idNguyenLieu, soLuong, giaNhap, ngayNhap);

                    MessageBox.Show("Nhập kho thành công");
                
            }
                catch (Exception ex)
                {
                   
                   MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        public bool XoaNhapKho(int id)
        {
            string query = "DELETE FROM NhapKho WHERE id = @id ";
            int result = DataProvider.Singleton.ExeCuteNon(query, new object[] { id });
            return result > 0;
        }
        public bool XoaKho(int id)
        {

            string query = "DELETE FROM NhapKho WHERE idnguyenlieu = @id ";
            int result = DataProvider.Singleton.ExeCuteNon(query, new object[] { id });
            return result > 0;
        }
       


    }
}
