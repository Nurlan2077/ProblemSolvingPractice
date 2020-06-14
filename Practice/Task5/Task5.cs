using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task5
    {
        // Метод для вычисления суммы элементов до последнего отрицательного числа в строке матрицы.
        public static int[] FindSum(int[][] matr)
        {
            int size = matr.Length;             // Размерность матрицы.

            int[] result = new int[size];       // Ответ с суммой строк.
            
            // Проходит по каждой строке матрицы.
            for(int i = 0; i < size; i++)
            {
                int sum = 0;                      // Сумма строки.
                int prevSum = 0;                  // Вспомог. переменная. Хранит предыдущую сумму.
                bool wasNegative = false;         // Вспомог. перемен. Хранит значение, было ли отриц. число в строке.

                // Проходит по каждой ячейке строки.
                for (int j = 0; j < matr[i].Length; j++)
                {
                    sum += matr[i][j];  // Суммирует значения.
                    
                    // Проверяет наличие отриц. числа в ячейке.
                    if (matr[i][j] < 0)
                    {
                        wasNegative = true;
                        prevSum = sum - matr[i][j];
                    }
                }

                // Если не было отриц. чисел в строке,
                // записывает -1.
                if (wasNegative)    result[i] = prevSum;
                else                result[i] = -1;
            }

            return result;
        }


        // Метод для вывода ступенчатых массивов.
        public static void ShowMas(int[][] mas)
        {
            int lenght = mas.Length;    // Количество массивов в ступенчатом массиве.

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write($"{mas[i][j]} ");
                }

                Console.WriteLine();
            }

            if (mas.Length == 0)
            {
                Console.WriteLine("Ваш массив пуст");
            }

            Console.WriteLine();
        }


        // Метод, проверяющий ввод пользователя.
        public static int CheckUserInput()
        {
            int num;        // Целое число, введенное пользователем.
            string input;   // Введенная строка.
            do
            {
                input = Console.ReadLine();

                // Проверка ввода, для вывода предупреждения.
                if (!int.TryParse(input, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите целое число.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (!int.TryParse(input, out num));  // Проверка ввода, если введено целое число, то выходит из цикла.
            return num;
        }
    }
}
