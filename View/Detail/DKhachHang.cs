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

namespace DoChoi.View.Detail
{
    public partial class DKhachHang : Form
    {
        private string maKH;
        public DKhachHang(string maKH)
        {
            this.maKH = maKH;
            InitializeComponent();
        }
        private void btPrimary_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string phone = tbPhone.Text;
            if (string.IsNullOrEmpty(maKH))
            {
                new DataBase().SelectData("exec InsertKH N'" + name + "'" + "," + "'" + phone + "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateKH '" + maKH + "'" + "," + "N'" + name + "'" + "," + "'" + phone + "'");

            }
            this.Dispose();
        }

        private void DKhachHang_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                this.Text = "Thêm mới khách hàng";
            }
            else
            {
                this.Text = "Cập nhật khách hàng";
                var r = new DataBase().Select("exec SelectKH '" + maKH + "'");
                tbCode.Text = r["MaKhachHang"].ToString();
                tbName.Text = r["TenKhachHang"].ToString();
                tbPhone.Text = r["SoDienThoai"].ToString();
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
            tbPhone.Text = string.Empty;
            tbCode.Focus();
            tbCode.Visible = false;
            label2.Visible = false;
            this.maKH = "";
            this.Text = "Thêm mới khách hàng";
        }
    }
}
