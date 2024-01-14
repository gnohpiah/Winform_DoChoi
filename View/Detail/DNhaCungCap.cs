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
    public partial class DNhaCungCap : Form
    {
        private string maNCC;
        public DNhaCungCap(string maNCC)
        {
            InitializeComponent();
            this.maNCC = maNCC;
        }

        private void DNhaCungCap_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNCC))
            {
                this.Text = "Thêm mới Nhà cung cấp";
            }
            else
            {
                this.Text = "Cập nhật Nhà cung cấp";
                var r = new DataBase().Select("exec SelectNCC '" + maNCC + "'");
                tbCode.Text = r["MaNCC"].ToString();
                tbName.Text = r["TenNCC"].ToString();
                tbEmail.Text = r["Email"].ToString();
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
            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbCode.Focus();
            tbCode.Visible = false;
            label2.Visible = false;
            this.maNCC = "";
            this.Text = "Thêm mới khách hàng";
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;
            if (string.IsNullOrEmpty(maNCC))
            {
                new DataBase().SelectData("exec InsertNCC N'" + name + "'" + "," +  "N'" + email + "'" + "," + "'" + phone + "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateNCC" + maNCC + "," +  "N'" + name + "'" + "," + "N'" + email + "'" + "," + "'" + phone + "'");

            }
            this.Dispose();
        }
    }
}
