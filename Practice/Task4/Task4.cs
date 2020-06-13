using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task4
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите точность вычисления:");
                double eps = CheckUserInput();

                Console.WriteLine(FindRoot(eps, 2.1, 2.2));
            }
        }


        // Метод для поиска корня уравнения.
        public static double FindRoot(double eps, double left, double right)
        {
            double prevNum = left;  // Хранит предыдущее значение последовательности.
            double actualNum;       // Текущее значение послед-ти.
            double temp;            // Вспомогательная переменная.

            do
            {
                // Высчитывает текущее значение.
                actualNum = prevNum - (Math.Pow(prevNum, 3) - 2 * Math.Pow(prevNum, 2) + prevNum - 3)
                                       /(3*Math.Pow(prevNum, 2) - 4*prevNum + 1);

                Console.WriteLine("Предыдущее число:" + prevNum);
                temp = prevNum;         // Запоминает предыдущее значение для высчитывания разницы.
                prevNum = actualNum;    // Записывает в предыдущее текущее.

                Console.WriteLine("Текущее число:" + actualNum);
                Console.WriteLine("Разница:" + Math.Abs(actualNum - temp));
                Console.WriteLine();

            }
            while (Math.Abs(actualNum - temp) > eps && Math.Abs(actualNum - temp) < right);   // Если модуль разницы пред. и текущ. больше точности,
                                                        // то прекращает вычисление.
            
            // Возвращает последнее вычисленное значение.
            return actualNum;
        }


        // Метод для проверки ввода пользователя.
        public static double CheckUserInput()
        {
            double num;         // Целое число, введенное пользователем.
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
    }
}
