using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task7
    {
        // Вычисление суффиксного троичного кода слова с заданной длиной.
        public static string[] CalculateCode(int[] lengths)
        {

            if (lengths.Length == 0)
            {
                Console.WriteLine("Набор пуст.");
                string[] empty = new string[0];

                return empty;
            }

            // Если не выполняется неравенство Макмиллана.
            if (!CheckMacmillan(3, lengths))
            {
                Console.WriteLine("Невозможно построить, поскольку не выполняется неравенство Макмиллана.");
                string[] empty = new string[0];
                return empty;
            }

            // Сортировка по убыванию.
            Array.Sort(lengths);
            Array.Reverse(lengths);

            // Алфавит троичного кода.
            char[] letters = { 'a', 'b', 'c' };

            string res = "";          // Хранит вычисленные код. слова.

            int actual = 0;           // Вспомог. переменная, указатель на букву алфавита. 


            // Проходит по каждой длине.
            for (int i = 0; i < lengths.Length; i++)
            {
                // Если повторяется, то пропускает.
                if (i != 0 && lengths[i] == lengths[i - 1])
                {
                    continue;
                }

                int repeats = lengths.Count(q => q == lengths[i]);     // Количество повторений длины кодового слова.
                int repeatsCount = 0;                                  // Указатель на текущ. повт. длину.

                // Проходит по каждой букве.
                for (int j = 0; j < 3; j++)
                {
                    // Если рассматирваемая буква равна текущей букве,
                    // то пропускает.
                    if (letters[actual] == letters[j])
                    {
                        continue;
                    }

                    string code = new string(letters[actual], lengths[i] - 1);  // Создает код длина - 1.
                    code += letters[j];                                         // Записывает букву в конец.

                    // Записывает в общий результат.
                    res += code + " ";

                    repeatsCount++;

                    // Прерывает, если кол-во текущ. повторений равно кол-ву повторений.
                    if (repeatsCount == repeats)
                    {
                        break;
                    }

                    // Если последняя буква алфавита, то меняется текущ. буква и обнуляется добавочный код.
                    if (j == 2)
                    {
                        actual++;
                        j = -1;
                    }
                }
            }

            string[] output = res.Trim().Split(' ');

            for(int i = 0; i < output.Length; i++)
            {
                // Переворачивание кодового слова,
                // из-за того, что в начале создавалась префиксная система.
                output[i] = new string(output[i].ToCharArray()
                                                .Reverse()
                                                .ToArray());
            }

            Array.Sort(output);

            return output;
        }


        // Метод для проверки длины на неравенство Макмиллана.
        public static bool CheckMacmillan(int num, int[] lengths)
        {

            double sum = 0;

            // Если сумма кол-ва букв в степени минус длин слов <= 1,
            // то неравенство выполняется.
            for(int i = 0; i < lengths.Length; i++)
            {
                sum += Math.Pow(num, -lengths[i]);
            }

            if (sum <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Метод для проверки ввода пользователя.
        public static int CheckUserInput()
        {
            int num;         // Число, введенное пользователем.
            string input;       // Введенная строка.
            do
            {
                input = Console.ReadLine();

                // Проверка ввода, для вывода предупреждения.
                if (!int.TryParse(input, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите действительное число.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (!int.TryParse(input, out num)); // Проверка ввода, если введено целое число, то выходит из цикла.
            return num;
        }


        // Перегрузка метода, проверяющего ввод пользователя.
        // Позволяет установить нижнюю границу для ввода.
        public static int CheckUserInput(int min)
        {
            int num;            // Целое число, введенное пользователем.
            string input;       // Введенная строка.

            do
            {
                input = Console.ReadLine();         // Чтение строки.

                // Проверка ввода целого числа.
                if (!int.TryParse(input, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите целое число больше {min}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Проверка ввода на соответствие границе.
                else if (int.Parse(input) <= min)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите целое число больше {min}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (!int.TryParse(input, out num) || (int.Parse(input) <= min));  // Проверка ввода, если введено целое число, то выходит из цикла.
            return num;
        }
    }
}
