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
    public partial class LDanhSachTinhTrang : Form
    {
        public LDanhSachTinhTrang()
        {
            InitializeComponent();
        }

      
        private void LDanhSachTinhTrang_Load_1(object sender, EventArgs e)
        {
            loadDSTT();
            //Last update: 11/01/2023
            evenRole();
        }

        public void loadDSTT()
        {
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure("SelectAllTT", lst);
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
                    var mtt = dgvList.Rows[e.RowIndex].Cells["MaTrangThai"].Value.ToString();
                    new DTinhTrang(mtt).ShowDialog();
                    loadDSTT();
                }
            }

            /*if (e.RowIndex > 0)
            {
                var mtt = dgvList.Rows[e.RowIndex].Cells["MaTrangThai"].Value.ToString();
                new DTinhTrang(mtt).ShowDialog();
                loadDSTT();
            }*/
        }

        private string tukhoa = "";

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập Mã tình trạng hoặc Tên tình trạng!");
            }
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimKiemTT";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimKiemTT N'" + tukhoa + "'");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            loadDSTT();
        }
    }
}
