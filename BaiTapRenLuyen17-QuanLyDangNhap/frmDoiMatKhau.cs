using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace BaiTapRenLuyen17_QuanLyDangNhap
{
    public partial class frmDoiMatKhau : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public TAIKHOAN TKhoan = null;
        public TAIKHOANBLL TKBLL = null;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinNhap() == false) return;
            TKhoan.MatKhau = txtMatKhauCu.Text.Trim();
            string MatKhauMoi = "";
            if (txtMatKhauMoi.Text == txtXacNhanMatKhauMoi.Text)
                MatKhauMoi = txtMatKhauMoi.Text;
            if (TKBLL.SuaMatKhauDangNhap(TKhoan, MatKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công.");
                DialogResult = DialogResult.OK;
            }                
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại.");
                DialogResult = DialogResult.OK;
            }
        }
        private bool KiemTraThongTinNhap()
        {
            int kq = 0;
            errorProvider1.Clear();
            if (txtMatKhauCu.Text == "")
            {
                errorProvider1.SetError(txtMatKhauCu, "Hãy nhập mật khẩu hiện tại");
                kq++;
            }               
            if (txtMatKhauMoi.Text == "")
            {
                errorProvider1.SetError(txtMatKhauMoi, "Hãy nhập mật khẩu mới");
                kq++;
            }              
            if(txtXacNhanMatKhauMoi.Text == "")
            {
                errorProvider1.SetError(txtXacNhanMatKhauMoi, "Hãy nhập lại mật khẩu trùng với mật khẩu mới.");
                kq++;
            }
            if (kq == 0)
                return true;
            return false;
        }

        private void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = TKhoan.TenDangNhap;
            txtTenDangNhap.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
