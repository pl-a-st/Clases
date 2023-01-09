using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath
{
    public class Voltage : SignalParameter {
        public Voltage(double RmsValue)
            : base(RmsValue) {
            Units = "мВ";
        }
        public double Get_dB() {
            double threshold = Math.Pow(10, -3);
            return 20 * Math.Log10(Value / threshold);
        }
    }
    
    public class Acceleration : VibroParameter {
        public Acceleration(double RmsValue)
            : base(RmsValue) {
            Units = "м/с²";
        }
    }
    public class Frequency : Parameter {
        public Frequency(double value)
            : base(value) {
            Units = "Гц";
        }
        public double GetHz() {
            return Value;
        }
        public double GetRPM() {
            return Value*60;
        }
    }
    public class Velocity : VibroParameter {
        public Velocity(double RmsValue)
            : base(RmsValue) {
            Units = "мм/с";
        }
    }
    public class Sensitivity : VibroParameter {
        public Sensitivity(double value)
            : base(value) {
            Units = "мВ/g";
        }
    }
}
