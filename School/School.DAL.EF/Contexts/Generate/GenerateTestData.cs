using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Contexts.Generate
{
    public class GenerateTestData
    {
        #region FirstName and LastName
        //50 element in first name
        public string[] firstName = {
            "Август", "Августин", "Авраам", "Миклуха", "Свирид",
            "Агафон", "Николай", "Агний", "Степан", "Аделаид",
            "Аделин", "Адонис", "Акайо", "Акулин", "Алан",
            "Алевтин", "Александр", "Александр", "Алексей", "Алексей",
            "Махбет", "Виталий", "Сергей", "Алсу", "Альберт",
            "Виктор", "Дмитрий", "Альфред", "Кузьма", "Артур",
            "Ян", "Михаил", "Анатолий", "Артём", "Андрей",
            "Евкакий", "Митрофан", "Анисий", "Анна", "Антон",
            "Митя", "Евдаким", "Аполлинарий", "Аполлон", "Хасбик",
            "Аннатолий", "Аристарх", "Аркадий", "Арсен", "Арсений",
           };

        //50 element in last name
        public string[] lastName = {
            "Иванов", "Кузнецов", "Соколов", "Попов", "Лебедев",
            "Козлов", "Новиков", "Морозов", "Петров", "Волков",
            "Соловьёв", "Васильев", "Зайцев", "Павлов", "Семёнов",
            "Голубев", "Виноградов", "Богданов", "Воробьёв", "Фёдоров",
            "Михайлов", "Беляев", "Тарасов", "Белов", "Комаров",
            "Орлов", "Киселёв", "Макаров", "Андреев", "Ковалёв",
            "Ильин", "Гусев", "Титов", "Кузьмин", "Кудрявцев",
            "Баранов", "Куликов", "Алексеев", "Степанов", "Яковлев",
            "Сорокин", "Сергеев", "Романов", "Захаров", "Борисов",
            "Королёв", "Герасимов", "Пономарёв", "Григорьев", "Лазарев",
            };
        #endregion
        #region Phone 
        public static List<string> PhoneListGenerate(int count)
        {
            List<string> Phone = new();
            string[] Code =
            {
            "+375291",
            "+375292",
            "+375290",
            "+375441",
            "+375442",
            "+375443",
            "+375444",
            "+375445",
            "+375446",
            "+375337",
            "+375338",
            "+375339",
            "+375333",
            "+375335",
            "+375336",
            "+375299",
            "+375298",
            "+375297",
            "+375296",
            "+375295",
            };
            Random rnd = new();
            for (int i = 0; i < count; i++)
            {
                string randCode = Code[rnd.Next(0, Code.Length - 1)];
                Phone.Add(randCode + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9) + rnd.Next(0, 9));
            }
            return Phone;
        }
        #endregion
        #region Email
        public static List<string> EmailListGenerate(int count)
        {
            List<string> Email = new();
            string[] ad ={ "@gmail.com", "@mail.ru", "@yandex.ru" };
            Random rnd = new();
            string[] a_s = {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "."
            };

            for (int i = 0; i < count; i++)
            {
                string randsror = ad[rnd.Next(0, ad.Length - 0)];
                string r = a_s[rnd.Next(0, a_s.Length)];
                string ra = a_s[rnd.Next(0, a_s.Length)];
                string rs = a_s[rnd.Next(0, a_s.Length)];
                string rd = a_s[rnd.Next(0, a_s.Length)];
                string rf = a_s[rnd.Next(0, a_s.Length)];
                string rg = a_s[rnd.Next(0, a_s.Length)];
                string rh = a_s[rnd.Next(0, a_s.Length)];
                string rj = a_s[rnd.Next(0, a_s.Length)];
                string rk = a_s[rnd.Next(0, a_s.Length)];
                Email.Add(r + ra + rs + rd + rf + rg + rh + rj + rk + randsror);
            }
            return Email;
        }
        #endregion
        #region Age
        public static int AgeGenerate()
        {
            byte minAgePerson = 16;
            byte maxAgePerson = 80;

            Random rnd = new Random();

            return rnd.Next(minAgePerson, maxAgePerson);
        }
        #endregion
    }
}
