using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn1.DTO
{
    public class NhapKhoDTO
    {

        public int Id { get; set; }
        public int IdNguyenLieu { get; set; }
        public float SoLuongNhap { get; set; }
        public DateTime NgayNhap { get; set; } = DateTime.Now;
        public float GiaNhap { get; set; }

        
        




        public NhapKhoDTO(int idNguyenLieu, float soLuongNhap, float giaNhap, DateTime ngayNhap)
        {
            this.IdNguyenLieu = idNguyenLieu;
            this.SoLuongNhap = soLuongNhap;
            this.GiaNhap = giaNhap;
            this.NgayNhap = ngayNhap;

        }
    }
}
