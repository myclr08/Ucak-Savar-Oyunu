namespace Y25UcaksavarOyunuApp.Lib
{
    public interface IHareketEdebilir
    {
        void HareketEt(Yonler yon);
    }
    public enum Yonler
    {
        Yukari, Asagi, Saga, Sola
    }
}
