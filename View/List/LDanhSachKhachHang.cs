using DoChoi.View.Detail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoChoi.View.List
{
    public partial class LDanhSachKhachHang : Form
    {
        DataBase db;
        public LDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void LDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            //Last update: 21/11/2023
            loadDSKH();
        }
        //Last update: 11/01/2023
        private string tukhoa = "";
        private void loadDSKH()
        {
            string sql = "SelectAllKH";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
            //last update: 20/11/2023
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            //last update: 20/11/2023
            if(tbSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập Mã khách hàng hoặc Tên khách hàng!");
            }    
            else
            {
                tukhoa = tbSearch.Text;
                string sql = "TimKiemKH";
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec TimKiemKH N'" + tukhoa + "'");
            }    
        }
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //last update: 21/11/2023
            if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex >= 0)
                {
                    var mkh = dgvList.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                    new DKhachHang(mkh).ShowDialog();
                    loadDSKH();
                }
            }

           /* if (e.RowIndex >= 0)
            {
                var mkh = dgvList.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                new DKhachHang(mkh).ShowDialog();
                loadDSKH();
            }*/
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            //last update: 20/11/2023
            tbSearch.Text = string.Empty;
            string sql = "SelectAllKH";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LDanhSachKhachHang danhSachKhachHangForm = this;
            int initialRowCount = danhSachKhachHangForm.dgvList.RowCount;
            string makh = string.Empty;
            // Perform the add operation here
            DKhachHang dKhachHang = new DKhachHang(makh);
            dKhachHang.FormClosed += (s, args) =>
            {
                int finalRowCount = danhSachKhachHangForm.dgvList.RowCount;

                loadDSKH();
                if (finalRowCount > initialRowCount)
                {
                    // A new row was added successfully
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
            };
            dKhachHang.Show();
            
        }
    }
}
