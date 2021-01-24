using System.Management;

namespace Ukrainian_propaganda
{
    class SystemInfo
    {
        public static string GetGPUName()
        {
            try
            {
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                foreach (ManagementObject mObject in mSearcher.Get())
                {
                    return mObject["Name"].ToString();
                }
                return "Unknown";
            }
            catch { return "Unknown"; }
        }

        public static string GetComputerManufacturer()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    return mo["Manufacturer"].ToString();
                }
            }
            return null;
        }
    }
}
