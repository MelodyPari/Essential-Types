using System;
using System.Globalization;
using System.Text;

namespace Chars__String._and_Working_with_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Пример проверок, что символ является числом/пробелом (через статические методы Char)");
            
            char digit = '1';
            char whitespace = ' ';
            if (char.IsDigit(digit)) Console.WriteLine($"{digit} is digit");
            if (char.IsWhiteSpace(whitespace)) Console.WriteLine($"{whitespace} is whitespace");

            Console.WriteLine("\n2. Два разных примера буквальной строки");
            
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            char infinity = '\u221E';
            string infinityCode = @"\u221E"; //Пример 1
            Console.WriteLine($"{infinity} code is {infinityCode}");
            string str = @"A backslash-like symbol is used for the set difference: A\B"; //Пример 2
            Console.WriteLine(str);

            //3. Примеры со сравнением строк через методы класса String (Equals/Compare/StartsWith/EndsWith).
            Console.WriteLine("\n3. Примеры со сравнением строк через методы класса String (Equals/Compare/StartsWith/EndsWith).");
            
            string str1 = "abcd";
            string str2 = "abcde";
            Console.WriteLine(str1.Equals(str2));//Определяет равенство значений
            Console.WriteLine(string.Compare(str1, str2));//Определяет относительное положение в порядке сортировки
            Console.WriteLine(str2.StartsWith(str1));
            Console.WriteLine(str1.EndsWith("d"));

            //4.Примеры Clone / Copy / Substring операций для строки
            Console.WriteLine("\n4.Примеры Clone / Copy / Substring операций для строки");
            
            string str3 = (string)str1.Clone();//возвращает ссылку на значение str1
            string str4 = string.Copy(str1); //Устаревший метод, создает новый экземпляр string с таким же значением что у str1
            string str5 = str1.Substring(0, 2);

            //5.Пример на StringBuilder.
            Console.WriteLine("\n5.Пример на StringBuilder.");

            StringBuilder sb = new StringBuilder();
            sb.Append(str1);
            sb.Replace('a', '4');
            Console.WriteLine(sb.ToString());

            //6.Пример форматирования строки через IFormatProvider(на String или StringBuilder)
            Console.WriteLine("\n6.Пример форматирования строки через IFormatProvider(на String или StringBuilder)");
            
            decimal price = 123.54M;
            string s = price.ToString("C", new CultureInfo("zh-HK"));
            Console.WriteLine(s);

            //7.Пример работы со String.Format(с форматированием и без него)
            Console.WriteLine("\n7.Пример работы со String.Format(с форматированием и без него)");

            string str6 = string.Format("{0} code is {1}", infinity, infinityCode);
            Console.WriteLine(str6);
            str6 = string.Format("{0,3:G}:{0,3:X}", 16);
            Console.WriteLine(str6);

            //8.Пример получения числа из строки(метод Parse для любого числового типа).
            str6 = "123456";
            int number = int.Parse(str6);

            //9.Кодирование и декодирование строки(через Encoding).
            Console.WriteLine("\n9.Кодирование и декодирование строки(через Encoding).");
            
            var encodedStr = Encoding.UTF7.GetBytes(str6);
            Console.WriteLine(BitConverter.ToString(encodedStr)+ "=" + Encoding.UTF7.GetString(encodedStr));

            //10.Пример перечисления на базе любого типа кроме int.
            Console.WriteLine("\n10.Пример перечисления на базе любого типа кроме int.");
            
            Weather weather = Weather.Rainy;
            Console.WriteLine(weather + "=" + weather.ToString("D"));

            //11.Пример нерегулярного(jagged) массива.
            Console.WriteLine("\n11.Пример нерегулярного(jagged) массива.");

            int n = 3;
            int[][] jaggedArray = new int[n][];
            jaggedArray[0] = new int[8];
            jaggedArray[1] = new int[2];
            jaggedArray[2] = new int[5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = i;
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public enum Weather : byte
        {
            Sunny,
            Windy,
            Rainy
        }
    }
}
