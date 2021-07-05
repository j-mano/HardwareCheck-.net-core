using GetHardwareInfo.Services.Modells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace GetHardwareInfo.Services.Win32
{
    public class GetFanInfo
    {
        public static List<FanModell> GetFanInfoAsync()
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Fan");
            List<FanModell> PcFans = new List<FanModell>();
            FanModell PcFan = new FanModell();

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                PcFan.Name              = obj["Name"].ToString();
                PcFan.DesiredRPM        = long.Parse( obj["DesiredSpeed"].ToString());
                PcFan.variableSpeed     = (bool)obj["VariableSpeed"];
                PcFan.ErrorDescription  = obj["ErrorDescription"].ToString();

                PcFans.Add(PcFan);
            }

            return PcFans;
        }
    }
}
