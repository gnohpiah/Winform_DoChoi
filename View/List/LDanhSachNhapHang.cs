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
    public partial class LDanhSachNhapHang : Form
    {
        public LDanhSachNhapHang()
        {
            InitializeComponent();
        }

        private void LDanhSachNhapHang_Load(object sender, EventArgs e)
        {
            //update 26/11/2023
            loadHDN(); 
        }
            
        public void loadHDN()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            dgvList.DataSource = new DataBase().SelectProcedure("SelectAllHDN", lstPara);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (TempAdmin.IsAdmin)
            {
                if (e.RowIndex > 0)
                {
                    var mncc = dgvList.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                    new DNhaCungCap(mncc).ShowDialog();
                    loadDSNCC();
                }
            }*/

                if (e.RowIndex >= 0)
                {
                    var mhdn = dgvList.Rows[e.RowIndex].Cells["SoHDN"].Value.ToString();
                    new DNhapHang(mhdn).ShowDialog();
                    loadHDN();
                }
        }
        private string tukhoa = "";
        private void btSearch_Click(object sender, EventArgs e)
        {
            tukhoa = tbSearch.Text;
            string sql = "TimKiemHDNtheotukhoa";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (tbSearch.Text == string.Empty && chbDate.Checked == false && chbPrice.Checked == false)
            {
                MessageBox.Show("Hãy điền thông tin tìm kiếm!");
            }
             else if (tbSearch.Text != string.Empty)
             {
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa,
                });
                if (chbPrice.Checked == true)
                {
                   if(tbSearch.Text == string.Empty)
                    {
                        sql = "TimKiemHDNtheogia";
                        lstPara.Add(new CustomParameter()
                        {
                            key = "@giabd",
                            value = tbPriceFrom.Text,
                        });
                        lstPara.Add(new CustomParameter()
                        {
                            key = "@giakt",
                            value = tbPriceTo.Text,
                        });
                   }
                    else
                    {
                        sql = "TimKiemHDNtheotukhoa";
                    } 
                        
                }
                if (chbDate.Checked == true)
                {
                    if (tbSearch.Text == string.Empty)
                    {
                        sql = "TimKiemHDNtheongay";
                        lstPara.Add(new CustomParameter()
                        {
                            key = "@ngaybd",
                            value = string.Concat(dpFrom),
                        });
                        lstPara.Add(new CustomParameter()
                        {
                            key = "@ngaybd",
                            value = string.Concat(dpTo),
                        });
                    }
                    else
                    {
                        sql = "TimKiemHDNtheotukhoa";
                    }
                }
                dgvList.DataSource = new DataBase().SelectProcedure(sql, lstPara);
                dgvList.DataSource = new DataBase().SelectData("exec " + sql + " N'" + tukhoa + "'");
             }    
        }

        private void chbPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPrice.Checked == true)
            {
                dpFrom.Enabled = dpTo.Enabled = false;
            }
        }

        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDate.Checked == true)
            {
                tbPriceFrom.Enabled = tbPriceTo.Enabled = false;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            chbDate.Checked = chbPrice.Checked = false;
            loadHDN();
        }
    }
}
