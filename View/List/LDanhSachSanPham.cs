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
    public partial class LDanhSachSanPham : Form
    {
        public LDanhSachSanPham()
        {
            InitializeComponent();
        }

        private void LDanhSachSanPham_Load(object sender, EventArgs e)
        {
            loadDSSP();
            //Last update: 11/01/2023
        }
        public void loadDSSP()
        {
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure("SelectAllSP", lst);
        }
        //Last update: 11/01/2023
 
        private string tukhoa = "";
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng không bỏ trống ô tìm kiếm!");
            }
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimKiemSP";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimKiemSP N'" + tukhoa + "'");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            loadDSSP();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex >= 0)
                {
                    var msp = dgvList.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                    new DSanPham(msp).ShowDialog();
                    loadDSSP();
                }
            }
            /*
                 if (e.RowIndex >= 0)
                 {
                     var msp = dgvList.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                     new DSanPham(msp).ShowDialog();
                     loadDSSP();
                  }*/
        }
    }
}
