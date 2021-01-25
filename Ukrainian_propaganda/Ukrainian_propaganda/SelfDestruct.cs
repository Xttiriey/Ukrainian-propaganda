using System.Diagnostics;

namespace Ukrainian_propaganda
{
    class SelfDestruct
    {
        public static void Terminate(int code = 0)
        {
            string AssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // Start process
            Process.Start(new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/C chcp 65001 && ping 127.0.0.1 && DEL /F /S /Q /A \"{AssemblyPath}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = true,
            });
            System.Environment.Exit(code);
        }
    }
}
