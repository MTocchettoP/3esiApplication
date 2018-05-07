using System;

namespace _3esiApplication.Exception {
    /// <summary>
    /// Thrown when two wells share the same X,Y location
    /// </summary>
    public class DuplicateWellLocationException : CustomException {

        public DuplicateWellLocationException() { }

        public DuplicateWellLocationException(String msg) : base(msg) { }
    }
}
