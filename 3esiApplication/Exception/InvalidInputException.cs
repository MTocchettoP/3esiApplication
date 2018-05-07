using System;


namespace _3esiApplication.Exception {
    /// <summary>
    /// Thrown when file input is invalid and not usable to create an object
    /// </summary>
    public class InvalidInputException : CustomException {

        public InvalidInputException() { }

        public InvalidInputException(String msg) : base(msg) { }
    }
}
