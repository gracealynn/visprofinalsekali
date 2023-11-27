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
    public partial class EditDataAsrama : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public EditDataAsrama()
        {
            alamat = "server=localhost; database=db_daftarfasilitas; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxNIM.Text != "")
                {
                    query = string.Format("select * from table_asrama where NIM like '%{0}%'", txtboxNIM.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow kolom = ds.Tables[0].Rows[0];
                        txtboxNIM.Text = kolom["NIM"].ToString();
                        txtboxNama.Text = kolom["Nama"].ToString();
                        txtboxNo1.Text = kolom["NoTelpon"].ToString();
                        txtboxNo2.Text = kolom["NoTelponOrangTua"].ToString();
                        txtboxKamar.Text = kolom["Kamar"].ToString();

                        btnTambah.Enabled = false;
                        btnHapus.Enabled = true;
                        btnUpdate.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("UPDATE `table_asrama` SET `Nama`='{0}',`NoTelpon`='{1}',`NoTelponOrangtua`='{2}',`Kamar`='{3}' where NIM = '{4}'", txtboxNama.Text, txtboxNo1.Text, txtboxNo2.Text, txtboxKamar.Text, txtboxNIM.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                EditDataAsrama_Load(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                query = "INSERT INTO `table_asrama` (`Nama`, `NIM`, `NoTelpon`, `NoTelponOrangtua`, `Kamar`) VALUES (@Nama, @NIM, @No1, @No2, @Kamar)";

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@Nama", txtboxNama.Text);
                perintah.Parameters.AddWithValue("@NIM", txtboxNIM.Text);
                perintah.Parameters.AddWithValue("@No1", txtboxNo1.Text);
                perintah.Parameters.AddWithValue("@No2", txtboxNo2.Text);
                perintah.Parameters.AddWithValue("@Kamar", txtboxKamar.Text);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();

                if (res == 1)
                {
                    MessageBox.Show("Insert data success");
                    EditDataAsrama_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Insert data Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                query = "DELETE FROM `table_asrama` WHERE NIM = @NIM";

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@NIM", txtboxNIM.Text);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Delete data success");
                    EditDataAsrama_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Delete data Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                EditDataAsrama_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmdata Frmdata = new frmdata();
            Frmdata.Show();

            this.Hide();
        }

        private void EditDataAsrama_Load(object sender, EventArgs e)
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
                txtboxNIM.Clear();
                txtboxNo1.Clear();
                txtboxNo2.Clear();
                txtboxKamar.Clear();

                btnCari.Enabled = false;
                btnTambah.Enabled = false;
                btnHapus.Enabled = false;
                btnUpdate.Enabled = false;
                btnClear.Enabled = false;
                btnCari.Enabled = true;
                btnTambah.Enabled = true;
                btnUpdate.Enabled = true;
                btnClear.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
