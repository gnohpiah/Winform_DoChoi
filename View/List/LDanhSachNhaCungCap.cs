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
    public partial class LDanhSachNhaCungCap : Form
    {
        public LDanhSachNhaCungCap()
        {
            InitializeComponent();
        }

        private void LDanhSachNhaCungCap_Load(object sender, EventArgs e)
        {
            //Last update: 11/01/2023
            evenRole();
            loadDSNCC();
        }
        public void loadDSNCC()
        {
            string sql = "SelectAllNCC";
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure(sql, lst);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string mancc = string.Empty;
            DNhaCungCap dNhaCungCap = new DNhaCungCap(mancc);
            dNhaCungCap.Show();
        }
        //Last update: 11/01/2023
        public void evenRole()
        {
            btAdd.Visible = btDelete.Visible = TempAdmin.IsAdmin;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex > 0)
                {
                    var mncc = dgvList.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                    new DNhaCungCap(mncc).ShowDialog();
                    loadDSNCC();
                }
            }

            /* if (e.RowIndex >= 0)
             {
                 var mncc = dgvList.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                 new DNhaCungCap(mncc).ShowDialog();
                 loadDSNCC();
             }*/
        }
        private string tukhoa = "";
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập Mã nhà cung cấp hoặc Tên nhà cung cấp!");
            }
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimkiemNCC";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimkiemNCC N'" + tukhoa + "'");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            loadDSNCC();
        }
    }
}
