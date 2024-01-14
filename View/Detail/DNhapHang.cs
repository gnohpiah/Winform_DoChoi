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
    public partial class DNhapHang : Form
    {
        private string mahdn;
        public DNhapHang(string mahdn)
        {
            InitializeComponent();
            this.mahdn = mahdn;
        }

        public void loadDSSP()
        {
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList2.DataSource = new DataBase().SelectProcedure("SelectAllSP", lst);
        }

        private void DNhapHang_Load(object sender, EventArgs e)
        {
            loadDSSP();
            if (string.IsNullOrEmpty(mahdn))
            {
                this.Text = "Thêm mới loại sản phẩm";
            }
            else
            {
                this.Text = "Cập nhật loại sản phẩm";
                var r = new DataBase().Select("exec SelectHDN '" + mahdn + "'");
                tbCode.Text = r["SoHDN"].ToString();
                tbDate.Text = r["NgayNhap"].ToString();
                tbUser.Text = tbName.Text = r["TenNguoiQuanLy"].ToString();
                tbProdCode.Text = r["MaSanPham"].ToString();
                tbProdName.Text = r["TenSanPham"].ToString();
                tbProdAmount.Text = r["SoLuongNhap"].ToString();
                tbProdPrice.Text = r["DonGiaNhap"].ToString();
                cbCatalog.Text = r["TenLoaiMatHang"].ToString();
                cbSupplier.Text = r["TenNCC"].ToString();
                cbStatus.Text = r["TenTrangThai"].ToString();
                cbBrand.Text = r["ThuongHieu"].ToString();
            }
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
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbCode.Enabled = false;
            tbDate.Enabled = false;
            tbUser.Enabled =  tbName.Enabled = false;
            tbProdCode.Enabled = false;
            tbProdName.Enabled = false;
            tbProdAmount.Text = string.Empty;
            tbProdPrice.Text = string.Empty;
            cbCatalog.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            cbBrand.Enabled = false;
            tbName.Text = string.Empty;
            tbCode.Focus();
            tbCode.Enabled = false;
            this.mahdn = "";
            this.Text = "Thêm mới hóa đơn nhập";
        }

        private void btProdSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            if (string.IsNullOrEmpty(mahdn))
            {
                new DataBase().SelectData("exec InsertLoaiSP N'" + name + "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateLoaiSP '" + mahdn + "'" + "," + "N'" + name + "'");
            }
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new DSanPham("").ShowDialog();
        }

        private void dgvList2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var msp = dgvList2.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                new DSanPham(msp).ShowDialog();
                loadDSSP();
            }
        }
    }
}
