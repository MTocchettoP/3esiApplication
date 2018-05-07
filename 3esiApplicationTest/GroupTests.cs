using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3esiApplication.Model;

namespace _3esiApplicationTest {
    [TestClass]
    public class GroupTests {

        [TestMethod]
        public void Groups_Dont_Intersect(){
            Group a = new Group("Group A", new Point(6, 6), 5);
            Group b = new Group("Group B", new Point(16, 9), 3);
            bool expected = false;
            bool actual = a.Intersect(b);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Groups_Intersect() {
            Group a = new Group("Group A", new Point(6, 6), 5);
            Group b = new Group("Group B", new Point(13, 6), 3);
            bool expected = true;
            bool actual = a.Intersect(b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Group_Inside_Group() {
            Group a = new Group("Group A", new Point(6, 6), 5);
            Group b = new Group("Group B", new Point(4, 6), 1);
            bool expected = true;
            bool actual = a.Intersect(b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Groups_Touch_Borders() {
            Group a = new Group("Group A", new Point(6, 6), 5);
            Group b = new Group("Group B", new Point(14, 6), 3);
            bool expected = true;
            bool actual = a.Intersect(b);
            Assert.AreEqual(expected, actual);
        }
    }
}
