using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoChoi.View
{
    public partial class DangNhap : Form
    {
        private string tendangnhap = "";
        private string loaitk = "";
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            #region kiemtra_rangbuoc
            if (cbAccessMode.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản");
                return;
            } 
            if(string.IsNullOrEmpty(tbUsername.Text) ) 
            {
                MessageBox.Show("Vui lòng hoàn thành UserName", "UserName không được bỏ trống!");
                tbUsername.Select();
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text)) 
            {
                MessageBox.Show("Vui lòng hoàn thành Password", "Password không được bỏ trống!");
                return;
            }
            #endregion
            //Last update: 11/01/2023
            #region swtk
            switch (cbAccessMode.Text)
            {
                case "Admin":
                    loaitk = "admin";
                    //Last update: 11/01/2023
                    TempAdmin.IsAdmin = true;
                    break;
                case "User":
                    loaitk = "user";
                    //Last update: 11/01/2023
                    TempAdmin.IsAdmin = false;
                    break;
            }
            #endregion
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@loaitk",
                    value = loaitk
                },
                new CustomParameter()
                {
                    key = "@username",
                    value = tbUsername.Text
                },
                new CustomParameter()
                {
                    key = "@password",
                    value = tbPassword.Text
                },
            };
            var rs = new DataBase().SelectProcedure("dangnhap", lst);
            if (rs.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công! \nXin chào " + tbUsername.Text, "Thông báo");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu", "Tài khoản hoặt mật khẩu không hợp lệ");
            }
        }
        public string getUserName()
        {
            return tbUsername.Text;
        }
        public string getLoaiTk()
        {
            return loaitk;
        }
    }
}
