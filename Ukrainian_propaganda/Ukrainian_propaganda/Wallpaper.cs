using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace Ukrainian_propaganda
{
    class Wallpaper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private static void DownloadWallpaper(string url, string path)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream stream = client.OpenRead(url);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public static void CheckWallpaper(string url, string path)
        {
            if (!File.Exists(path))
            {
                DownloadWallpaper(url, path);
            }
        }

        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(20, 0, path, 0x01 | 0x02);
        }
    }
}
