using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Practice.Task5;

namespace Task5_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        // Проверка матрицы со строками без отриц. чисел.
        [TestMethod]
        public void TestFindSumWithoutNegatives()
        {
            int[][] matr = new int[3][];
            matr[0] = new int[] { 1, 2, 3 };
            matr[1] = new int[] { 1, 2, 3 };
            matr[2] = new int[] { 1, 2, 3 };


            Random rand = new Random();

            int[] actual = FindSum(matr);
            int[] expected = new int[] { -1, -1, -1};

            CollectionAssert.AreEqual(actual, expected);
        }


        // Проверка матрицы со строками с 1 отриц. числом.
        [TestMethod]
        public void TestFindSumWithOneNegative()
        {
            int[][] matr = new int[3][];
            matr[0] = new int[] { 1, 2, -3 };
            matr[1] = new int[] { 1, -2, 3 };
            matr[2] = new int[] { -1, 2, 3 };


            Random rand = new Random();

            int[] actual = FindSum(matr);
            int[] expected = new int[] { 3, 1, 0 };

            CollectionAssert.AreEqual(actual, expected);
        }


        // Проверка матрицы со строками со всеми отриц. числами.
        [TestMethod]
        public void TestFindSumWithAllNegatives()
        {
            int[][] matr = new int[3][];
            matr[0] = new int[] { -1, -2, -3 };
            matr[1] = new int[] { -1, -3, -3 };
            matr[2] = new int[] { -1, -4, -3 };


            Random rand = new Random();

            int[] actual = FindSum(matr);
            int[] expected = new int[] { -3, -4, -5 };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
