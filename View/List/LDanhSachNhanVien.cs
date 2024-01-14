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
    public partial class LDanhSachNhanVien : Form
    {
        DataBase db;
        public LDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void LDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            /*db = new DataBase();
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = db.SelectProcedure("SelectAllNV", lst);*/
            //Last update: 21/01/2023
            LoadDSNV();
            evenRole();
        }
        public void LoadDSNV()
        {
            string sql = "SelectAllNV";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
            //last update: 20/11/2023
        }
        private string tukhoa = "";
        private void btAdd_Click(object sender, EventArgs e)
        {
            string manv = string.Empty;
            DNhanVien dNhanVien = new DNhanVien(manv);  
            dNhanVien.Show();
        }
        //Last update: 11/01/2023
        public void evenRole()
        {
            btAdd.Visible = btDelete.Visible = TempAdmin.IsAdmin;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập Nhân viên hàng hoặc Tên Nhân viên hoặc thông tin khác!");
            }
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimKiemNV";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimKiemNV N'" + tukhoa + "'");
            }
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            string sql = "SelectAllNV";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex >= 0)
                {
                    var mkh = dgvList.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                    new DNhanVien(mkh).ShowDialog();
                    LoadDSNV();
                }
            }
        }
    }
}
