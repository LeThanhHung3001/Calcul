using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Caculation c;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void SetUp()
        {
            c = new Caculation(10, 5);
        }
        [TestMethod]
        public void TestAddOperator()
        {
            int expected , actual;
           // Caculation c = new Caculation(10, 5);
            expected = 15;
            actual = c.Execute("+");
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void TestSubOperator()
        {
            int expected, actual;
            //Caculation c = new Caculation(10, 5);
            expected = 5;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMulOperator()
        {
            int expected, actual;
           // Caculation c = new Caculation(10, 5);
            expected = 50;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            c = new Caculation(10, 0);
            c.Execute("/");
           
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
@".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[2].ToString());
            Caculation c = new Caculation(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
    }
}
