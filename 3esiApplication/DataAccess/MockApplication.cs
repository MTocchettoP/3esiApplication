using _3esiApplication.Model;
using System.Collections.Generic;


namespace _3esiApplication.DataAccess {
    /// <summary>
    /// This class is simply a mock of the application described in the required document. Since no information was provided regarding the application this class was created in its place.
    /// In the real application this would very likely be replaced with a broker class that interfaced with a database.
    /// </summary>
    public class MockApplication {

        /// <summary>
        /// A list holding all the Wells loaded by the application
        /// </summary>
        private List<Well> wells;

        /// <summary>
        /// A  list holding all the Groups loaded by the application
        /// </summary>
        private List<Group> groups;

        /// <summary>
        /// Count the amount of files that have been loaded
        /// </summary>
        private int fileCount;

        /// <summary>
        /// Attribute to allow access to this object, using singleton pattern
        /// </summary>
        private static MockApplication instance = null;

        /// <summary>
        /// Constructor is set to private to enforce singleton pattern.
        /// </summary>
        private MockApplication() {
            wells = new List<Well>();
            groups = new List<Group>();
        }

        /// <summary>
        /// Entry point for this object. Due to the singleton pattern only one instance of this object exists so data will persist throw the life of the program.
        /// </summary>
        /// <returns>An object containing a reference to this class's only instantiation</returns>
        public static MockApplication GetInstance() {
            if (instance == null)
                instance = new MockApplication();
            return instance;
        }

        /// <summary>
        /// Add a group to the list
        /// </summary>
        /// <param name="toAdd">The group to be added</param>
        public void AddGroup(Group toAdd) {
            groups.Add(toAdd);

        }

        /// <summary>
        /// Add a well to the list
        /// </summary>
        /// <param name="toAdd">The Well to be added</param>
        public void AddWell(Well toAdd) {
            wells.Add(toAdd);
        }

        /// <summary>
        /// Increase the amount of files that have been loaded
        /// </summary>
        public void IncreaseFileCount() {
            fileCount++;
        }

        /// <summary>
        /// Return the list of Wells
        /// </summary>
        /// <returns>A list containing all the Wells loaded into this application</returns>
        public List<Well> GetWells() {
            return wells;
        }

        /// <summary>
        /// Return the list of Groups
        /// </summary>
        /// <returns>A list containing all the Groups loaded into this application.</returns>
        public List<Group> GetGroups() {
            return groups;
        }

        /// <summary>
        /// Return the amount of files that have been loaded
        /// </summary>
        /// <returns>The amount of files that have been loaded</returns>
        public int GetFileCount() {
            return fileCount;
        }
    }
}
