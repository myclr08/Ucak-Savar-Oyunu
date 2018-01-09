namespace Y25UcaksavarOyunuApp
{
    partial class Form1
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
            this.lblAciklama = new System.Windows.Forms.Label();
            this.cmbKayitliOyunlar = new System.Windows.Forms.ComboBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(12, 9);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(304, 17);
            this.lblAciklama.TabIndex = 0;
            this.lblAciklama.Text = "Enter tuşu ile oyuna başla yada kayıtlı oyun aç.";
            // 
            // cmbKayitliOyunlar
            // 
            this.cmbKayitliOyunlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKayitliOyunlar.FormattingEnabled = true;
            this.cmbKayitliOyunlar.Location = new System.Drawing.Point(12, 29);
            this.cmbKayitliOyunlar.Name = "cmbKayitliOyunlar";
            this.cmbKayitliOyunlar.Size = new System.Drawing.Size(121, 24);
            this.cmbKayitliOyunlar.TabIndex = 1;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Enabled = false;
            this.btnBaslat.Location = new System.Drawing.Point(139, 30);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(75, 23);
            this.btnBaslat.TabIndex = 2;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(836, 529);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.cmbKayitliOyunlar);
            this.Controls.Add(this.lblAciklama);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.ComboBox cmbKayitliOyunlar;
        private System.Windows.Forms.Button btnBaslat;
    }
}

