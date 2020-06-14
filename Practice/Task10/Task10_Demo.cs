using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Task10;

namespace Practice
{
    class Task10_Demo
    {
        // Демонстрация работы уничтожения дерева.
        static void Main(string[] args)
        {
            // Создание дерева.
            TreeNode<int> tree = new TreeNode<int>(1, 2, 3, 20, 5, 6, 7);

            // Вывод дерева.
            tree.Show();

            // Демонстрация доп. метода - 
            // вывод макс. значения.
            Console.WriteLine("Максимальное значение дерева: " + tree.Maximum());

            Console.WriteLine("Уничтожение дерева: ");

            tree.DeleteTree();  // Удаление дерева.

            tree.Show();        // Вывод дерева.

            Console.ReadLine();
        }
    }
}
