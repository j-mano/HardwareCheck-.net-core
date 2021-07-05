using GetHardwareInfo.Services.Modells;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.Win32
{
    public class GetCPUInfo
    {
        //https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp

        public static async Task<List<CPUModell>> GetCPUInfoAsync()
        {
            ManagementObjectSearcher myProcessorObject  = new ManagementObjectSearcher("select * from Win32_Processor");
            List<CPUModell> CpusInSystem                = new List<CPUModell>();
            CPUModell SingelCpu                         = new CPUModell();

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                SingelCpu.CpuName                   = obj["Name"].ToString();
                SingelCpu.CpuManufactorer           = obj["Manufacturer"].ToString();
                SingelCpu.NumberOfLogicalProcessors = short.Parse(obj["NumberOfLogicalProcessors"].ToString());
                SingelCpu.CpuCores                  = short.Parse(obj["NumberOfCores"].ToString());
                SingelCpu.CpuArtcitecure            = artechturcheck(int.Parse( obj["Architecture"].ToString()));
                SingelCpu.TurboClockSpeed           = float.Parse(obj["MaxClockSpeed"].ToString());
                SingelCpu.SupportVirtulatation      = (bool)obj["VirtualizationFirmwareEnabled"];

                CpusInSystem.Add(SingelCpu);
            }

            return CpusInSystem;
        }

        static private string artechturcheck(int inputint)
        {
            string returnString = "";

            switch (inputint)
            {
                case 0:
                    returnString = "x86";
                    break;
                case 1:
                    returnString = "Mips";
                    break;
                case 2:
                    returnString = "Alpha";
                    break;
                case 3:
                    returnString = "PowerPC";
                    break;
                case 5:
                    returnString = "Arm";
                    break;
                case 6:
                    returnString = "Ia64 (Itanium-based systems)";
                    break;
                case 9:
                    returnString = "X86/x64";
                    break;
                default:
                    returnString = "Could not determent cpu artcetecture";
                    break;
            }

            return returnString;
        }
    }
}
