using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y25UcaksavarOyunuApp.Lib
{
    public class Ucak : OyunBase, IHareketEdebilir
    {
        private Point konum;
        private const int UCAK_HIZI = 7;

        public int YanmaSuresi { get; set; } = 1500;
        public Ucak(Point konum)
        {
            this.konum = konum;
            ResimKutusu = new PictureBox()
            {
                Size = new Size(52, 44),
                Image = Properties.Resources.ucak,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = konum
            };
        }
        public void HareketEt(Yonler yon)
        {
            if (yon == Yonler.Asagi)
            {
                Point point = new Point()
                {
                    X = ResimKutusu.Location.X,
                    Y = ResimKutusu.Location.Y + UCAK_HIZI
                };
                this.ResimKutusu.Location = point;
            }
            else
                throw new Exception("Uçak sadece aşağı yönde hareket edebilir");
        }
    }
    //   public abstract class BossUcak: OyunBase, IHareketEdebilir, IAtesEdebilir { }
}
