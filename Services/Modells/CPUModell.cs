using System;
using System.Collections.Generic;
using System.Text;

namespace GetHardwareInfo.Services.Modells
{
    public class CPUModell
    {
        public string CpuName { get; set; }
        public short CpuCores { get; set; }
        public short NumberOfLogicalProcessors { get; set; }
        public string CpuManufactorer { get; set; }
        public string CpuArtcitecure { get; set; }
        public float TurboClockSpeed { get; set; }
        public bool SupportVirtulatation { get; set; }
    }
}
