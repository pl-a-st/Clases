using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Person verin = new Person();
            verin.DateOfBirth = new DateTime(1985, 6, 3);
            int age = verin.GetAge();
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
        int VerificationIntervalDays = 365;
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
    }
}
