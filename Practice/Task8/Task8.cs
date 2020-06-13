using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Practice
{
    // Задача 8 - Найти пустой подграф из K вершин.
    public class Task8
    {
        // Метод для поиска пустых подграфов.
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


        // Метод для поиска внутренних независимых множеств.
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


        // Метод для генерации матрицы смежности.
        public static int[][] GenerateInput()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            int rank = rand.Next(3, 10);        // Получает случайное кол-во строк и столбцов матрицы.
            int[][] output = new int[rank][];   // Сгенерированный массив.

            // Создает строки.
            for(int line = 0; line < rank; line++)
            {
                output[line] = new int[rank];

                // Создает столбцы.
                for(int row = 0; row < rank; row++)
                {
                    output[line][row] = rand.Next(0, 2);

                    Thread.Sleep(1);  // Приостанавливает поток для обновления датчика случайных чисел.
                }
            
            }

            return output;
        }


        // Метод для чтения из файла в массив.
        public static int[][] ReadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string input = reader.ReadLine();

            int i = 0;

            try
            {
                // Первая линия для подсчёта количества элементов.
                int[] firstLine = Regex.Split(input.Trim(), @"\s+").Select(Int32.Parse).ToArray();

                int[][] graph = new int[firstLine.Length][];

                graph[0] = firstLine;


                // Считывает все элементы в массив.
                for (i = 1; i < graph.Length; i++)
                {
                    int[] temp = new int[firstLine.Length];
                    temp = reader.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                    graph[i] = temp;
                }

                return graph;
            }
            catch (Exception)
            {
                Console.WriteLine($"Во входном файле строка {i} содержит не только числа.");
                int[][] empty = new int[0][];
                return empty;
            }

        }


        // Метод для вывода графа.
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
