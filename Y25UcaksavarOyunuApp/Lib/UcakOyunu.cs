using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y25UcaksavarOyunuApp.Lib
{
    public class UcakOyunu
    {
        private Timer tmrMermi, tmrUretici, tmrUcak, tmrKontrol, tmrArkaPlan, tmrYananUcak;
        public PictureBox PictureArkaplan1 { get; set; } = new PictureBox();
        public PictureBox PictureArkaplan2 { get; set; } = new PictureBox();
        public List<Ucak> YananUcaklar { get; set; } = new List<Ucak>();

        private Random rnd = new Random();
        public Ucaksavar Ucaksavar { get; set; }
        public int Skor { get; set; } = 0;
        public bool OyunDurduMu { get; set; } = false;
        public List<Ucak> Ucaklar { get; set; } = new List<Ucak>();
        private ContainerControl tasiyici;
        public UcakOyunu(ContainerControl tasiyici)
        {

            this.tasiyici = tasiyici;
            this.tasiyici.BackColor = Color.White;
            tasiyici.Controls.Clear();
            this.Ucaksavar = new Ucaksavar(tasiyici);
            ArkaplanAyarlariniYap();

            tmrArkaPlan = new Timer()
            {
                Interval = 30,
                Enabled = true
            };
            tmrArkaPlan.Tick += TmrArkaPlan_Tick;

            tmrMermi = new Timer()
            {
                Interval = 30,
                Enabled = true
            };
            tmrMermi.Tick += TmrMermi_Tick;

            tmrUretici = new Timer()
            {
                Interval = 1200,
                Enabled = true
            };
            tmrUretici.Tick += TmrUretici_Tick;

            tmrYananUcak = new Timer()
            {
                Interval = 5,
                Enabled = true
            };
            tmrYananUcak.Tick += TmrYananUcak_Tick;

            tmrUcak = new Timer()
            {
                Interval = 120,
                Enabled = true
            };

            tmrUcak.Tick += TmrUcak_Tick;
            tmrKontrol = new Timer();
            tmrKontrol.Interval = 5;
            tmrKontrol.Tick += TmrKontrol_Tick; ;
            tmrKontrol.Start();

        }

        private void TmrYananUcak_Tick(object sender, EventArgs e)
        {
            foreach (Ucak item in YananUcaklar)
            {
                item.YanmaSuresi -= tmrYananUcak.Interval;
                if (item.YanmaSuresi <= 0)
                {
                    YananUcaklar.Remove(item);
                    this.tasiyici.Controls.Remove(item.ResimKutusu);
                    break;
                }

            }
        }

        internal void OyunuDevamEttir()
        {
            tmrArkaPlan.Start();
            tmrKontrol.Start();
            tmrMermi.Start();
            tmrUcak.Start();
            tmrUretici.Start();
            tmrYananUcak.Start();
        }

        internal void OyunuKaydet()
        {
            OyunKayit newKayit = new OyunKayit();
            newKayit.KayitIsmi = $"Kayit-{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}";
            newKayit.Skor = Skor;
            newKayit.Arkaplan.Add(new ArkaplanKayit()
            {
                X = PictureArkaplan1.Location.X,
                Y = PictureArkaplan1.Location.Y
            });
            newKayit.Arkaplan.Add(new ArkaplanKayit()
            {
                X = PictureArkaplan2.Location.X,
                Y = PictureArkaplan2.Location.Y
            });
            foreach (Ucak item in Ucaklar)
            {
                newKayit.Ucak.Add(new UcaklarKayit()
                {
                    X = item.ResimKutusu.Location.X,
                    Y = item.ResimKutusu.Location.Y
                });
            }
            foreach (Ucak item in YananUcaklar)
            {
                newKayit.YananUcak.Add(new YananUcaklarKayit()
                {
                    X = item.ResimKutusu.Location.X,
                    Y = item.ResimKutusu.Location.Y,
                    YanmaSuresi = item.YanmaSuresi
                });
            }
            foreach (Roket item in Ucaksavar.Roketler)
            {
                newKayit.Mermi.Add(new MermilerKayit()
                {
                    X = item.ResimKutusu.Location.X,
                    Y = item.ResimKutusu.Location.Y
                });
            }
            newKayit.Ucaksavar = new UcaksavarKayit()
            {
                X = Ucaksavar.ResimKutusu.Location.X,
                Y = Ucaksavar.ResimKutusu.Location.Y
            };

            string jsonkayit = JsonConvert.SerializeObject(newKayit);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\UcaksavarKayit";
            Directory.CreateDirectory(path);
            FileStream file = new FileStream(path + $"\\{newKayit.KayitIsmi.Replace(" ", "")}.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(jsonkayit);
            writer.Flush();
            writer.Close();
            file.Close();
        }

        internal void OyunuDuraklat()
        {
            tmrArkaPlan.Stop();
            tmrKontrol.Stop();
            tmrMermi.Stop();
            tmrUcak.Stop();
            tmrUretici.Stop();
            tmrYananUcak.Stop();

        }

        private void ArkaplanAyarlariniYap()
        {
            PictureArkaplan1.Image = Properties.Resources.bulut;
            PictureArkaplan1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureArkaplan1.Size = new Size(tasiyici.ClientSize.Width, tasiyici.ClientSize.Height);
            PictureArkaplan2.Image = Properties.Resources.bulut;
            PictureArkaplan2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureArkaplan2.Size = new Size(tasiyici.ClientSize.Width, tasiyici.ClientSize.Height);
            PictureArkaplan1.Location = new Point(0, 0);
            PictureArkaplan2.Location = new Point(-PictureArkaplan2.Width + 1, 0);


            this.tasiyici.Controls.Add(PictureArkaplan1);
            this.tasiyici.Controls.Add(PictureArkaplan2);


        }

        private void TmrArkaPlan_Tick(object sender, EventArgs e)
        {
            PictureArkaplan1.Location = new Point(PictureArkaplan1.Location.X + 1, 0);
            PictureArkaplan2.Location = new Point(PictureArkaplan2.Location.X + 1, 0);
            if (PictureArkaplan2.Location.X + this.tasiyici.ClientSize.Width == this.tasiyici.ClientSize.Width)
            {
                PictureArkaplan1.Location = new Point(-1 * PictureArkaplan1.Size.Width, 0);
            }
            else if (PictureArkaplan1.Location.X + this.tasiyici.ClientSize.Width == this.tasiyici.ClientSize.Width)
            {
                PictureArkaplan2.Location = new Point(-1 * PictureArkaplan2.Size.Width, 0);
            }
        }

        private void TmrKontrol_Tick(object sender, EventArgs e)
        {
            foreach (Ucak item in Ucaklar)
            {
                bool vurduMu = false;
                if (item.ResimKutusu.Location.Y + item.ResimKutusu.Height > tasiyici.Height - 70)
                {
                    OyunDurduMu = true;
                    tmrKontrol.Stop();
                    tmrMermi.Stop();
                    tmrUcak.Stop();
                    tmrUretici.Stop();
                    break;
                }
                Rectangle ur = new Rectangle()
                {
                    X = item.ResimKutusu.Left,
                    Y = item.ResimKutusu.Top,
                    Height = item.ResimKutusu.Height,
                    Width = item.ResimKutusu.Width
                };

                Rectangle mr = new Rectangle();

                foreach (Roket roket in Ucaksavar.Roketler)
                {
                    mr.X = roket.ResimKutusu.Left;
                    mr.Y = roket.ResimKutusu.Top;
                    mr.Height = roket.ResimKutusu.Height;
                    mr.Width = roket.ResimKutusu.Width;

                    if (ur.IntersectsWith(mr))
                    {

                        tasiyici.Controls.Remove(roket.ResimKutusu);
                        Ucaklar.Remove(item);
                        Ucaksavar.Roketler.Remove(roket);
                        Skor++;
                        vurduMu = true;
                        YanmaEfektiniVer(item);
                        break;
                    }
                }
                if (vurduMu) break;
            }
            foreach (Roket item in this.Ucaksavar.Roketler)
            {
                if (item.ResimKutusu.Location.Y < 0)
                {
                    this.Ucaksavar.Roketler.Remove(item);
                    tasiyici.Controls.Remove(item.ResimKutusu);
                    break;
                }
            }
            tasiyici.Text = $"Skor: {Skor} Toplam Roket: {Ucaksavar.Roketler.Count} Toplam Ucak: {Ucaklar.Count}";
            if (OyunDurduMu)
            {
                DialogResult cevap = MessageBox.Show($"Oyun bitti. Skor: {Skor}\nYeniden oynamak istiyor musun?", "Kaybettin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {

                    tasiyici.Controls.Clear();
                    Ucaklar = new List<Ucak>();
                    Skor = 0;
                    OyunDurduMu = false;
                    Ucaksavar = new Ucaksavar(tasiyici);
                    tmrKontrol.Start();
                    tmrMermi.Start();
                    tmrUcak.Start();
                    tmrUretici.Start();
                    ArkaplanAyarlariniYap();
                }
                else
                    Application.Exit();
            }
        }

        private void YanmaEfektiniVer(Ucak item)
        {
            Sesler.VurulmaSesi();
            item.ResimKutusu.Image = Properties.Resources.yanma;
            YananUcaklar.Add(item);
        }

        private void TmrUcak_Tick(object sender, EventArgs e)
        {
            Ucaklar.ForEach(x => x.HareketEt(Yonler.Asagi));
        }


        private void TmrUretici_Tick(object sender, EventArgs e)
        {
            Point point = new Point()
            {
                X = rnd.Next(60, tasiyici.Width - 120),
                Y = 0
            };
            Ucak ucak = new Ucak(point);
            Ucaklar.Add(ucak);
            tasiyici.Controls.Add(ucak.ResimKutusu);
            tasiyici.Controls.SetChildIndex(ucak.ResimKutusu, 11);
            ArkaplaniArkayaAt();
        }

        private void ArkaplaniArkayaAt()
        {
            PictureArkaplan1.SendToBack();
            PictureArkaplan2.SendToBack();
        }

        private void TmrMermi_Tick(object sender, EventArgs e)
        {
            foreach (Roket item in Ucaksavar.Roketler)
            {
                item.HareketEt(Yonler.Yukari);
                ArkaplaniArkayaAt();
            }
        }
    }
}
