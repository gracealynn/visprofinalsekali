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
    public partial class Fasilitas : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Fasilitas()
        {
            alamat = "server=localhost; database=db_daftarfasilitas; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Fasilitas_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                query = "INSERT INTO `info_fasilitas` (`Fasilitas`, `Asrama`, `Jumlah`, `Status`, `Nomor_Kamar`) VALUES (@Fasilitas, @Asrama, @Jumlah, @Status, @NomorKamar)";

                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                perintah.Parameters.AddWithValue("@Fasilitas", TxtFasilitas.Text);
                perintah.Parameters.AddWithValue("@Asrama", TxtAsrama.Text);
                perintah.Parameters.AddWithValue("@Jumlah", TxtJumlah.Text);
                perintah.Parameters.AddWithValue("@Status", StatusCBox.Text);
                perintah.Parameters.AddWithValue("@NomorKamar", TxtNomorKamar.Text);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();

                if (res == 1)
                {
                    MessageBox.Show("Insert data success");
                    Fasilitas_Load(null, null);
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNomorKamar.Text != "")
                {
                    query = string.Format("select * from info_fasilitas where Nomor_Kamar like '%{0}%'", TxtNomorKamar.Text);
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
                        TxtNomorKamar.Text = kolom["Nomor_Kamar"].ToString();
                        TxtAsrama.Text = kolom["Asrama"].ToString();
                        TxtJumlah.Text = kolom["Jumlah"].ToString();
                        StatusCBox.Text = kolom["Status"].ToString();
                        TxtFasilitas.Text = kolom["Fasilitas"].ToString();
                        Lbl_Id.Text = kolom["No"].ToString();
                        AddBtn.Enabled = true;
                        UpdateBtn.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("UPDATE `info_fasilitas` SET `Fasilitas`='{0}',`Asrama`='{1}',`Jumlah`='{2}',`Status` = '{3}', `Nomor_Kamar` ='{4}' where `No` = '{5}'", TxtFasilitas.Text, TxtAsrama.Text, TxtJumlah.Text, StatusCBox.Text, TxtNomorKamar.Text, Lbl_Id.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                Fasilitas_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void Fasilitas_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from info_fasilitas");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[0].HeaderText = "No.";
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[1].HeaderText = "Fasilitas";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderText = "Jumlah";
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[3].HeaderText = "Status";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Asrama";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Nomor_Kamar";

                TxtAsrama.Clear();
                TxtFasilitas.Clear();
                TxtNomorKamar.Clear();
                TxtJumlah.Clear();
                StatusCBox.Items.Clear();
                StatusCBox.Items.Add("Baik");
                StatusCBox.Items.Add("Rusak");

                TxtFasilitas.Focus();

                AddBtn.Enabled = true;
                UpdateBtn.Enabled = true;
                ClearBtn.Enabled = true;
                SearchBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
