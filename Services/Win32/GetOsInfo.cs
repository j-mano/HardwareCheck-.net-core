using GetHardwareInfo.Services.Modells;
using System.Management;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.Win32
{
    public class GetOsInfo
    {
        //https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp

        public static async Task<OSModell> GetOsInfoAsync()
        {
            OSModell SingelOs = new OSModell();

            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                SingelOs.OsVersion     = obj["Version"].ToString();
                SingelOs.Name          = obj["Caption"].ToString();
                SingelOs.Countrycode   = int.Parse( obj["OSType"].ToString() );
                SingelOs.Directory     = obj["WindowsDirectory"].ToString();
            }

            return SingelOs;
        }
    }
}
