using System;
using _3esiApplication.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace _3esiApplicationTest {
    [TestClass]
    public class LoggerTests {
        [TestMethod]
        public void Logger_Clear() {
            Logger l = Logger.GetInstance();
            String expected = l.ToString();
            l.add("Hello There", "General Kenobi");
            l.Clear();
            String actual = l.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
