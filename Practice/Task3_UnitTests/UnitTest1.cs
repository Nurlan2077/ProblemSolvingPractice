using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Practice.Task3;

namespace Task3_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // Проверка точки в заштрихованной области.
        public void TestCheckPointIn()
        {

            double x = 0;
            double y = 1;

            bool actual = CheckPoint(x, y);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        // Проверка точки вне заштрихованной области.
        public void TestCheckPointOut()
        {
            double x = -10;
            double y = -10;

            bool actual = CheckPoint(x, y);
            bool expected = false;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        // Проверка точки на краю заштрихованной области.
        public void TestCheckPointOnLine()
        {
            double x = 0;
            double y = 0;

            bool actual = CheckPoint(x, y);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        // Проверка перегрузки метода с одним аргументом на заштрихованной области.
        public void TestCheckPointOneArgIn()
        {
            double y = 1;

            bool actual = CheckPoint(y);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }


        [TestMethod]
        // Проверка перегрузки метода с одним аргументом вне заштрихованной области.
        public void TestCheckPointOneArgOut()
        {
            double y = -12;

            bool actual = CheckPoint(y);
            bool expected = false;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        // Проверка перегрузки метода с одним аргументом на краю заштрихованной области.
        public void TestCheckPointOneArgOnLine()
        {
            double y = 0;

            bool actual = CheckPoint(y);
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }
    }
}
