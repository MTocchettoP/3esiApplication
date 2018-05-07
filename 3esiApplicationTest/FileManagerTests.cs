using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3esiApplication.Util;
using System.IO;

namespace _3esiApplicationTest {
    [TestClass]
    public class FileManagerTests {

        String path1 = "C:\\Users\\Marcos\\test.csv"; //Should contain real test data, comma delimited
        String path2 = "C:\\Users\\Marcos\\foobar.csv";//File should not exist
        String path3 = "C:\\Users\\Marcos\\test3.csv";//Should contain two lines: "Hello,World" AND "Again"

        [TestMethod]
        public void File_Exists() {
            Exception expected = null;
            Exception actual = null;
            try {
                FileManager fm = new FileManager(path1);
            } catch (Exception e) {
                actual = e;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void File_Dont_Exist() {
            FileManager fm = new FileManager(path2);
        }

        [TestMethod]
        public void Default_Delim() {
            FileManager fm = new FileManager(path1);
            char expected = ',';
            char actual = fm.DELIMITER;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Custom_Delim() {
            FileManager fm = new FileManager(path1,';');
            char expected = ';';
            char actual = fm.DELIMITER;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_All_Lines() {
            FileManager fm = new FileManager(path3);
            String[] expected = { "Hello,World", "Again" };
            String[] actual = fm.ReadAllLines();

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
            
        }
    }
}
