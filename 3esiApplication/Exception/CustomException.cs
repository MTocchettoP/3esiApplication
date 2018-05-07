
namespace _3esiApplication.Exception {

    /// <summary>
    /// Abastract extensions of the Exception class to enable try/catch of only the exceptions defined by this application.
    /// </summary>
    public abstract class CustomException : System.Exception {

        protected CustomException() { }

        protected CustomException(string msg) : base(msg) {}
    }
}
