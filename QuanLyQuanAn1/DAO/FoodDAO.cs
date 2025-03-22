using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return instance;
            }
            set => instance = value; 
        }


       

        public bool KiemTraKho(int idFood, int soLuongDat)
        {
            try
            {
                string query = @"
                SELECT MIN(k.soLuong - (fi.soLuongCan * @soLuongDat ))
                FROM KhoNguyenLieu k
                JOIN FoodIngredient fi ON k.id = fi.idNguyenLieu
                WHERE fi.idFood = @idFood ";

                object result = DataProvider.Singleton.ExeCuteS(query, new object[] { idFood, soLuongDat });

                // Kiểm tra nếu kết quả null hoặc nhỏ hơn 0
                if (result == null || Convert.ToInt32(result) < 0)
                {
                    return false; // Không đủ nguyên liệu
                }
                return true; // Nguyên liệu đủ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool CapNhatKho(int idFood, int soLuongDat)
        {
            
                try
                {

                string query = @"
                        UPDATE k
                        SET k.soLuong = k.soLuong - CAST(fi.soLuongCan AS FLOAT) * @soLuongDat 
                        FROM KhoNguyenLieu k
                        JOIN FoodIngredient fi ON k.id = fi.idNguyenLieu
                        WHERE fi.idFood = @idFood ";


                DataProvider.Singleton.ExeCuteNon(query , new object[] {idFood, soLuongDat});
                  return true;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        


        public int GetIDFood(string TenMon)
        {
            string query = " select id from  Food where name = @name ";
            object result = DataProvider.Singleton.ExeCuteS(query , new object[] { TenMon });
            if(result == null)
            {
                return -1;
            }
            return Convert.ToInt32(result);
        }
    }
}
