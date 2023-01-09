using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    public enum LastModified {
        Successful,
        NotSuccessful
    }
    public abstract class Parameter {
        private protected double Value;
        public string Units {
            get;
            private protected set;
        }
        public LastModified LastModified {
            get;
            private protected set;
        }

        public Parameter() {

        }
        public Parameter(double value) {
            SetValue(value);
        }
        public double GetValue() {
            return Value;
        }

        public void SetValue(double value) {
            if (value >= 0) {
                Value = value;
                LastModified = LastModified.Successful;
                return;
            }
            LastModified = LastModified.NotSuccessful;
        }

    }
    public abstract class SignalParameter : Parameter {
        public SignalParameter()
            : base() {

        }
        public SignalParameter(double RMSValue)
           : base(RMSValue) {

        }
        public double GetRMS() {
            return Value;
        }
        public double GetPIK() {
            return Value * Math.Sqrt(2);
        }
        public double GetPIKPIK() {
            return Value * 2 * Math.Sqrt(2);
        }
        public void SetRMS(double value) {
            Value = value;
        }
        public void SetPIK(double value) {
            Value = value / Math.Sqrt(2);
        }
        public void SetPIKPIK(double value) {
            Value = value / 2 / Math.Sqrt(2);
        }
    }
    public abstract class VibroParameter : SignalParameter {
        public VibroParameter()
            : base() {

        }
        public VibroParameter(double RmsValue)
            : base(RmsValue) {

        }
        public double Get_dB() {
            double threshold = Math.Pow(10, -6);
            return 20 * Math.Log10(Value / threshold);
        }

    }
}
