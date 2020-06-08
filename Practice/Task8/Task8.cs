using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Practice
{
    // Найти пустой подграф из K вершин.
    class Task8
    {
        static void Main(string[] args)
        {
            string filePath = "../../input.txt";

            int[][] graph = ReadFromFile(filePath);

            ShowGraph(graph);

            List<Sets> output = FindEmptySubgraphs(graph);

            Console.WriteLine("Введите количество вершин:");
            int num = CheckUserInput(0);

            Console.WriteLine("Пустые подграфы: ");

            bool isNumFits = false;

            foreach (Sets elem in output)
            {
                if (elem.Count == num)
                {
                    isNumFits = true;
                    foreach (int el in elem)
                    {
                        Console.Write(el + " ");
                    }
                }
                
                Console.WriteLine();
            }

            if (!isNumFits && output.Count > 0)
            {
                Console.WriteLine("Пустых подграфов с введенным количеством вершин нет.");
                Console.WriteLine();

                Console.WriteLine("Есть пустые подграфы: ");

                foreach (Sets elem in output)
                {
                    foreach (int el in elem)
                    {
                        Console.Write(el + " ");
                    }

                    Console.WriteLine();
                }
            }

        }
        


        // Поиск пустых подграфов
        public static List<Sets> FindEmptySubgraphs(int[][] graph)
        {
            List<Sets> indPointList = FindIndependentPoints(graph);

            List<Sets> result = new List<Sets>();

            // Проходит по каждому множеству из списка множеств.
            foreach (Sets indPoints in indPointList)
            {
                bool isEmptySubgraph = false;

                // Проходит по каждой строке матрицы смежности.
                for (int i = 0; i < graph.Length; i++)
                {
                    // Проходит по каждой вершине из множества.
                    foreach (int indPoint in indPoints)
                    {
                        // Если вершина из матрицы смежности,
                        // имеет общее ребро с вершиной из множества, 
                        // то подграф является пустым.
                        if (i != indPoint && graph[i][indPoint] == 1)
                        {
                            isEmptySubgraph = true;
                            break;
                        }
                    }

                    if (isEmptySubgraph)
                    {
                        break;
                    }
                }

                if (isEmptySubgraph)
                {
                    result.Add(indPoints);
                }
            }

            return result;
        }


        // Находит внутренние независимые множества.
        public static List<Sets> FindIndependentPoints(int[][] input)
        {
            List<Sets> independents = new List<Sets>();
        
            // Проходит по строкам матрицы.
            for (int i = 0; i < input.Length; i++)
            {
                Sets temp = new Sets();

                // Проходит по элементам строки.
                for (int j = 0; j < input[i].Length; j++)
                {
                    // Добавляет все элементы, с которыми вершина не смежная.
                    if (input[i][j] == 0)
                    {
                        temp.Add(j);
                    }
                }

                Sets nums = new Sets();
                 
                // Копирует элементы в nums.
                foreach(int elem in temp)
                {
                    nums.Add(elem);
                }

                // Проверяет на наличие смежныж вершин.
                foreach (int elem in temp)
                {
                    foreach(int elem2 in temp)
                    {
                        if(input[i][elem] != input[elem][elem2])
                        {
                            nums.Remove(elem);
                        }
                    }
                }

                if (nums.Count < 3 || independents.Contains(nums))
                {
                    continue;
                }
                else
                {
                    independents.Add(nums);
                }

            }

            return independents;
        }


        // Класс множеств.
        public class Sets : List<int>, IEquatable<Sets>
        {

            // Реализация метода интерфейса для сравнения экземпляров класса.
            public bool Equals(Sets other)
            {
                // Если количество элементов не равно, то не одинаковы.
                if (this.Count != other.Count)
                {
                    return false;
                }

                // Проходит по всем элементам.
                for (int i = 0; i < this.Count; i++)
                {
                    // Если хотя бы один элемент не равен соотв. из другого списка,
                    // то не одинаковы.
                    if (this[i] != other[i])
                    {
                        return false;
                    }
                }

                // Если все элементы равны, возвращает true.
                return true;
            }
        }


        // Чтение из файла в массив.
        public static int[][] ReadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string input = reader.ReadLine();

            // Первая линия для подсчёта количества элементов.
            int[] firstLine = Regex.Split(input.Trim(), @"\s+").Select(Int32.Parse).ToArray();

            int[][] graph = new int[firstLine.Length][];

            graph[0] = firstLine;

            // Считывает все элементы в массив.
            for (int i = 1; i < graph.Length; i++)
            {
                int[] temp = new int[firstLine.Length];
                temp = reader.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                graph[i] = temp;
            }

            return graph;
        }


        // Вывод графа.
        public static void ShowGraph(int[][] mas)
        {
            int lenght = mas.Length;    // Количество массивов в ступенчатом массиве.

            // Отступ для вида.
            Console.Write("  ");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < lenght; i++) Console.Write($"X{i} ");   // Вывод названий вершин.
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            // Вывод элементов матрицы смежности.
            for (int i = 0; i < lenght; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"X{i} ");
                Console.ForegroundColor = ConsoleColor.White;

                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write($"{mas[i][j]}  ");
                }

                Console.WriteLine();
            }

            if (mas.Length == 0)
            {
                Console.WriteLine("Ваша матрица пуста.");
            }

            Console.WriteLine();
        }

        // Метод, проверяющий ввод пользователя.
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
