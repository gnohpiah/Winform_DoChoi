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
    public partial class DNhanVien : Form
    {
        private string manv;
        public DNhanVien(string manv)
        {
            this.manv = manv;
            InitializeComponent();
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string phone = tbPhone.Text;
            string address = tbAddress.Text;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(manv))
            {
                new DataBase().SelectData("exec InsertNV N'" + name + "'" + "," + "N'" + address + "'" + "," + "'" + phone+ "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateNV '" + manv + "'" + "," +  "N'" + name + "'" + "," + "N'" + address + "'" + "," + "'" + phone+ "'");

            }
            this.Dispose();
        }

        private void DNhanVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(manv))
            {
                this.Text = "Thêm mới Nhân viên";
            }
            else
            {
                this.Text = "Cập nhật Nhân viên";
                var r = new DataBase().Select("exec SelectNV '" + manv + "'");
                tbCode.Text = r["MaNhanVien"].ToString();
                tbName.Text = r["TenNhanVien"].ToString();
                tbPhone.Text = r["SoDienThoai"].ToString();
                tbAddress.Text = r["DiaChi"].ToString();
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
            tbAddress.Text = string.Empty;
            tbCode.Focus();
            tbCode.Visible = false;
            label2.Visible = false;
            this.manv = "";
            this.Text = "Thêm mới nhân viên";
        }
    }
}
