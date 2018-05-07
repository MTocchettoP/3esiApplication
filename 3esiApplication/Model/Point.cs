using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3esiApplication.Model {

    /// <summary>
    /// This structure defines a point with an X and Y coordinate. The struct was chosen instead of a class as this is a very lightweight 
    /// entity that will benefit of the advantages of a struct.
    /// </summary>
    public struct Point {
        /// <summary>
        /// The X coordinate
        /// </summary>
        public readonly int x;

        /// <summary>
        /// The Y coordinate
        /// </summary>
        public readonly int y;

        /// <summary>
        /// The constructor requires X and Y to be provided since they can't be set later
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Overridden method. Two points are considered equal if their X and Y attributes are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>True if objects are the same, false otherwise</returns>
        public override bool Equals(object obj) {
            if (!(obj is Point)) {
                return false;
            }

            var point = (Point)obj;
            return x == point.x &&
                   y == point.y;
        }
    }
}
