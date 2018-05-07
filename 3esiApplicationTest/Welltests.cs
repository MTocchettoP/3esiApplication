using System;
using _3esiApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3esiApplicationTest {
    [TestClass]
    public class WellTests {


        Group baseG = new Group("Group A", new Point(6, 6), 5);

        [TestMethod]
        public void Well_Inside_Group() {
            Well w = new Well("Well A", new Point(10, 6), new Point(1, 1));
            bool expected = true;
            bool actual = w.IsInside(baseG);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Well_Outside_Group() {
            Well w = new Well("Well A", new Point(12, 6), new Point(1, 1));
            bool expected = false;
            bool actual = w.IsInside(baseG);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Well_In_Group_Border() {
            Well w = new Well("Well A", new Point(11, 6), new Point(2, 2));
            bool expected = true;
            bool actual = w.IsInside(baseG);
            Assert.AreEqual(expected, actual);
        }
    }
}
