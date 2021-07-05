using System;
using System.Collections.Generic;
using System.Text;

namespace GetHardwareInfo.Services.Modells
{
    public class GPUModell
    {
        public string GpuName { get; set; }
        public string GpuManufactorer { get; set; }
        public string GpuArtcitecure { get; set; }
        public string ApuOrDedicated { get; set; }
        public float VideoRam { get; set; }
        public float CurrentClockSpeed { get; set; }
        public string GpuDriver { get; set; }
        public string GPUDriverDate { get; set; }
    }
}
