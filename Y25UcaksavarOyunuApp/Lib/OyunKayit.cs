using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y25UcaksavarOyunuApp.Lib
{
    public class OyunKayit
    {
        public string KayitIsmi { get; set; }
        public int Skor { get; set; }
        public List<ArkaplanKayit> Arkaplan { get; set; } = new List<ArkaplanKayit>();
        public List<UcaklarKayit> Ucak { get; set; } = new List<UcaklarKayit>();
        public List<MermilerKayit> Mermi { get; set; } = new List<MermilerKayit>();
        public List<YananUcaklarKayit> YananUcak { get; set; } = new List<YananUcaklarKayit>();
        public UcaksavarKayit Ucaksavar { get; set; } = new UcaksavarKayit();


    }
    public class UcaksavarKayit
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class YananUcaklarKayit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int YanmaSuresi { get; set; }

    }
    public class MermilerKayit
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class UcaklarKayit
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class ArkaplanKayit
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
