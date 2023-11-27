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
    public partial class frmdata : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public frmdata()
        {
            alamat = "server=localhost; database=db_daftarfasilitas; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void btncari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxNama.Text != "")
                {
                    query = string.Format("select * from table_asrama where NIM like '%{0}%'", txtboxNama.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                frmdata_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            EditDataAsrama editDataAsrama = new EditDataAsrama();
            editDataAsrama.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();

        }

        private void frmdata_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from table_asrama");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Nama";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[2].HeaderText = "NIM";
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[3].HeaderText = "No.Telpon";
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[4].HeaderText = "No. Telepon Orang Tua";
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[5].HeaderText = "Kamar";

                txtboxNama.Clear();

                txtboxNama.Focus();

                btncari.Enabled = false;
                btncari.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
