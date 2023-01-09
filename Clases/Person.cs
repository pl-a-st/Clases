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
        string name;
        public string Name {
            get { return name; }
            set {
                if (value.Length >= 1) {
                    name = Char.ToUpper(value[0]) + value.Remove(0, 1).ToLower();
                }
            }
        }
        public string Surname {
            get;
            private set;
        }
        public Person(string name, string surname) {
            this.name = name;
            Surname = surname;
        }
        /// <summary>
        /// Поясняющий текст
        /// </summary>
        /// <param name="surname">Фамилия</param>
        public void SetSurname(string surname) {
            if (surname.Length >= 1) {
                Surname = Char.ToUpper(surname[0]) + surname.Remove(0, 1).ToLower();
            }
            else {
                Surname = "Undefined";
            }
        }
        Gender Gender;
        public DateTime DateOfBirth;

        public int GetAge() {
            return (DateTime.Now.Year - DateOfBirth.Year);
        }
    }
}
