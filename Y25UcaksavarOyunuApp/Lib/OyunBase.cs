using System;
using System.Windows.Forms;

namespace Y25UcaksavarOyunuApp.Lib
{
    public abstract class OyunBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PictureBox ResimKutusu { get; set; }
        protected ContainerControl tasiyici;
    }
}
