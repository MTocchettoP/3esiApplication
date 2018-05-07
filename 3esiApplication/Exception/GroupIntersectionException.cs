using System;

namespace _3esiApplication.Exception {
    /// <summary>
    /// Thrown when two groups intersect each other, see <see cref="Model.Group.Intersect(Model.Group)"/>
    /// </summary>
    public class GroupIntersectionException : CustomException {

        public GroupIntersectionException() { }

        public GroupIntersectionException(String msg) : base(msg) { }
    }
}
