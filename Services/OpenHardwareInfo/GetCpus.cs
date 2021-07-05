using GetHardwareInfo.Services.Modells;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.OpenHardwareInfo
{
    public static class GetCpus
    {
        static Computer ComputerCpu = new Computer()
        {
            CPUEnabled = true
        };

        /* 
         * If sevral cpus is in the system is it expected to be of the same model and have sam or simular cooling and temps.
         * The load is expected to be somewhat evenly distrubuted over all cpu core. (Multitreaded aplication is expected to run on this system).
        */

        public async static Task<List<CPUModell>> ReturncpuAsync()
        {
            List<CPUModell> CpuList = new List<CPUModell>();

            List<string> CpuNames = returnCpuName();

            foreach (string CpuName in CpuNames)
            {
                CPUModell cpu = new CPUModell();
                cpu.CpuName         = CpuName;
                cpu.CpuCores        = returnCpuCores();
                cpu.TurboClockSpeed = returnMaxClockSpeed();

                CpuList.Add(cpu);
            }

            return CpuList;
        }

        /// <summary>
        /// Returning an list of an cpu or cpus if running ob multi cpu server
        /// </summary>
        /// <returns></returns>
        public static List<string> returnCpuName()
        {
            List<string> returnStringList = new List<string>();

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        returnStringList.Add(hardware.Name);
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return returnStringList;
        }

        /// <summary>
        /// Return amount of cores on the cpus. Cores not treads. expected amount is 2 to 16 for regular consumer hardware in 2020/2021.
        /// Return as int.
        /// </summary>
        /// <returns></returns>
        public static short returnCpuCores()
        {
            short ReturnCpuCoreCount = 0;

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        ReturnCpuCoreCount++;
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return ReturnCpuCoreCount;
        }

        /// <summary>
        /// Return of the Max clockspeed of the cpu / cpus. propbaly going to be the boost speed of the cpu in the cpu specifikation.
        /// Return as float.
        /// </summary>
        /// <returns></returns>
        public static float returnMaxClockSpeed()
        {
            float returnCpuClockspeed = 0f;

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            try
                            {
                                if (sensor.SensorType == SensorType.Clock)
                                {
                                    returnCpuClockspeed = (float)sensor.Max;
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return returnCpuClockspeed;
        }

        /// <summary>
        /// Return of the Max clockspeed of the cpu / cpus. propbaly going to be the boost speed of the cpu in the cpu specifikation.
        /// Return as float.
        /// </summary>
        /// <returns></returns>
        public static float returnCurrentClockSpeed()
        {
            float returnCpuClockspeed = 0f;

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            try
                            {
                                if (sensor.SensorType == SensorType.Clock)
                                {
                                    returnCpuClockspeed = (float)sensor.Value;
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return returnCpuClockspeed;
        }

        /// <summary>
        /// Return current power consumtion of the cpu.
        /// </summary>
        /// <returns></returns>
        public static float powerConsumtion()
        {
            float ReturnPowerConsumtion = 0;

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            try
                            {
                                if (sensor.SensorType == SensorType.Power)
                                {
                                    ReturnPowerConsumtion = (float)sensor.Value;
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return ReturnPowerConsumtion;
        }

        /// <summary>
        /// Return higest recorded power consumtion of the cpu in this session.
        /// </summary>
        /// <returns></returns>
        public static float highestPowerConsumtion()
        {
            float ReturnPowerConsumtion = 0;

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            try
                            {
                                if (sensor.SensorType == SensorType.Power)
                                {
                                    ReturnPowerConsumtion = (float)sensor.Max;
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return ReturnPowerConsumtion;
        }

        /// <summary>
        /// Return of current clockVoltage of the cpu.
        /// </summary>
        /// <returns></returns>
        public static string returnClockVoltage()
        {
            string returnString = "";

            try
            {
                ComputerCpu.Open();

                foreach (var hardware in ComputerCpu.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            try
                            {
                                if (sensor.SensorType == SensorType.Voltage)
                                {
                                    returnString = sensor.Values.ToString();
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }
                }

                ComputerCpu.Close();
            }
            catch
            {
                throw;
            }

            return returnString;
        }
    }
}
