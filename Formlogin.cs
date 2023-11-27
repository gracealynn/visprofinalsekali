using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Daftar_fasilitas
{
    public partial class Formlogin : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Formlogin()
        {
            alamat = "server=localhost; database=db_signup; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("select * from tabel_signup where username = '{0}'", txtboxuser.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        string sandi;
                        sandi = kolom["password"].ToString();
                        if (sandi == txtboxpass.Text)
                        {
                            Homepage homepage = new Homepage();
                            homepage.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Anda Salah Input Password");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            signup Signup = new signup();
            Signup.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                txtboxpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtboxpass.UseSystemPasswordChar= true;
            }
        }

        private void Formlogin_Load(object sender, EventArgs e)
        {
            txtboxpass.UseSystemPasswordChar = true;
        }
    }
}
