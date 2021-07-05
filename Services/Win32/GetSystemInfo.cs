using GetHardwareInfo.Services.Modells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace GetHardwareInfo.Services.Win32
{
    public class GetSystemInfo
    {
        private async static Task< SystemModell > GetSystemInfoAsync()
        {
            SystemModell SysInfo = new SystemModell();

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_Battery");
            ManagementObjectSearcher myVideoObject2 = new ManagementObjectSearcher("select * from Win32_CDROMDrive");
            ManagementObjectSearcher myVideoObject3 = new ManagementObjectSearcher("select * from Win32_FloppyController"); 
            ManagementObjectSearcher myVideoObject4 = new ManagementObjectSearcher("select * from Win32_IDEController");
            ManagementObjectSearcher myVideoObject5 = new ManagementObjectSearcher("select * from Win32_1394Controller");

            foreach (ManagementObject obj in myVideoObject.Get())
            {

            }

            foreach (ManagementObject obj in myVideoObject2.Get())
            {

            }

            foreach (ManagementObject obj in myVideoObject3.Get())
            {

            }

            foreach (ManagementObject obj in myVideoObject4.Get())
            {

            }

            foreach (ManagementObject obj in myVideoObject5.Get())
            {

            }

            return SysInfo;
        }
    }
}
