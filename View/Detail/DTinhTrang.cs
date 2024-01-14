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
    public partial class DTinhTrang : Form
    {
        private string maTT;
        public DTinhTrang(string maTT)
        {
            InitializeComponent();
            this.maTT = maTT;
        }

        private void DTinhTrang_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maTT))
            {
                this.Text = "Thêm mới loại tình trạng";
            }
            else
            {
                this.Text = "Cập nhật loại tình trạng";
                var r = new DataBase().Select("exec SelectTT '" + maTT + "'");
                tbCode.Text = r["MaTrangThai"].ToString();
                tbName.Text = r["TenTrangThai"].ToString();
            }
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            if (string.IsNullOrEmpty(maTT))
            {
                new DataBase().SelectData("exec InsertTT N'" + name + "'");
            }
            else
            {
                new DataBase().SelectData("exec UpdateTT '" + maTT + "'" + "," + "N'" + name + "'");
            }
            this.Dispose();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;
            tbName.Text = string.Empty;
            tbCode.Focus();
            tbCode.Visible = false;
            label2.Visible = false;
            this.maTT = "";
            this.Text = "Thêm mới tình trạng";
        }

        private void btDanger_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
