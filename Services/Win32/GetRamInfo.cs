using GetHardwareInfo.Services.Modells;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.Win32
{
    public class GetRamInfo
    {
        //https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp
        
        /// <summary>
        /// Returning a list of rammodules in form of ramModell.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<RamModell>> GetRamInfoAsync()
        {
            List <RamModell> AllRammModulesInSystem = new List<RamModell>();
            RamModell SingleRamModule               = new RamModell();
            long TotalRamAmount                     = 0;

            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                SingleRamModule.RamModuleAmount = long.Parse(obj["Capacity"].ToString());
                SingleRamModule.RamType         = obj["MemoryType"].ToString();
                SingleRamModule.RamSpeed        = long.Parse( obj["Speed"].ToString() );
                SingleRamModule.RamName         = obj["Name"].ToString();
                SingleRamModule.manufacturer    = obj["Manufacturer"].ToString();
                // Colleting total amount of ram
                TotalRamAmount                  = SingleRamModule.RamModuleAmount + TotalRamAmount;

                AllRammModulesInSystem.Add(SingleRamModule);
            }

            // Assigning total amount of ram to alla modules.
            foreach(RamModell SingelModull in AllRammModulesInSystem)
            {
                SingelModull.RamTotalAmount = TotalRamAmount;
            }

            return AllRammModulesInSystem;
        }
    }
}
