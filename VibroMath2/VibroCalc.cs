using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    static public class VibroCalc {
        const int IntegrationFactor = 1000;
        static public Voltage Voltage {
            get;
            private set;
        } = new Voltage(102);
        static public Sensitivity Sensitivity {
            get;
            private set;
        } = new Sensitivity(100);
        static public Acceleration Acceleration {
            get;
            private set;
        } = new Acceleration(10);
        static public Frequency Frequency {
            get;
            private set;
        } = new Frequency(159.127);
        static public Velocity Velocity {
            get;
            private set;
        } = new Velocity(10);

        public static void SetVoltage(double value) {
            Voltage.SetValue(value);
        }
        public static void SetVoltage(Acceleration acceleration) {
            double voltage = acceleration.GetRMS() * Sensitivity.GetValue() / 9.807;
            Voltage.SetValue(voltage);
        }
        public static void SetVoltage(Velocity velocity) {
            double acceleration = velocity.GetRMS() * 2 * Math.PI * Frequency.GetValue() / 
                                  IntegrationFactor;
            SetVoltage(new Acceleration(acceleration));
        }
        private static void SetAcceleration() {
            double acceleration = Voltage.GetRMS() / Sensitivity.GetValue() * 9.807;
            Acceleration.SetValue(acceleration);
        }
        private static void SetVelocity() {
            double velocity = Acceleration.GetRMS() / 2 / Math.PI / Frequency.GetValue() *
                                  IntegrationFactor;
            Velocity.SetValue(velocity);
        }
        /// <summary>
        /// Производит расчет всех параметров 
        /// </summary>
        /// <param name="parameter"> 
        /// Acceleration, Velocity, Displasment - или Voltage 
        /// </param>
        public static void SetSignalParams(Parameter parameter) {
            if (parameter is Velocity) {
                SetVoltage(parameter as Velocity);
            }
            SetAcceleration();
            SetVelocity();
        }
    }
}
