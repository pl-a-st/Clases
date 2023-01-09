using System;

namespace VibroMath {
    static public class Voltage {
        public static double Value {
            get;
            private set;
        } = 102;

        public static string Range = "мВ";
        public static void SetValue(double voltage) {
            Value = voltage;
        }
    }
}
