using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoChoi.View.Detail
{
    public partial class DSanPham : Form
    {
        private string maSP;
        public DSanPham(string maSP)
        {
            InitializeComponent();
            this.maSP = maSP;
        }

        private void DSanPham_Load(object sender, EventArgs e)
        {
            cbCatalog.DataSource = new DataBase().SelectData("Select * from tLoaiMatHang");
            cbCatalog.DisplayMember = "TenLoaiMatHang";
            cbSupplier.DataSource = new DataBase().SelectData("Select * from tNhaCungCap");
            cbSupplier.DisplayMember = "TenNCC";
            cbStatus.DataSource = new DataBase().SelectData("Select * from tTrangThai");
            cbStatus.DisplayMember = "TenTrangThai";
            cbBrand.DataSource = new DataBase().SelectData("Select * from tSanPham");
            cbBrand.DisplayMember = "ThuongHieu";
            cbGender.DataSource = new DataBase().SelectData("Select * from tSanPham");
            cbGender.DisplayMember = "GioiTinh";
            if (!string.IsNullOrEmpty(maSP)) 
            {
                this.Text = "Cập nhật sản phẩm";
                var r = new DataBase().Select("exec SelectSP '" + maSP + "'");
                tbCode.Text = r["MaSanPham"].ToString();
                tbName.Text = r["TenSanPham"].ToString();
                cbCatalog.Text = r["MatHang"].ToString();
                cbSupplier.Text = r["TenNCC"].ToString();
                tbAmount.Text = r["SoLuong"].ToString();
                tbPrice.Text = r["DonGiaBan"].ToString();
                cbStatus.Text = r["TrangThai"].ToString();
                cbBrand.Text = r["ThuongHieu"].ToString();
                cbGender.Text = r["GioiTinh"].ToString();
            }
            else
            {
                this.Text = "Thêm sản phẩm mới";
            }
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            string code = tbCode.Text;
            string name = tbName.Text;
            string loaimh = cbCatalog.Text;
            string nhacc = cbSupplier.Text;
            string soluong = tbAmount.Text;
            string dongiaban = tbPrice.Text;
            string trangthai = cbStatus.Text;
            string anh = tbImages.Text;
            string thuonghieu = cbBrand.Text;
            string gioitinh = cbGender.Text;
            if(!string.IsNullOrEmpty(maSP)) { }
            {
                new DataBase().SelectData("exec UpdateSP '" + code + "'" + "," +  "N'" + name + "'" + "," + "N'" + gioitinh + "'" + "," +  "N'" + loaimh + "'" + "," 
                    + "N'" + trangthai + "'" + "," +  "'" + anh+ "'" + "," + "N'" + thuonghieu + "'" + "," +  "'" + soluong + "'" + "," + "'" +
                    dongiaban + "'" + "," + "'" +  nhacc + "'");
            }
            this.Dispose();
        }

        private void btDanger_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;
            tbName.Text = string.Empty;
            cbCatalog.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            tbAmount.Text = string.Empty;
            tbPrice.Text = string.Empty;
            cbStatus.SelectedIndex = -1;
            tbImages.Text = string.Empty;
            cbBrand.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            tbCode.Focus();
        }
    }
}
