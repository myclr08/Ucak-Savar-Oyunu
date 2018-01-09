using System;
using System.Drawing;
using System.Windows.Forms;

namespace Y25UcaksavarOyunuApp.Lib
{
    public class Roket : OyunBase, IHareketEdebilir
    {
        private Point konum;
        private const int MERMI_HIZI = 5;
        public Roket(Point konum)
        {
            this.konum = konum;
            ResimKutusu = new PictureBox
            {
                Size = new Size(28, 36),
                Image = Properties.Resources.mermi1,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = konum
            };
            Sesler.RoketSesi();
        }
        public void HareketEt(Yonler yon)
        {
            if (yon == Yonler.Yukari)
            {
                ResimKutusu.Location = new Point
                {
                    X = ResimKutusu.Location.X,
                    Y = ResimKutusu.Location.Y - MERMI_HIZI
                };
            }
            else
                throw new Exception("Roket sadece yukarı yönde hareket eder");
        }
    }
}
