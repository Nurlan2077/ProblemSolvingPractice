using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    // Реализация методов сортировки вставками, выбором и подсчётом.
    public class Task12
    {
        // Сортировка вставками.
        public static int[] InsertionSort(int[] input)
        {
            int countTransfer   = 0;    // Количество перемещений элементов массива.
            int countComparison = 0;    // Количество сравнений.

            // Проходит по всем элементам массива.
            for (int actualCursor = 1; actualCursor < input.Length; actualCursor++)
            {
                countComparison++;

                int unsortedCursor;

                int temp = input[actualCursor];  // Вспомог. перемен. хранит текущ. элемент.

                // Проходит по несортированной части.
                for (unsortedCursor = actualCursor - 1; unsortedCursor >= 0; unsortedCursor--)
                {
                    countComparison++;

                    countComparison++;

                    // Если предыдущ. элемент, не меньше текущ., 
                    // то прерывает цикл.
                    if (input[unsortedCursor] < temp)
                    {
                        break;
                    }

                    // Меняет след. элемент с текущим.
                    input[unsortedCursor + 1] = input[unsortedCursor];
                    countTransfer++;
                }

                // Вставляет меньший найденный элемент.
                input[unsortedCursor + 1] = temp;
                countTransfer++;

            }

            Console.WriteLine($"Количество сравнений: {countComparison}");
            Console.WriteLine($"Количество пересылок: {countTransfer}");

            return input;
        }


        // Метод для сортировки простым выбором.
        public static int[] SelectionSort(int[] input)
        {
            int min;                    // Хранит мин. значение.
            int temp;                   // Вспомог. перемен. для хранения предыдущ. элемента.
            int countTransfer   = 0;    // Количество перемещений элементов массива.
            int countComparison = 0;    // Количество сравнений.


            // Проходит по всем элементам массива.
            for (int sortedCursor = 0; sortedCursor < input.Length - 1; sortedCursor++)
            {
                countComparison++;


                min = sortedCursor;    // Текущий элемент становится минимальным.

                countTransfer++;

                // Проходит по остальным элементам массива.
                for (int unsortedCursor = sortedCursor + 1; unsortedCursor < input.Length; unsortedCursor++)
                {
                    countComparison++;

                    countComparison++;

                    // Если след. элемент меньше текущего минимума,
                    // то заменяет.
                    if (input[unsortedCursor] < input[min])
                    {
                        min = unsortedCursor;

                        countTransfer++;

                    }
                }

                // Если минимум не равен текущему элементу,
                // меняет местами текущий элемент и минимальный.

                countComparison++;

                if (min != sortedCursor)
                {
                    temp = input[sortedCursor];
                    input[sortedCursor] = input[min];
                    input[min] = temp;

                    countTransfer += 3;
                }
            }


            Console.WriteLine($"Количество сравнений: {countComparison}");
            Console.WriteLine($"Количество пересылок: {countTransfer}");

            return input;
        }


        // Дополнительный метод для сортировки подсчётом.
        public static int[] CountingSort(int[] input)
        {
            int countTransfer = 0;      // Количество перемещений элементов массива.
            int countComparison = 0;    // Количество сравнений.

            // Вспомог. переменная.
            int[] temp = new int[input.Length];

            
            int min = input[0];  // Минимальное значение массива.
            int max = input[0];  // Максимальное значение.

            // Проходит по всем элементам массива,
            // находит мин и макс значение.
            for (int i = 1; i < input.Length; i++)
            {   
                if (input[i] < min)
                {
                    min = input[i];
                }
                else if (input[i] > max)
                {
                    max = input[i];
                    countComparison++;
                }

                countComparison += 2;

            }

            // Массив для подсчёта.
            int[] counts = new int[max - min + 1];

            // Заполняет массив для подсчёта числами от мин до макс.
            for (int i = 0; i < input.Length; i++)
            {
                counts[input[i] - min]++;
                countComparison++;
            }

            // Декрементирует первый элемент.
            counts[0]--;

            // Заполняет массив для подсчёта.
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
                countTransfer++;
                countComparison++;
            }

            // Сортирует массив.
            for (int i = input.Length - 1; i >= 0; i--)
            {
                temp[counts[input[i] - min]--] = input[i];
                countTransfer++;
                countComparison++;
            }

            Console.WriteLine($"Количество сравнений: {countComparison}");
            Console.WriteLine($"Количество пересылок: {countTransfer}");

            return temp;
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
