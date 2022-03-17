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
    public partial class frmMain : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public TAIKHOANBLL TKBLL = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            TKBLL = new TAIKHOANBLL();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TAIKHOAN tk = new TAIKHOAN();
            tk.TenDangNhap = txtUser.Text;
            tk.MatKhau = txtPass.Text;
            int kiemtra = TKBLL.KiemTraDungSaiThongTinDangNhap(tk);      
            if (kiemtra==-1)
            {
                MessageBox.Show("Bạn đã nhập sai 3 lần.");
                Close();
            }
            if (kiemtra == 1)
            {
                this.Hide();
                frmDoiMatKhau frm = new frmDoiMatKhau();
                frm.TKhoan = tk;
                frm.TKBLL = TKBLL;
                frm.ShowDialog();
                frm = null;
                this.Show();
                txtUser.Text = "";
                txtPass.Text = "";
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng.", "Thông báo");
                txtUser.Text = "";
                txtPass.Text = "";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
                       
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
