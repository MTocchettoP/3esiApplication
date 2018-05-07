using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3esiApplication.Model {
    /// <summary>
    /// This class define the possible type of holes and provide a method set the type of hole. 
    /// </summary>
    public class HoleType {
        /// <summary>
        /// The possible values of a HoleType, a numberic representative is also available
        /// </summary>
        private enum HoleTypes { Vertical = 1, Slanted = 2, Horizontal = 3 };

        /// <summary>
        /// The attribuite holding the actual value for the hole type
        /// </summary>
        private HoleTypes holeType;

        /// <summary>
        /// The Constructor requires two points, the top and bottom of the borehole to determined the hole type
        /// </summary>
        /// <param name="top">The top of the borehole</param>
        /// <param name="bottom">the bottom of the borehole</param>
        public HoleType(Point top, Point bottom) {
            SetHoleType(top, bottom);
        }

        /// <summary>
        /// Method that sets <see cref="holeType"/> based on the distance between the top and the bottom of the hole.<para />
        /// Note: The difference between the hole's coordinates is found using <see cref="Math.Abs(double)"/> which will throw an exception if applied to <see cref="Int32.MinValue"/> as the number is 
        /// outside the range of possible positive numbers.<para />
        /// 
        /// Assumption: Type is given by the difference of either the X or Y coordinates<para />
        /// Assumption: Let the difference betwen the holes X or Y coordinate be d. If d &lt;=1 hole is Vertical, if 1 &lt; d &lt; 5 hole is Slanted, otherwise it's Horizontal<para />
        /// </summary>
        /// <param name="top">The Point defining the top of the hole</param>
        /// <param name="bottom">The Point defining the bottom of the hole</param>
        public void SetHoleType(Point top, Point bottom) {

            int difX = Math.Abs(top.x - bottom.x);//Will fail if on Int32.MinValue
            int difY = Math.Abs(top.y - bottom.y);//Will fail if on Int32.MinValue

            if (difX >= 5 || difY >= 5) {
                holeType = HoleTypes.Horizontal;
            } else if ( (difX > 1 && difX < 5) || (difY > 1 && difY < 5)) {
                holeType = HoleTypes.Slanted;
            } else {
                holeType = HoleTypes.Vertical;
            }
        }

        /// <summary>
        /// Overridden method. Return the string representation of the hole type, Vertical, Slanted or Horizontal
        /// </summary>
        /// <returns>The string representation of the hole type, Vertical, Slanted or Horizontal</returns>
        public override string ToString() {
            return holeType.ToString();
        }
    }
}