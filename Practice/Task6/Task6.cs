using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{   
    // Решение задачи 6.
    public class Task6
    {
        // Метод для высчитывания чисел последовательности.
        public static void FindNum(ref double[] elems, int count)
        {
            // Вычисляет текущий элемент. 
            elems[count] = elems[count - 3]
                           + elems[count - 2] / 3
                           + 3 * elems[count - 1];

            Console.WriteLine("Элемент последовательности: " + elems[count]);

            // Проверяет на заполнение массива. 
            if (count + 1 < elems.Length)
            {
                FindNum(ref elems, count + 1);
            }
        }



        // Метод для анализа последовательности на монотоноость.
        public static int AnalizeSequence(double[] sequence)
        {
            bool monotonyR = false;     // Монотонность возрастающая.
            bool monotonyD = false;     // Монотонность убывающая.

            bool strict = true;         // Строгость монотонности.


            // Если в последовательности меньше двух чисел,
            // то завершает выполнение.
            if (sequence.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В последовательности недостаточно чисел для анализа.");
                Console.ForegroundColor = ConsoleColor.White;

                return -1;
            }

            // Проверяет на монотонную возрастающую.
            for(int i = 0; i < sequence.Length - 1; i++)
            {
                // Если след. элемент больше предыдущ., то монотонность возрастающая.
                if (sequence[i] < sequence[i + 1])
                {
                    monotonyR = true;
                }
                // Если след. элемент равен предыдущ., то монотонность нестрогая.
                else if (sequence[i] == sequence[i + 1])
                {
                    strict = false;
                }
                // Если след. элемент меньше предыдущ., то нет монотонности.
                else if (sequence[i] > sequence[i + 1])
                {
                    monotonyR = false;
                    break;
                }
            }

            // Проверяет на монотонную убывающую.
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                // Если след. элемент меньше предыдущ., то монотонность убывающая.
                if (sequence[i] > sequence[i + 1])
                {
                    monotonyD = true;
                }
                // Если след. элемент равен предыдущ., то монотонность нестрогая.
                else if (sequence[i] == sequence[i + 1])
                {
                    strict = false;
                }
                // Если след. элемент больше предыдущ., то нет монотонности.
                else if (sequence[i] < sequence[i + 1])
                {
                    monotonyD = false;
                    break;
                }
            }


            // Вывод результата.
            if (monotonyR)
            {
                if (strict)
                {
                    // Числовая последовательность монотонная строго возрастающая.
                    return 11;
                }
                else
                {
                    // Числовая последовательность монотонная нестрого возрастающая.
                    return 10;
                }
            }
            else if (monotonyD)
            {
                if (strict)
                {
                    // Числовая последовательность монотонная строго убывающая.
                    return 21;

                }
                else
                {
                    // Числовая последовательность монотонная нестрого убывающая.
                    return 20;
                }
            }
            else
            {
                // Числовая последовательность не монотонная.
                return 0;
            }

        }


        // Метод для проверки ввода пользователя.
        public static double CheckUserInput()
        {
            double num;         // Число, введенное пользователем.
            string input;       // Введенная строка.
            do
            {
                input = Console.ReadLine();

                // Проверка ввода, для вывода предупреждения.
                if (!double.TryParse(input, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите действительное число.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (!double.TryParse(input, out num)); // Проверка ввода, если введено целое число, то выходит из цикла.
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
