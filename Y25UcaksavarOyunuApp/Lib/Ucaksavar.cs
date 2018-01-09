using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Y25UcaksavarOyunuApp.Lib
{
    public class Ucaksavar : OyunBase, IHareketEdebilir, IAtesEdebilir
    {
        private const int UCAKSAVAR_BIRIM = 10;
        public List<Roket> Roketler { get; set; } = new List<Roket>();
        public Ucaksavar(ContainerControl tasiyici)
        {
            this.tasiyici = tasiyici;
            this.ResimKutusu = new PictureBox()
            {
                
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(83, 83),
                Image = Properties.Resources.ucaksavar
            };
            this.ResimKutusu.Location = new Point(new Random().Next(90, tasiyici.Width - 90), tasiyici.Height - 125);
            tasiyici.Controls.Add(this.ResimKutusu);
        }

        public void HareketEt(Yonler yon)
        {
            switch (yon)
            {
                case Yonler.Sola:
                    if (ResimKutusu.Location.X > 20)
                        ResimKutusu.Location = new Point(ResimKutusu.Location.X - UCAKSAVAR_BIRIM, ResimKutusu.Location.Y);
                    break;
                case Yonler.Saga:
                    if (ResimKutusu.Location.X < tasiyici.Width - 120)
                        ResimKutusu.Location = new Point(ResimKutusu.Location.X + UCAKSAVAR_BIRIM, ResimKutusu.Location.Y);
                    break;
                default:
                    throw new Exception("Uçaksavar sadece sola veya sağa hareket edebilir");
            }
        }

        public void AtesEt()
        {
            Point point = new Point
            {
                X = ResimKutusu.Location.X + 30,
                Y = ResimKutusu.Location.Y - 30
            };
            Roket roket = new Roket(point);
            Roketler.Add(roket);
            tasiyici.Controls.Add(roket.ResimKutusu);
            tasiyici.Controls.SetChildIndex(roket.ResimKutusu, 10);
        }
    }
}
