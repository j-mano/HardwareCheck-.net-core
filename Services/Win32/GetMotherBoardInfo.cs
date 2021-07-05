using GetHardwareInfo.Services.Modells;
using System.Management;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.Win32
{
    public class GetMotherBoardInfo
    {
        public async static Task<ModerBoardModell> GetMotherBoardInfoAsync()
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher myOperativeSystemObject2 = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");

            ModerBoardModell moderBoard = new ModerBoardModell();

            // Motherboard information.
            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                moderBoard.MoboManufacturer = obj["Manufacturer"].ToString();
                moderBoard.MoboModell       = obj["Product"].ToString();
            }

            // Bios information.
            foreach (ManagementObject obj in myOperativeSystemObject2.Get())
            {
                moderBoard.BiosVersion = obj["SMBIOSBIOSVersion"].ToString();
            }

            return moderBoard;
        }
    }
}
