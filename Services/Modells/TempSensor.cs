using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace GetHardwareInfo.Services.Modells
{
    public class TempSensor
    {
        public List<ISensor> Cpusensors { get; set; }
        public List<ISensor> Gpusensors { get; set; }
        public List<ISensor> Motherboarssensors { get; set; }
        public List<ISensor> RamSensors { get; set; }
    }
}
