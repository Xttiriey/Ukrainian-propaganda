using System.IO;
using System.Media;
using System.Net;

namespace Ukrainian_propaganda
{
    class Anthem
    {
        private static void DownloadWav(string url, string path)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.DownloadFile(url, path);
        }

        public static void CheckWav(string url, string path)
        {
            if (!File.Exists(path))
            {
                DownloadWav(url, path);
            }
        }

        public static void PlayWav(string anthem)
        {
            SoundPlayer sound = new SoundPlayer(anthem);
            sound.PlaySync();
        }
    }
}
