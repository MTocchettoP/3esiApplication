using System;
using _3esiApplication.Business;
using _3esiApplication.Exception;
using _3esiApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3esiApplicationTest {
    [TestClass]
    public class ApplicationServicesTests {

        [TestMethod]
        public void Group_Is_Added() {
            ApplicationServices appServ = new ApplicationServices();
            Group a = new Group("Group A", new Point(1, 1), 1);
            appServ.AddGroup(a);
            int expected = 1;
            int actual = appServ.GetGroups().Count;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(GroupIntersectionException))]
        public void Group_Is_Invalid_Intersect() {
            ApplicationServices appServ = new ApplicationServices();
            Group b = new Group("Group B", new Point(3, 3), 1);
            appServ.AddGroup(b);
            Group c = new Group("Group C", new Point(4, 4), 2);
            appServ.AddGroup(c);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGroupNameException))]
        public void Group_Has_Invalid_Name() {
            ApplicationServices appServ = new ApplicationServices();
            Group d = new Group("Group D", new Point(10, 10), 1);
            appServ.AddGroup(d);
            Group e = new Group("Group D", new Point(100, 100), 1);
            appServ.AddGroup(e);
        }

        [TestMethod]
        public void Well_Is_Added() {
            ApplicationServices appServ = new ApplicationServices();
            Well a = new Well("Well A", new Point(1, 1), new Point(1, 1));
            appServ.AddWell(a);
            int expected = 1;
            int actual = appServ.GetWells().Count;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(DuplicatedWellNameException))]
        public void Well_Has_Invalid_Name() {
            ApplicationServices appServ = new ApplicationServices();
            Well b = new Well("Well B", new Point(2, 2), new Point(1, 1));
            appServ.AddWell(b);
            Well c = new Well("Well B", new Point(5, 5), new Point(1, 1));
            appServ.AddWell(c);

        }

        [TestMethod]
        public void Well_Has_Valid_Name_Across_Groups() {
            ApplicationServices appServ = new ApplicationServices();
            Group x = new Group("Group X", new Point(110, 110), 1);
            Well a = new Well("Well A", new Point(110, 110), new Point(1, 1));
            Group y = new Group("Group Y", new Point(120, 120), 1);
            Well b = new Well("Well A", new Point(120, 120), new Point(1, 1));
            try {
                appServ.AddGroup(x);
                appServ.AddGroup(y);
                appServ.AddWell(a);
                appServ.AddWell(b);
            }catch(Exception e) {
                Assert.Fail("Expected no error, got " + e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWellLocationException))]
        public void Well_Is_Invalid_Location() {
            ApplicationServices appServ = new ApplicationServices();
            Well d = new Well("Well D", new Point(130, 130), new Point(1, 1));
            appServ.AddWell(d);
            Well e = new Well("Well E", new Point(130, 130), new Point(1, 1));
            appServ.AddWell(e);
        }

        [TestMethod]
        public void Well_Is_Orphan() {
            ApplicationServices appServ = new ApplicationServices();
            Well x = new Well("Well X", new Point(1000, 1000), new Point(1, 1));
            appServ.AddWell(x);
            bool expected = true;
            bool actual = x.GetUniqueName().Contains("Orphan");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Well_Belong_To_Group() {
            ApplicationServices appServ = new ApplicationServices();
            Group zed = new Group("Group Z", new Point(1010, 1010), 1);
            appServ.AddGroup(zed);
            Well z = new Well("Well Z", new Point(1010, 1010), new Point(1, 1));
            appServ.AddWell(z);
            bool expected = true;
            bool actual = z.GetUniqueName().Contains("Group Z");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Orphan_Well_Is_Reassigned() {
            ApplicationServices appServ = new ApplicationServices();
            Well g = new Well("Well G", new Point(2000, 2000), new Point(1, 1));
            appServ.AddWell(g);
            Group ge = new Group("Group G", new Point(2000, 2000), 1);
            appServ.AddGroup(ge);
            appServ.CheckOrphanWells();
            
            bool expected = true;
            bool actual = g.GetUniqueName().Contains("Group G");
            Assert.AreEqual(expected, actual);
        }
    }
}
