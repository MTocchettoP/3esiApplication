using System;


namespace _3esiApplication.Exception {
    /// <summary>
    /// Thrown when two wells share the same unique name, see <see cref="Model.Well.uniqueName"/>
    /// </summary>
    public class DuplicatedWellNameException : CustomException {

        public DuplicatedWellNameException() { }

        public DuplicatedWellNameException(String msg) : base(msg) { }
    }
}
