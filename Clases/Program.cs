using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;
using Metrology;



//using Clases.MainClasses;

namespace Clases {
    public enum VerificationStatus {
        Valid,
        Unfit
    }
    class Program {
        static void Main(string[] args) {
            CD23 cd23a = new CD23();
            cd23a.SerialNum = 1;
            CD23 cd23b = new CD23();
            cd23b.SerialNum = 2;
            CD23 cd23c = new CD23(3, DateTime.Now);
            cd23c.DateVerification = DateTime.Now.AddDays(-5);
            int daysBeforeVerificatio = cd23c.GetDaysBeforeVerification();
            cd23a.SetVerification(VerificationStatus.Valid, DateTime.Now.AddDays(-5));
            cd23a.SetVerification(VerificationStatus.Valid);
            int verificationIntervalDays = CD23.VerificationIntervalDays;
            //verificationIntervalDays = cd23a.VerificationIntervalDays; // ошибка, нужно обращаться через название класса
            int weeks = CD23.GetVerificationIntervalWeeks();

            CD23EX cd23EX = new CD23EX();


            Person verin = new Person("Сергей", "Верин");
            verin.DateOfBirth = new DateTime(1985, 6, 3);
            verin.Name = "сЕргей";
            verin.SetSurname(string.Empty);
            int age = verin.GetAge();

            MainClass mainClass = new MainClass();

            for (int i = 0; i < 20; i++) {
                Console.WriteLine(Name.GetName());
            }

            Voltage voltage = new Voltage(100);

            voltage.SetPIK(141.4);
            Frequency frequency = new Frequency(159.17);
            double frq = frequency.GetValue();
            double frqRPM = frequency.GetRPM();
            Acceleration acceleration = new Acceleration(1);
            double dBA = acceleration.Get_dB();
            double dBU = voltage.Get_dB();
            VibroCalc.SetVoltage(new Acceleration(9.8077777777777777));
            VibroCalc.SetSignalParams(acceleration);

            double acc = VibroCalc.Acceleration.GetRMS();

            double vel = VibroCalc.Velocity.GetRMS();
            double exemple = MetrologyRound.GetRounded(number: -555.59, countMainChars: 4);

        }

    }
    class Exemple {  //Имя
        // Поля - переменные;
        // Методы - поведение описываемое классом
    }
    public class CD23 {
        public int SerialNum;
        string SoftwareVersion = "5.31";
        DateTime Date;
        public VerificationStatus VerificationStatus;
        public DateTime DateVerification;
        public static int VerificationIntervalDays {
            get;
            private set;
        } = 365;
        /// <summary>
        /// Создание прибора
        /// </summary>
        public CD23() {

        }
        /// <summary>
        /// Создание прибора
        /// </summary>
        /// <param name="serialNum"> серийный номер </param>
        /// <param name="date">Дата создания</param>
        public CD23(int serialNum, DateTime date) {
            SerialNum = serialNum;
            Date = date;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Возвращает число дней до поверки</returns>
        public int GetDaysBeforeVerification() {
            int days = (DateVerification.AddDays(VerificationIntervalDays) - DateTime.Now).Days;
            if (days > 0 && VerificationStatus == VerificationStatus.Valid) {
                return days;
            }
            return 0;
        }
        public void SetVerification(VerificationStatus verificationStatus, DateTime date) {
            VerificationStatus = verificationStatus;
            DateVerification = date;
        }
        public void SetVerification(VerificationStatus verificationStatus) {
            SetVerification(verificationStatus, DateTime.Now);
        }
        public static int GetVerificationIntervalWeeks() {
            const int DAYS_IN_WEEK = 7;
            //int serialNum = SerialNum; // ошибка. SerialNum не статическое поле.
            return VerificationIntervalDays / DAYS_IN_WEEK;
        }
    }

    public class CD23EX : CD23 {
        DateTime DateFinishSertificate;
        public static new int VerificationIntervalDays = 456;
        public new int SerialNum;
        public new int GetDaysBeforeVerification() {
            int serialNum = base.SerialNum;
            int days = (DateVerification.AddDays(VerificationIntervalDays) - DateTime.Now).Days;
            if (days > 0 && VerificationStatus == VerificationStatus.Valid) {
                return days;
            }
            return 0;
        }
    }
}
