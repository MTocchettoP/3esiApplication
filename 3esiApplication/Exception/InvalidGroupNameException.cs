using System;


namespace _3esiApplication.Exception {
    /// <summary>
    /// Thrown when two groups share the same name
    /// </summary>
    public class InvalidGroupNameException : CustomException {

        public InvalidGroupNameException() { }

        public InvalidGroupNameException(String msg) : base(msg) { }
    }
}
