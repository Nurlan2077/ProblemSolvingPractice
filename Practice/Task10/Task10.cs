using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Task10
    {
        // Класс узла дерева.
        public class TreeElement<T>
        {
            public T Data { get; set; }                 // Данные.
            public TreeElement<T> Left { get; set; }    // Ссылка на элемент слева.
            public TreeElement<T> Right { get; set; }   // Ссылка на элемент справа.

            // Конструктор без параметров для создание элемента дерева.
            public TreeElement()
            {
                Data = default(T);      // Данные.
                Left = null;            // Расположение относительно родителя.
                Right = null;
            }

            // Конструктор с параметром для создания элемента дерева.
            public TreeElement(T data)
            {
                Data = data;            // Данные.
                Left = null;            // Расположение относительно родителя.
                Right = null;
            }

            // Перевод в строку.
            public override string ToString()
            {
                return Data.ToString() + " ";
            }
        }


        // Класс для дерева.
        public class TreeNode<T> where T : IComparable
        {
            // Корень дерева.
            TreeElement<T> root;

            // Корень дерева.
            public TreeElement<T> Root
            {
                get { return root; }
                set { root = value; }
            }

            // Конструктор без параметров, 
            // создает дерево с нулевым корнем.
            public TreeNode()
            {
                root = null;
            }

            // Конструктор с параметром,
            // создает дерево с даными.
            public TreeNode(params T[] datas)
            {
                int i = 0;
                root = MakeTree(datas.Length, root, ref i, datas);
            }

            // Рекурсивный метод создания дерева.
            private TreeElement<T> MakeTree(int num, TreeElement<T> root, ref int i, params T[] datas)
            {
                if (num == 0) 
                { 
                    root = null; 
                    return root;
                }

                int countLeft = num / 2;                // Количество узлов слева.
                int countRight = num - countLeft - 1;   // Количество узлов справа.

                // Создает элемент с данными.
                TreeElement<T> treeElement = new TreeElement<T>(datas[i]);

                i++;

                treeElement.Left = MakeTree(countLeft, treeElement.Left, ref i, datas);     // Создание ветви слева.
                treeElement.Right = MakeTree(countRight, treeElement.Right, ref i, datas);  // Создание ветви справа.

                // Возвращает элемент дерева.
                return treeElement;
            }

            // Метод для уничтожение дерева.
            public void DeleteTree()
            {
                root = null;    // Обнуляет корень.
            }

            // Дополнительное поле максимум.
            public TreeElement<T> Maximum()
            {
                TreeElement<T> max = this.root; 

                return GetMax(root, ref max);
            }

            // Дополнительный рекурсивный метод для получения максимального элемента.
            private TreeElement<T> GetMax(TreeElement<T> root, ref TreeElement<T> max)
            {
                // Пока не корень дерева, ищет максимальное.
                if (root != null)
                {
                    // Если значение больше, то заменяет макс. значение на него.
                    if (root.Data.CompareTo(max.Data) == 1)
                    { 
                        max = root; 
                    }

                    // Проходит по всем ветвям.
                    GetMax(root.Left, ref max); 
                    GetMax(root.Right, ref max);
                }

                return max;
            }

            // Рекурсивный метод, для вывода дерева.
            private void ShowTree(TreeElement<T> root, int l)
            {
                if (root != null)
                {
                    ShowTree(root.Left, l + 3);

                    for (int i = 0; i < l; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.WriteLine(root.Data + "-<");

                    ShowTree(root.Right, l + 3);
                }
            }


            // Метод для вывода дерева.
            public void Show()
            {
                Console.WriteLine();

                ShowTree(root, 3);

                Console.WriteLine();
            }


        }
    }
}
