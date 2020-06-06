using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Practice.Task6;

namespace Task6_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /* Проверка FindNum()                              */

        [TestMethod]
        // Проверка кол-ва вычисл. значений = 1.
        public void TestFindNumNumOne()
        {
            double[] firstElems = new double[3];

            firstElems[0] = 1;
            firstElems[1] = 2;
            firstElems[2] = 3;

            int num = 1;

            double[] actual = new double[num];
            double[] expected = new double[] {1};


            FindNum(firstElems, num, ref actual);

            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        // Проверка кол-ва вычисл. значений = 4.
        public void TestFindNumNumFour()
        {
            double[] firstElems = new double[3];

            firstElems[0] = 1;
            firstElems[1] = 3;
            firstElems[2] = 3;

            int num = 4;

            double[] actual = new double[num];
            double[] expected = new double[] { 1, 3, 3, 7};


            FindNum(firstElems, num, ref actual);

            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        // Проверка отрицательных значений.
        public void TestFindNumNegatives()
        {
            double[] firstElems = new double[3];

            firstElems[0] = -1;
            firstElems[1] = -3;
            firstElems[2] = -3;

            int num = 4;

            double[] actual = new double[num];
            double[] expected = new double[] { -1, -3, -3, -7 };


            FindNum(firstElems, num, ref actual);

            CollectionAssert.AreEqual(actual, expected);
        }


        /* Проверка AnalizeSequence()                              */
        [TestMethod]
        // Проверка анализа различных последовательностей.
        public void TestAnalizeSequenceMSR()
        {
            int[] actual = new int[5];

            // Строгая возрастающая.
            double[] test = new double[] { 1, 2, 3, 4, 5 };
            actual[0] = AnalizeSequence(test);

            // Нестрогая возрастающая.
            test = new double[] { 1, 1, 3, 4, 5 };
            actual[1] = AnalizeSequence(test);

            // Строгая убывающая.
            test = new double[] { -1, -2, -3, -4, -5 };
            actual[2] = AnalizeSequence(test);

            // Нестрогая убывающая.
            test = new double[] { -1, -1, -3, -4, -5 };
            actual[3] = AnalizeSequence(test);

            // Немонотонная.
            test = new double[] { -1, 5, -3, 0, -5 };
            actual[4] = AnalizeSequence(test);

            int[] expected = new int[] { 11, 10, 21, 20, 0 };

            CollectionAssert.AreEqual(actual, expected);
        }



    }
}
