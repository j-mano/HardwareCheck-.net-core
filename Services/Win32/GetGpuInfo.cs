using GetHardwareInfo.Services.Modells;
using System.Collections.Generic;
using System.Management;
using System.Threading.Tasks;

namespace GetHardwareInfo.Services.Win32
{
    public class GetGpuInfo
    {
        //https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp

        static public async Task<List<GPUModell>> GetGpuInfoAsync()
        {
            List<GPUModell> GpusInSystem = new List<GPUModell>();
            GPUModell SingelSelectGpus = new GPUModell();

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                SingelSelectGpus.GpuName           = obj["Name"].ToString();
                SingelSelectGpus.VideoRam          = float.Parse(obj["AdapterRAM"].ToString());
                SingelSelectGpus.GpuArtcitecure    = obj["VideoArchitecture"].ToString();
                SingelSelectGpus.GpuDriver         = obj["DriverVersion"].ToString();
                SingelSelectGpus.ApuOrDedicated    = obj["AdapterDACType"].ToString();
                SingelSelectGpus.VideoRam          = float.Parse( obj["AdapterRAM"].ToString() );
                SingelSelectGpus.GPUDriverDate     = obj["DriverDate"].ToString();

                GpusInSystem.Add(SingelSelectGpus);
            }

            return GpusInSystem;
        }
    }
}
