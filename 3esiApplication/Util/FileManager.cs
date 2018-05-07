using System;
using System.IO;

namespace _3esiApplication.Util {

    /// <summary>
    /// This class handles all file IO operations. Since the application requirements didn't require any complex functionality from this
    /// class it was left somwhat bare boned. It can be enhanced to support all types of IO and different file formats as well as different delimiters, or none at all
    /// </summary>
    public class FileManager {

        /// <summary>
        /// The full file path
        /// </summary>
        private String filePath;

        /// <summary>
        /// The delimiter used by this file
        /// </summary>
        public readonly char DELIMITER;

        /// <summary>
        /// Default delimiter to be used if a delimiter was not passed during class instantiation
        /// </summary>
        private const char DEFAULT_DELIMITER = ',';

        /// <summary>
        /// Chained constructor that takes only the file path and uses the default delimiter
        /// </summary>
        /// <param name="filePath">The full path of the file, should include path, filename and extension</param>
        public FileManager(String filePath) : this(filePath, DEFAULT_DELIMITER) { }

        /// <summary>
        /// Constructor that takes a full file path and a delimiter
        /// </summary>
        /// <param name="filePath">The full path of the file, should include path, filename and extension</param>
        /// <param name="delim">The delimiter used in this file</param>
        /// <exception cref="FileNotFoundException">Thrown when file path is invalid</exception>
        public FileManager(String filePath, char delim) {
            this.filePath = filePath;
            DELIMITER = delim;
            bool exists = File.Exists(filePath);

            if (!exists)
                throw new FileNotFoundException();
        }

        /// <summary>
        /// Read all lines in the file and return them in an array of strings
        /// </summary>
        /// <returns>A string array containing one line from the file per element</returns>
        public String[] ReadAllLines() {
            String[] lines = File.ReadAllLines(filePath);
            return lines;
        }
    }
}
