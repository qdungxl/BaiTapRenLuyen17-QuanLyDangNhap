using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TAIKHOANBLL
    {
        TAIKHOANDAL TKDAL = new TAIKHOANDAL();
        List<TAIKHOAN> lsTK = new List<TAIKHOAN>(); //Lưu toàn bộ danh sách thông tin đăng nhập.
        private int SoLapNhapSai = 0;
        public TAIKHOANBLL()
        {
            LayDuLieu();
        }
        public void LayDuLieu()
        {
            lsTK = TKDAL.LayToanBoTaiKhoan();
        }
        /// <summary>
        /// Nếu đúng trả về 1, sai trả về 0.
        /// Nếu sai 3 lần sẽ trả về -1.
        /// </summary>
        /// <param name="taiKhoan"></param>
        /// <returns></returns>
        public int KiemTraDungSaiThongTinDangNhap(TAIKHOAN taiKhoan)
        {
            foreach(TAIKHOAN item in lsTK)
            {
                if (item.TenDangNhap==taiKhoan.TenDangNhap&&item.MatKhau==taiKhoan.MatKhau)
                {
                    SoLapNhapSai = 0;
                    return 1;
                }                   
            }
            SoLapNhapSai++;
            if (SoLapNhapSai < 3)
                return 0;
            else
                return -1;
        }
        public bool SuaMatKhauDangNhap(TAIKHOAN taiKhoan, string MatKhauMoi)
        {

            if (KiemTraDungSaiThongTinDangNhap(taiKhoan) == 1)
            {
                if(TKDAL.SuaMatKhauDangNhap(taiKhoan, MatKhauMoi))                   
                lsTK = TKDAL.LayToanBoTaiKhoan();
                return true;
            }
            return false;
        }
    }
}
