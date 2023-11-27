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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Daftar_fasilitas
{
    public partial class signup : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public signup()
        {
            alamat = "server=localhost; database=db_signup; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                query = "INSERT INTO tabel_signup (username, password) VALUES (@username, @password)";

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@username", txtboxuser.Text);
                perintah.Parameters.AddWithValue("@password", txtboxpass.Text);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();

                if (res == 1)
                {
                    Formlogin formlogin = new Formlogin();
                    formlogin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to Sign Up");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
