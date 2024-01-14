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
    public partial class DLoaiSanPham : Form
    {
        string maLoaiSP;
        public DLoaiSanPham(string maLoaiSP)
        {
            InitializeComponent();
            this.maLoaiSP = maLoaiSP;
        }

        private void DLoaiSanPham_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maLoaiSP))
            {
                this.Text = "Thêm mới loại sản phẩm";
            }
            else
            {
                this.Text = "Cập nhật loại sản phẩm";
                var r = new DataBase().Select("exec SelectLoaiSP '" + maLoaiSP + "'");
                tbCode.Text = r["MaLoaiMatHang"].ToString();
                tbName.Text = r["TenLoaiMatHang"].ToString();
            }
        }

        private void btDanger_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;
            tbName.Text = string.Empty;
            tbCode.Focus();
            tbCode.Visible = false;
            label2.Visible = false;
            this.maLoaiSP = "";
            this.Text = "Thêm mới khách hàng";
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            if (string.IsNullOrEmpty(maLoaiSP))
            {
                new DataBase().SelectData("exec InsertLoaiSP N'" + name + "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateLoaiSP '" + maLoaiSP + "'" + "," + "N'" + name + "'");
            }
            this.Dispose();
        }
    }
}
