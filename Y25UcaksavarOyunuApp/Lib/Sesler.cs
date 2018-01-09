using System.Media;

namespace Y25UcaksavarOyunuApp.Lib
{
    public static class Sesler
    {
        public static void RoketSesi()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.bomb_small);
            soundPlayer.Play();
        }
        public static void VurulmaSesi()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.AWP_Ates);
            soundPlayer.Play();
        }
    }
}
