using GetHardwareInfo.Services.Modells;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetHardwareInfo.Services.OpenHardwareInfo
{
    public class GetFans
    {
        static Computer ComputerCpu = new Computer()
        {
            FanControllerEnabled = true
        };

        public static List<FanModell> GetFansAsync()
        {
            List<FanModell> RetrunFanList = new List<FanModell>();

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    FanModell f = new FanModell();

                    if (hardware.HardwareType == HardwareType.Heatmaster)
                    {
                        f.Name = hardware.Name;

                        RetrunFanList.Add(f);
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return RetrunFanList;
        }
    }
}
