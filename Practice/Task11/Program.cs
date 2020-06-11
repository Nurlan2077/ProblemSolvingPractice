using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Task11
    {
        static void Main(string[] args)
        {
            int[] input = { 1};
            int[] output = Decode(input);
            ShowMas(output);

        }


        // Метод для дешифрования последовательности.
        public static int[] Decode(int[] line)
        {
            List<int> result = new List<int>();     // Хранит результат.

            // Выбрасывает исключение, если кол-во цифр в последовательности не кратно 3.
            if (line.Length % 3 != 0)
            {
                throw new Exception("В последовательности недостает цифр.");
            }

            int sum = 0;    // Вспомог. перемен. хранит сумму трех элем-ов послед-ти.

            // Проходит по всем цифрам.
            for(int i = 0; i < line.Length; i += 1)
            {
                sum += line[i];     // Прибавляет цифру к сумме.

                // Если три цифры пройдено, проверяет сумму.
                if((i + 1) % 3 == 0 && sum < 2)
                {
                    result.Add(0);  // 0, если сумма меньше 2.
                    sum = 0;        // Обнуляет счётчик суммы.
                }
                else if ((i + 1) % 3 == 0 && sum >= 2)
                {
                    result.Add(1);  // 1, если сумма больше 2.
                    sum = 0;        // Обнуляет счётчик суммы.
                }

            }

            // Возвращает массив с цифрами.
            return result.ToArray();
        }

        // Доп. метод для перевода из двоичной системы счисления в десятичную.
        public static int ConvertBinaryToInt10(int[] input)
        {
            string bin = "";    // Хранит цифры последовательности.

            // Переводит цифры последовательности в строку.
            foreach(int elem in input)
            {
                bin += elem;
            }

            // Конвертирует в десятичную.
            int result = Convert.ToInt32(bin, 2);

            return result;
        }

        // Доп. метод для перевода из двоичной системы счисления в 16-ричную.
        public static string ConvertBinaryToInt16(int[] input)
        {
            int num = ConvertBinaryToInt10(input);          // Конвертирует в десятичную.

            string result = Convert.ToString(num, 16);      // Конвертирует из десятичн. в 16-ричную.

            return result;
        }


        // Метод, который выводит значения массива через пробел.
        public static void ShowMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]} ");
            }

            if (mas.Length == 0)
            {
                Console.WriteLine("Ваш массив пуст");
            }

            Console.WriteLine();
        }
    }
}
