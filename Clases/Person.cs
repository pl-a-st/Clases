using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases {
    public enum Gender {
        Male,
        Femail
    }
    /// <summary>
    /// Описание персоны
    /// Name - имя
    /// </summary>
    public class Person {
        string Name;
        string Sername;
        Gender Gender;
        public DateTime DateOfBirth;

        public int GetAge() {
            return (DateTime.Now.Year - DateOfBirth.Year);
        }
    }
}
