using _3esiApplication.Exception;
using _3esiApplication.Model;
using System;

namespace _3esiApplication.Util {

    /// <summary>
    /// This class implements a simple version of a Factory Pattern, handling the creation of Group and Well objects and hidding the implementation from any user class.
    /// It performs minimal validation before the objects are created, only checking if it has the necessary information to finish the job.
    /// Business rules regarding Group and Wells are found in the business layer, 
    /// <seealso cref="Business.ApplicationServices"/>  
    /// </summary>
    public static class Factory {

        /// <summary>
        /// Create a Group object based on the provided array of arguments. Arguments are checked before creation is attempted. See <see cref="ValidateGroupArgs(string[])"/>. 
        /// </summary>
        /// <param name="args">A string array containing the arguments necessary to create a Group object</param>
        /// <returns>Returns the newly instantiated Group object</returns>
        public static Group CreateGroup(String[] args) {

            ValidateGroupArgs(args);
            String name = args[1];
            Point center = new Point(int.Parse(args[2]), int.Parse(args[3]));
            int radius = int.Parse(args[4]);
            return new Group(name, center, radius);    
        }

        /// <summary>
        /// Create a Well object based on the provided array of arguments. Arguments are checked before creation is attempted. See <see cref="ValidateWellArgs(string[])"/>.
        /// </summary>
        /// <param name="args">A string array containing the arguments necessary to create a Well object</param>
        /// <returns>Returns the newly instantiated Well object</returns>
        public static Well CreateWell(string[] args) {

            ValidateWellArgs(args);
            String name = args[1];
            Point tHole = new Point(int.Parse(args[2]), int.Parse(args[3]));
            Point bHole = new Point(int.Parse(args[4]), int.Parse(args[5]));
            return new Well(name, tHole, bHole);
        }

        /// <summary>
        /// Validate if the list of arguments posses all the necessary information to generate the object.
        /// </summary>
        /// <param name="args">>A string array containing the arguments necessary to create a Well object</param>
        /// <exception cref="InvalidInputException">Thrown when number of arguments don't match the expected count or are of the wrong data type, a distinctive message is send with the exception</exception>
        private static void ValidateWellArgs(String[] args) {

            //Validate argument count
            if (args.Length != 6)//This can be refactored to count the arguments in the constructor instead of using a magic number
                throw new InvalidInputException($"Wrong number of arguments, wanted {6} found {args.Length}");
                
            //Validate argument type
            for (int i = 2; i < args.Length; i++) {
                if (!Int32.TryParse(args[i], out int res)) {
                    throw new InvalidInputException($"Argument {i} is of wrong type, expected a number");
                }
            }
        }

        /// <summary>
        /// Validate if the list of arguments posses all the necessary information to generate the object.
        /// </summary>
        /// <param name="args">>A string array containing the arguments necessary to create a Group object</param>
        /// <exception cref="InvalidInputException">Thrown when number of arguments don't match the expected count or are of the wrong data type, a distinctive message is send with the exception</exception>
        private static void ValidateGroupArgs(String[] args) {
            //Validate argument count
            if (args.Length != 5)//This can be refactored to count the arguments in the constructor instead of using a magic number
                throw new InvalidInputException($"Wrong number of arguments, wanted {5} found {args.Length}");

            //Validate argument type
            for (int i = 2; i < args.Length; i++) {
                if (!Int32.TryParse(args[i], out int res)) {
                    throw new InvalidInputException($"Argument {i} is of wrong type, expected a number");
                }
            }
        }
    }
}
