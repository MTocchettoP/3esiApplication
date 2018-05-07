using System;
using _3esiApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3esiApplicationTest {
    [TestClass]
    public class HoleTypeTests {
        [TestMethod]
        public void Vertical_Hole1() {
            HoleType ht = new HoleType(new Point(1,1), new Point(1,1));
            String expected = "Vertical";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vertical_Hole2() {
            HoleType ht = new HoleType(new Point(1, 1), new Point(2, 2));
            String expected = "Vertical";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Slanted_Hole1() {
            HoleType ht = new HoleType(new Point(1, 1), new Point(3, 1));
            String expected = "Slanted";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Slanted_Hole2() {
            HoleType ht = new HoleType(new Point(1, 1), new Point(1, 5));
            String expected = "Slanted";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Horizontal_Hole1() {
            HoleType ht = new HoleType(new Point(1, 1), new Point(6, 1));
            String expected = "Horizontal";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Horizontal_Hole2() {
            HoleType ht = new HoleType(new Point(1, 1), new Point(1, 10));
            String expected = "Horizontal";
            String actual = ht.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
