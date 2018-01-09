using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y25UcaksavarOyunuApp.Lib;

namespace Y25UcaksavarOyunuApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UcakOyunu oyun;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (oyun == null)
                {
                    oyun = new UcakOyunu(this);
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                oyun?.Ucaksavar.AtesEt();
            }
            else if (e.KeyCode == Keys.Left)
            {
                oyun?.Ucaksavar.HareketEt(Yonler.Sola);
            }
            else if (e.KeyCode == Keys.Right)
            {
                oyun?.Ucaksavar.HareketEt(Yonler.Saga);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                oyun?.OyunuDuraklat();
                DialogResult cevap = MessageBox.Show("Oyun kaydedilsin mi?", "Duraklatıldı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    oyun?.OyunuKaydet();
                    Application.Exit();
                }
                else if (cevap == DialogResult.No)
                    Application.Exit();
                else
                    oyun?.OyunuDevamEttir();
            }
        }
        private void KayitliOyunlariGetir()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\UcaksavarKayit";
            bool exists = Directory.Exists(path);
            if (exists)
            {
                string[] txtFiles = Directory.GetFiles(path, "*.txt")
                                                     .Select(Path.GetFileName)
                                                     .ToArray();
                foreach (string item in txtFiles)
                {
                    cmbKayitliOyunlar.Items.Add(item);
                    btnBaslat.Enabled = true;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KayitliOyunlariGetir();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (cmbKayitliOyunlar.SelectedIndex > -1)
            {
                string jsonkayit = "";
                string filename = cmbKayitliOyunlar.SelectedItem.ToString();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\UcaksavarKayit\\";
                Directory.CreateDirectory(path);
                FileStream file = new FileStream(path + filename, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                jsonkayit = reader.ReadToEnd();
                reader.Close();
                file.Close();

                oyun = new UcakOyunu(this);

                if (!string.IsNullOrWhiteSpace(jsonkayit))
                {

                    OyunKayit kayit = JsonConvert.DeserializeObject<OyunKayit>(jsonkayit);
                    oyun.Skor = kayit.Skor;
                    oyun.PictureArkaplan1.Location = new Point(kayit.Arkaplan[0].X, kayit.Arkaplan[0].Y);
                    oyun.PictureArkaplan2.Location = new Point(kayit.Arkaplan[1].X, kayit.Arkaplan[1].Y);

                    foreach (UcaklarKayit item in kayit.Ucak)
                    {
                        Ucak u = new Ucak(new Point(item.X, item.Y));
                        oyun.Ucaklar.Add(u);
                        this.Controls.Add(u.ResimKutusu);
                    }

                    foreach (YananUcaklarKayit item in kayit.YananUcak)
                    {
                        Ucak u = new Ucak(new Point(item.X, item.Y));
                        u.YanmaSuresi = item.YanmaSuresi;
                        u.ResimKutusu.Image = Properties.Resources.yanma;
                        oyun.YananUcaklar.Add(u);
                        this.Controls.Add(u.ResimKutusu);
                    }
                    oyun.Ucaksavar.ResimKutusu.Location = new Point(kayit.Ucaksavar.X, kayit.Ucaksavar.Y);
                    foreach (MermilerKayit item in kayit.Mermi)
                    {
                        Roket r = new Roket(new Point(item.X, item.Y));
                        oyun.Ucaksavar.Roketler.Add(r);
                        this.Controls.Add(r.ResimKutusu);
                    }

                }

            }

        }
    }
}
