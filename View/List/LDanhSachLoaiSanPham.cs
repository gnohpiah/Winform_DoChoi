using DoChoi.View.Detail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoChoi.View.List
{
    public partial class LDanhSachLoaiSanPham : Form
    {
        DataBase db;
        public LDanhSachLoaiSanPham()
        {
            InitializeComponent();
        }
        private void LDanhSachLoaiSanPham_Load(object sender, EventArgs e)
        {
            loadDSLSP();
            evenRole();
        }

        public void loadDSLSP()
        {
            db = new DataBase();
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = db.SelectProcedure("SelectAllLSP", lst);
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            string maLoaiSP = string.Empty;
            DLoaiSanPham dLoaiSanPham = new DLoaiSanPham(maLoaiSP);
            dLoaiSanPham.Show();
        }

        public void evenRole()
        {
            btAdd.Visible = btDelete.Visible = TempAdmin.IsAdmin;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex >= 0)
                {
                    var mloaisp = dgvList.Rows[e.RowIndex].Cells["MaLoaiMatHang"].Value.ToString();
                    new DLoaiSanPham(mloaisp).ShowDialog();
                    loadDSLSP();
                }
            }

           /* if (e.RowIndex >= 0)
            {
                var mloaisp = dgvList.Rows[e.RowIndex].Cells["MaLoaiMatHang"].Value.ToString();
                new DLoaiSanPham(mloaisp).ShowDialog();
                loadDSLSP();
            }*/
        }

        private string tukhoa = "";

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập Mã loại mặt hàng hoặc Tên loại mặt hàng!");
            }
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimKiemLoaiSP";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimKiemLoaiSP N'" + tukhoa + "'");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            loadDSLSP();
        }
    }
}
