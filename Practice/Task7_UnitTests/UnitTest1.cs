using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Practic.Task7;

namespace Task7_UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        // Проверка вычисления кода с единичным повторением.
        public void TestCalculateCodeOneRepeat()
        {
            int[] lengths = { 1, 1 };

            string[] actual = CalculateCode(lengths);

            string[] expected = { "b", "c" };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        // Проверка вычисления кода с множественным повторением.
        public void TestCalculateCodeMultipleRepeat()
        {
            int[] lengths = { 3, 2, 2, 2 };

            string[] actual = CalculateCode(lengths);

            string[] expected = { "ab", "ba", "baa", "ca" };

            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        // Проверка вычисления кода без повторений.
        public void TestCalculateCodeZeroRepeat()
        {
            int[] lengths = { 1, 2, 3, 4 };

            string[] actual = CalculateCode(lengths);

            string[] expected = { "b", "ba", "baa", "baaa" };

            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        // Проверка вычисления кода без повторений.
        public void TestCheckMacmillan()
        {
            int[] lengths = { 1, 1, 1, 1 };

            bool actual = CheckMacmillan(3, lengths);

            bool expected = false;

            Assert.AreEqual(actual, expected);
        }
    }
}
