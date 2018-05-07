using System;


namespace _3esiApplication.Model {

    /// <summary>
    /// Define a Well object containing a name, a Point indicating the top hole, a Point indicating the bottom hole, a unique name, see <see cref="uniqueName"/> and the type of the hole defined by the difference between the top and bottom hole.
    /// </summary>
    public class Well {

        /// <summary>
        /// The name of the well
        /// </summary>
        private String name;
        /// <summary>
        /// The location of the top hole
        /// </summary>
        private Point tHole;
        /// <summary>
        /// The location of the bottom hole
        /// </summary>
        private Point bHole;
        /// <summary>
        /// The unique name of the hole, given by the concatenation of the name of the group it belongs to and the well's name.<para />
        /// Assumption: Wells that don't belong to any group put in the Orphan group.
        /// </summary>
        private String uniqueName;
        /// <summary>
        /// The type of the hole. See <see cref="HoleType"/> for more information.
        /// </summary>
        private HoleType type;

        /// <summary>
        /// Constructor that takes a name, top hole and bottom hole location to create the object. After the holes are set the HoleType is instantiated and the hole type is set.
        /// </summary>
        /// <param name="name">The name of the well</param>
        /// <param name="tHole">The Point defining the location of the top of the borehole </param>
        /// <param name="bHole">The Point defining the location of the bottom of the borehole</param>
        public Well(String name, Point tHole, Point bHole) {
            this.name = name;
            this.tHole = tHole;
            this.bHole = bHole;
            type = new HoleType(tHole, bHole);
        }

        /// <summary>
        /// Set the name of the Well
        /// </summary>
        /// <param name="name">The new name to be set</param>
        public void SetName(String name) {
            this.name = name;
        }

        /// <summary>
        /// Set the location of the top hole based on a provided Point. This method will trigger a change in the Well type if necessary.
        /// </summary>
        /// <param name="tHole">The new Point to be set as the top of the borehole</param>
        public void SetTopHole(Point tHole) {
            this.tHole = tHole;
            type.SetHoleType(tHole, bHole);
        }

        /// <summary>
        /// Set the location of the top hole based on a provided x,y coordinate. This method will trigger a change in the Well type if necessary.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public void SetTopHole(int x, int y) {
            SetTopHole(new Point(x, y));
            type.SetHoleType(tHole, bHole);
        }

        /// <summary>
        /// Set the location of the bottom hole based on a provided Point. This method will trigger a change in the Well type if necessary.
        /// </summary>
        /// <param name="tHole">The new Point to be set as the top of the borehole</param>
        public void SetBottomHole(Point bHole) {
            this.bHole = bHole;
            type.SetHoleType(tHole, bHole);
        }

        /// <summary>
        /// Set the location of the bottom hole based on a provided x,y coordinate. This method will trigger a change in the Well type if necessary.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public void SetBottomHole(int x, int y) {
            SetBottomHole(new Point(x, y));
            type.SetHoleType(tHole, bHole);
        }

        /// <summary>
        /// Set the unique name of this well. See <see cref="Well.uniqueName"/>
        /// </summary>
        /// <param name="uniqueName">The unique name to be set</param>
        public void SetUniqueName(String uniqueName) {
            this.uniqueName = uniqueName;
        }

        /// <summary>
        /// Return the name
        /// </summary>
        /// <returns>A String containing the Well's name</returns>
        public String GetName() {
            return name;
        }

        /// <summary>
        /// Return the location of the top hole
        /// </summary>
        /// <returns>A Point representing the top hole</returns>
        public Point GetTopHole() {
            return tHole;
        }

        /// <summary>
        /// Return the location of the bottom hole
        /// </summary>
        /// <returns>A Point representing the bottom hole</returns>
        public Point GetBottomHole() {
            return bHole;
        }

        /// <summary>
        /// Return the unique name
        /// </summary>
        /// <returns>A String containing the Well's unique name</returns>
        public String GetUniqueName() {
            return uniqueName;
        }

        /// <summary>
        /// Check if a Well is part of a Group. This is given by the following formula where the Well is a point and the Group a circle:
        /// Let a point Xp,Yp and a circle Xc,Yc with radius r. The squared distance between the point and the circle is given by d²=(Xp-Xc)² + (Yp-Yc)².
        /// When d² &lt;= r², point is inside or in the circle, else it's outside.<para />
        /// Assumption: A Well in a Group's border is considered inside the Group
        /// </summary>
        /// <param name="g">The group to check if this Well belongs to</param>
        /// <returns>True if the well is inside the group or in it's border, false otherwise</returns>
        public bool IsInside(Group g) {
            bool isInside = true;

            double srqRadius = Math.Pow(g.GetRadius(), 2.0);
            int x1 = this.tHole.x;
            int x2 = g.GetCenter().x;
            int y1 = this.tHole.y;
            int y2 = g.GetCenter().y;

            double sqrDist = Math.Pow((x1 - x2), 2.0) + Math.Pow((y1 - y2), 2.0);

            if (sqrDist > srqRadius) {
                isInside = false;
            }
            return isInside;
        }

        /// <summary>
        /// Overridden method, return the object in a report format
        /// </summary>
        /// <returns>The object in a report format</returns>
        public override string ToString() {
            return String.Format($"Name:{name} ; Top:{tHole.x},{tHole.y} ; Bottom:{bHole.x},{bHole.y} ; Type: {type} ; Unique Name:{uniqueName}");
        }

        /// <summary>
        /// Overridden method, two Well's are considered equal if they have the same name, top and bottom hole.
        /// </summary>
        /// <param name="obj">The object to be compared</param>
        /// <returns>True if the objects are the same based on the parameters described above, false otherwise</returns>
        public override bool Equals(object obj) {
            bool isEqual = false;

            if (obj == null)
                return isEqual;

            Well other = (Well)obj;
            if (obj is Well)
                if (this.name.Equals(other.GetName()))
                    if (this.tHole.Equals(other.GetTopHole()))
                        if (this.bHole.Equals(other.GetBottomHole()))
                            isEqual = true;
            return isEqual;
        }
    }
}
