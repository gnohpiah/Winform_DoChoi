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
    public partial class LDanhSachBanHang : Form
    {
        DataBase db;
        public LDanhSachBanHang()
        {
            InitializeComponent();
        }

        private void LDanhSachBanHang_Load(object sender, EventArgs e)
        {
            db = new DataBase();
            List<CustomParameter> lst = new List<CustomParameter>();
            dgvList.DataSource = db.SelectProcedure("SelectAllHDB", lst);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DHoaDonBan dHoaDonBan = new DHoaDonBan();
            dHoaDonBan.Show();
        }
    }
}
