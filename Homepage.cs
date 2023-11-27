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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void btnmahasiswa_Click(object sender, EventArgs e)
        {
            frmdata Frmdata = new frmdata();
            Frmdata.Show();
            this.Hide();
        }

        private void btnfasilitas_Click(object sender, EventArgs e)
        {
            Fasilitas fasilitas = new Fasilitas();
            fasilitas.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Hide();
        }
    }
}
