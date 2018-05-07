using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3esiApplication.Model {

    /// <summary>
    /// This class defines a Group which is composed of a name, a Point representing the center of the group, a radius and a list of the Wells that reside inside this group's area
    /// </summary>
    public class Group {

        /// <summary>
        /// The name of the group
        /// </summary>
        private String name;

        /// <summary>
        /// The center of this group, represented by a Point object
        /// </summary>
        private Point center;

        /// <summary>
        /// The radius of this group
        /// </summary>
        private int radius;

        /// <summary>
        /// The list of all the Wells that reside inside this group's area
        /// </summary>
        private List<Well> children;

        /// <summary>
        /// The constructor takes a name, the center of the well and the radius. The children Well's have to be added after instantiation.
        /// </summary>
        /// <param name="name">The name of the group</param>
        /// <param name="center">The center of this group, represented a Point object</param>
        /// <param name="radius">The radius of this group</param>
        public Group(String name, Point center, int radius) {
            this.name = name;
            this.center = center;
            this.radius = radius;
            children = new List<Well>();
        }

        /// <summary>
        /// Set the name of the group
        /// </summary>
        /// <param name="name">The name to be set</param>
        public void SetName(String name) {
            this.name = name;
        }

        /// <summary>
        /// Set the center of the group given a Point object
        /// </summary>
        /// <param name="center">The Point to be set as the center</param>
        public void SetCenter(Point center) {
            this.center = center;
        }

        /// <summary>
        /// Set the center of the group given a X and Y coordinate
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public void SetCenter(int x, int y) {
            SetCenter(new Point(x, y));
        }

        /// <summary>
        /// Set the radius of the group
        /// </summary>
        /// <param name="radius">The new radius</param>
        public void SetRadius(int radius) {
            this.radius = radius;
        }

        /// <summary>
        /// Return the name of the group
        /// </summary>
        /// <returns>A String containing the name</returns>
        public String GetName() {
            return name;
        }

        /// <summary>
        /// Return the center of the group as a Point
        /// </summary>
        /// <returns>A Point representing the center of the group</returns>
        public Point GetCenter() {
            return center;
        }

        /// <summary>
        /// Return the radius of the group
        /// </summary>
        /// <returns>The radius of the group as integer</returns>
        public int GetRadius() {
            return radius;
        }

        /// <summary>
        /// Return a list of all the child Wells
        /// </summary>
        /// <returns>A list containing all the Wells that reside inside this group</returns>
        public List<Well> getChildren() {
            return children;
        }

        /// <summary>
        /// Add a Well to this group. A Well is a child of a group if it resides inside it. Use <see cref="Well.IsInside(Group)"/> to check this property.
        /// </summary>
        /// <param name="w">The Well to be added to the group</param>
        public void AddChild(Well w) {
            children.Add(w);
        }

        /// <summary>
        /// This method determines if two groups intersect each other, based on the following formula where groups are circles:
        /// Let circle "a" be expressed by Xa, Ya and radius Ra and circle "b" be expressed by Xb, Yb and radius Rb.
        /// Let Rs be the sum of Ra and Rb, Rs = Ra + Rb
        /// The square root of the distance between the center of both circles is given by d = sqrt[(Xp-Xc)² + (Yp-Yc)²].
        /// When d &gt; Rs, the circles don't interesect, otherwise they do.<para />
        /// 
        /// Assumption: Groups that share a tangent point, their borders touch, are considered to be intersected this is the result of d = Rs.<para />
        /// Assumption: If a group contains another group or share the same center, this equation will accuse an intersection, thus, this equation
        /// satisfies both requirements regarding a group's location.
        /// </summary>
        /// <param name="other">The group to be compared with</param>
        /// <returns>True if two groups intersect or one contains the other. False otherwise </returns>
        public bool Intersect(Group other) {
            bool intersect = false;

            double sumRadii = this.radius + other.radius;
            int x1 = this.center.x;
            int x2 = other.GetCenter().x;
            int y1 = this.center.y;
            int y2 = other.GetCenter().y;

            double sqrDist = Math.Sqrt(Math.Pow((x1 - x2), 2.0) + Math.Pow((y1 - y2), 2.0));

            if (sqrDist <= sumRadii) {
                intersect = true;
            }

            return intersect;
        }

        /// <summary>
        /// Overridden method. Return the object in report format.
        /// </summary>
        /// <returns>The object in report format.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder(String.Format($"Name:{name} ; Center:{center.x},{center.y} ; Radius:{radius} ; Children:"));
            foreach (Well w in children) {
                sb.Append(String.Format($"{w.GetName()} ; "));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Overridden method. Two groups are considered equal if they have the same name, center and radius.
        /// </summary>
        /// <param name="obj">The object to be compared to</param>
        /// <returns>True if groups are equal, false otherwise</returns>
        public override bool Equals(object obj) {
            bool isEqual = false;

            if (obj == null)
                return isEqual;

            Group other = (Group)obj;
            if (obj is Group)
                if (this.name.Equals(other.GetName()))
                    if (this.center.Equals(other.GetCenter()))
                        if (this.radius == other.GetRadius())
                            isEqual = true;
            return isEqual;
        }
    }
}
