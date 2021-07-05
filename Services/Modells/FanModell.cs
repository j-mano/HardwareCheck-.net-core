using System;
using System.Collections.Generic;
using System.Text;

namespace GetHardwareInfo.Services.Modells
{
    public class FanModell
    {
        public string Name { get; set; }
        public int RPM { get; set; }
        public long DesiredRPM { get; set; }
        public bool variableSpeed { get; set; }
        public string ErrorDescription { get; set; }
    }
}
