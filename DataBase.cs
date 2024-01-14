using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DoChoi
{
    internal class DataBase
    {
        private string url = "Data Source=THANHVU\\SQLEXPRESS01;Initial Catalog=QLDoChoi_final;Integrated Security=True";
        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;

        public DataBase()
        {
            try
            {
                conn = new SqlConnection(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connected Failed: " + ex.Message);
            }
        }

        public DataTable SelectProcedure(string sql, List<CustomParameter> lcustomParameters)
        {
            try
            {
                conn.Open();
                dt = new DataTable();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var parameter in lcustomParameters)
                {
                    cmd.Parameters.AddWithValue(parameter.key, parameter.value);
                }
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Procedure Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable SelectData(string sql)
        {
            try
            {
                conn.Open();
                dt = new DataTable();
                cmd = new SqlCommand(sql, conn);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading Data Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //last update: 20/11/2023
        public DataRow Select(string  sql) 
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn); 
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi load thông tin chi tiết: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public int Excute(string sql, List<CustomParameter> lcustomParameters)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                foreach (var parameter in lcustomParameters)
                {
                    cmd.Parameters.AddWithValue(parameter.key, parameter.value);
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}