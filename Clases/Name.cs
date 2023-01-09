using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases {
    static class Name {
        static Random Random = new Random();
        static int Counter = 0;
        static string[] MenNames = new[] { "Сергей", "Андрей", "Владимир", "Павел", "Эдуард", "Руслан" };
        static string[] WomenNames = new[] { "Света", "Алена", "Агафья" };
        public static string GetName() {
            Counter++;
            if (Counter % 2 > 0) {
                return MenNames[Random.Next(MenNames.Length)];
            }
            return WomenNames[Random.Next(WomenNames.Length)];
        }
    }
}
