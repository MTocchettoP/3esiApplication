using _3esiApplication.Exception;
using _3esiApplication.Model;
using _3esiApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3esiApplication.Business {

    /// <summary>
    /// This class enforces the business rules and provide access to the data access layer. In a more complex application these functionalities would be split
    /// to better satisfy a three-layer architecture.
    /// </summary>
    public class ApplicationServices {

        /// <summary>
        /// The default group name to be used for wells that don't belong to any group.
        /// </summary>
        private const String DEFAULT_GROUP_NAME = " Orphan";

        /// <summary>
        /// A reference to the data access object.
        /// </summary>
        private MockApplication app;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationServices() {
            app = MockApplication.GetInstance();
        }

        /// <summary>
        /// This method validate the passed group against the business rules before passing it on to the persistance layer, see <see cref="ValidateGroup(Group)"/>
        /// </summary>
        /// <param name="toAdd">The group to be added</param>
        public void AddGroup(Group toAdd) {
            ValidateGroup(toAdd);
            app.AddGroup(toAdd);
        }

        /// <summary>
        /// This method validate the passed Well against the business rules before passing it on to the persistance layer, see <see cref="ValidateWell(Well)"/>.
        /// This method also assign the Well to the appropriated group, see <see cref="AssignWellToGroup(Well)"/>.
        /// </summary>
        /// <param name="toAdd">The Well to be added</param>
        public void AddWell(Well toAdd) {

            AssignWellToGroup(toAdd);
            ValidateWell(toAdd);

            app.AddWell(toAdd);
        }

        /// <summary>
        /// Increase the counter for files loaded
        /// </summary>
        public void AddToFileCount() {
            app.IncreaseFileCount();
        }

        /// <summary>
        /// Return the list of all Wells loaded from the persistence layer
        /// </summary>
        /// <returns>The list of all Wells loaded from the persistence layer</returns>
        public List<Well> GetWells() {
            return app.GetWells();
        }

        /// <summary>
        /// Return the list of all Groups loaded from the persistence layer
        /// </summary>
        /// <returns>The list of all Groups loaded from the persistence layer</returns>
        public List<Group> GetGroups() {
            return app.GetGroups();
        }

        /// <summary>
        /// Return the amount of files loaded by the application
        /// </summary>
        /// <returns>The amount of files loaded by the application</returns>
        public int GetLoadedFileCounter() {
            return app.GetFileCount();
        }

        /// <summary>
        /// Validate the passed group against the business rules.
        /// Assumption: Group name should be unique
        /// </summary>
        /// <exception cref="GroupIntersectionException">Thrown when this group intersect with another group already added to the list</exception>
        /// <exception cref="InvalidGroupNameException">Thrown when this group has the same name of another group already added to the list</exception>
        /// <param name="toAdd">The group to be validated</param>
        private void ValidateGroup(Group toAdd) {
            foreach (Group g in app.GetGroups()) {
                //Validate if group intersects with the others
                if (toAdd.Intersect(g)) {
                    throw new GroupIntersectionException($"Groups {toAdd.GetName()} intersects with {g.GetName()}");
                }
                //Validate if group name is unique
                if (toAdd.GetName().Equals(g.GetName())) {
                    throw new InvalidGroupNameException($"{toAdd.GetName()} already exist");
                }
            }
        }

        /// <summary>
        /// Validate the passed well against the business rules
        /// </summary>
        /// <exception cref="DuplicatedWellNameException">Thrown when this Well has the same Unique Name as another Well already added to the list</exception>
        /// <exception cref="DuplicateWellLocationException">Thrown when this Well has the same location of another Well already added to the list</exception>
        /// <param name="toAdd">The group to be validated</param>
        private void ValidateWell(Well toAdd) {

            foreach (Well w in app.GetWells()) {

                //Validate if uniqueName is unique
                if (w.GetUniqueName().Equals(toAdd.GetUniqueName())) {
                    throw new DuplicatedWellNameException($"{toAdd.GetUniqueName()} already exists");
                }

                //Validate if location is unique
                if (w.GetTopHole().Equals(toAdd.GetTopHole())) {
                    throw new DuplicateWellLocationException($"{toAdd.GetUniqueName()} in same location as {w.GetUniqueName()}");
                }
            }
        }

        /// <summary>
        /// Assign the passed Well to one of the groups added or to the default group if this Well don't reside inside any of the known groups.
        /// It also adds the well to the group's children list
        /// </summary>
        /// <param name="w">The Well to be analyzed</param>
        private void AssignWellToGroup(Well w) {

            foreach (Group g in app.GetGroups()) {
                if (w.IsInside(g)) {
                    String uniqueName = g.GetName() + w.GetName();
                    w.SetUniqueName(uniqueName);
                    g.AddChild(w);
                    break;
                }
            }
            if (w.GetUniqueName() == null) {
                w.SetUniqueName(DEFAULT_GROUP_NAME + w.GetName());
            }
        }

        /// <summary>
        /// Check all Wells that belong to the Orphan group to see if they don't belong to a newly added group
        /// </summary>
        public void CheckOrphanWells() {

            //for each orphan well
            foreach(Well w in app.GetWells().Where(w => w.GetUniqueName().Contains(DEFAULT_GROUP_NAME))) {
                AssignWellToGroup(w);
            }
        }
    }
}
