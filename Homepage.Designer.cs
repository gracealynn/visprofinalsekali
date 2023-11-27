namespace Daftar_fasilitas
{
    partial class Homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.btnmahasiswa = new System.Windows.Forms.Button();
            this.btnfasilitas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnhelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnmahasiswa
            // 
            this.btnmahasiswa.Location = new System.Drawing.Point(190, 328);
            this.btnmahasiswa.Name = "btnmahasiswa";
            this.btnmahasiswa.Size = new System.Drawing.Size(168, 115);
            this.btnmahasiswa.TabIndex = 0;
            this.btnmahasiswa.Text = "Data Mahasiswa";
            this.btnmahasiswa.UseVisualStyleBackColor = true;
            this.btnmahasiswa.Click += new System.EventHandler(this.btnmahasiswa_Click);
            // 
            // btnfasilitas
            // 
            this.btnfasilitas.Location = new System.Drawing.Point(546, 328);
            this.btnfasilitas.Name = "btnfasilitas";
            this.btnfasilitas.Size = new System.Drawing.Size(168, 115);
            this.btnfasilitas.TabIndex = 1;
            this.btnfasilitas.Text = "Daftar Fasilitas";
            this.btnfasilitas.UseVisualStyleBackColor = true;
            this.btnfasilitas.Click += new System.EventHandler(this.btnfasilitas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(382, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnhelp
            // 
            this.btnhelp.Location = new System.Drawing.Point(827, 12);
            this.btnhelp.Name = "btnhelp";
            this.btnhelp.Size = new System.Drawing.Size(75, 33);
            this.btnhelp.TabIndex = 3;
            this.btnhelp.Text = "Help";
            this.btnhelp.UseVisualStyleBackColor = true;
            this.btnhelp.Click += new System.EventHandler(this.btnhelp_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 578);
            this.Controls.Add(this.btnhelp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnfasilitas);
            this.Controls.Add(this.btnmahasiswa);
            this.Name = "Homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Homepage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnmahasiswa;
        private System.Windows.Forms.Button btnfasilitas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnhelp;
    }
}