using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3esiApplication.Util;
using _3esiApplication.Model;
using _3esiApplication.Exception;

namespace _3esiApplicationTest {

    [TestClass]
    public class FactoryTest {

        Group baseG = new Group("Group A", new Point(1, 1), 10);
        Well baseW = new Well("Well A", new Point(2, 2), new Point(2, 2));

        [TestMethod]
        public void Create_Group() {
            Group expected = baseG;
            Group actual = Factory.CreateGroup(new String[]{ "Group", "Group A", "1", "1", "10"});
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Group_Wrong_Number_Of_Arguments() {
            Factory.CreateGroup(new String[] { "Group", "Group A", "1", "1" });

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Group_Wrong_Argument_Type1() {
            Factory.CreateGroup(new String[] { "Group", "Group A", "Hello", "1", "10" });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Group_Wrong_Argument_Type2() {
            Factory.CreateGroup(new String[] { "Group", "Group A", "1", "Hello", "10" });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Group_Wrong_Argument_Type3() {
            Factory.CreateGroup(new String[] { "Group", "Group A", "1", "1", "Hello" });
        }

        [TestMethod]
        public void Create_Well() {
            Well expected = baseW;
            Well actual = Factory.CreateWell(new String[] { "Well", "Well A", "2", "2", "2","2" });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Well_Wrong_Number_Of_Arguments() {
            Factory.CreateWell(new String[] { "Well", "Well A", "2", "2", "2" });
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Well_Wrong_Argument_Type1() {
            Factory.CreateWell(new String[] { "Well", "Well A", "hello", "2", "2", "2" });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Well_Wrong_Argument_Type2() {
            Factory.CreateWell(new String[] { "Well", "Well A", "2", "hello", "2", "2" });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Well_Wrong_Argument_Type3() {
            Factory.CreateWell(new String[] { "Well", "Well A", "2", "2", "hello", "2" });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Well_Wrong_Argument_Type4() {
            Factory.CreateWell(new String[] { "Well", "Well A", "2", "2", "2", "hello" });
        }
    }
}
