using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task12;

namespace Practice
{
    class Task12_Demo
    {
        // Демонстрация различных видов сортировки массивов.
        static void Main(string[] args)
        {
            int[] chaotic = new int[] { 2, -1, 0, 127, 14, 13, 23, 8, 7, -2 };  // Неупорядоченный массив.
            int[] rising = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };         // По возрастанию.
            int[] declining = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };      // По убыванию.

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cортировка подсчётом: ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.WriteLine("По возрастанию:");
            ShowMas(CountingSort(rising));
            Console.WriteLine("По убыванию:");
            ShowMas(CountingSort(declining));
            Console.WriteLine("Неупорядоченный:");
            ShowMas(CountingSort(chaotic));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка вставками: ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.WriteLine("По возрастанию:");
            ShowMas(InsertionSort(rising));
            Console.WriteLine("По убыванию:");
            ShowMas(InsertionSort(declining));
            Console.WriteLine("Неупорядоченный:");
            ShowMas(InsertionSort(chaotic));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сортировка выбором: ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.WriteLine("По возрастанию:");
            ShowMas(SelectionSort(rising));
            Console.WriteLine("По убыванию:");
            ShowMas(SelectionSort(declining));
            Console.WriteLine("Неупорядоченный:");
            ShowMas(SelectionSort(chaotic));

            Console.WriteLine();
        }
    }
}
