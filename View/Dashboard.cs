using DoChoi.View.Detail;
using DoChoi.View.List;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoChoi.View
{
    public partial class Dashboard : Form
    {
        DataBase db;
        TempAdmin tempAdmin;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void productItem_Click(object sender, EventArgs e)
        {
            LDanhSachSanPham dssp = new LDanhSachSanPham();
            dssp.Show(); 
        }

        private void classifyItem_Click(object sender, EventArgs e)
        {
            LDanhSachLoaiSanPham dslsp = new LDanhSachLoaiSanPham();
            dslsp.Show();
        }

        private void employeeItem_Click(object sender, EventArgs e)
        {
            LDanhSachNhanVien dsnv = new LDanhSachNhanVien();
            dsnv.Show();
        }

        private void customerItem_Click(object sender, EventArgs e)
        {
            LDanhSachKhachHang dskh = new LDanhSachKhachHang();
            dskh.Show();
        }

        private void supplierItem_Click(object sender, EventArgs e)
        {
            LDanhSachNhaCungCap dsncc = new LDanhSachNhaCungCap();
            dsncc.Show();
        }

        private void statusItem_Click(object sender, EventArgs e)
        {
            LDanhSachTinhTrang dstt = new LDanhSachTinhTrang();
            dstt.Show();
        }

        private void invoiceItem_Click(object sender, EventArgs e)
        {
            LDanhSachBanHang dsbh = new LDanhSachBanHang();
            dsbh.Show();
        }

        private void importItem_Click(object sender, EventArgs e)
        {
            LDanhSachNhapHang dsnh = new LDanhSachNhapHang();
            dsnh.Show();
        }

        private void tslImport_Click(object sender, EventArgs e)
        {
            DNhapHang dNhapHang = new DNhapHang(null);
            dNhapHang.Show();
        }

        private void tslInvoice_Click(object sender, EventArgs e)
        {
            DHoaDonBan dHoaDonBan = new DHoaDonBan();
            dHoaDonBan.Show();
        }

        private void tslChangePassword_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau();
            doimatkhau.Show();
        }

        private void tslLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kiểm tra nếu form đăng nhập được đóng bởi người dùng
            if (((DangNhap)sender).DialogResult != DialogResult.OK)
            {
                // Đóng form "Dashboard"
                this.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        { 
            var dangNhap = new DangNhap();
            dangNhap.FormClosed += DangNhap_FormClosed;
            dangNhap.ShowDialog();
            tslUsername.Text = dangNhap.getUserName();
        }

    }
}
