using System;

namespace _3esiApplication.Model {

    /// <summary>
    /// This structure defines an entry line in the log, which is this application's reporting entity. The struct was chosen instead of a class as this is a very lightweight 
    /// entity that will benefit of the advantages of a struct.
    /// </summary>
    public struct LogLine {

        /// <summary>
        /// The line from the loaded file that was operated on
        /// </summary>
        public readonly String line;

        /// <summary>
        /// The result of the operation. Should display the exception's message if something goes wrong or a success message otherwise
        /// </summary>
        public readonly String msg;

        /// <summary>
        /// The constructor need both attributes as they can't be set later.
        /// </summary>
        /// <param name="line">The line from the loaded file that was operated on</param>
        /// <param name="msg">The message describing the result of the operation</param>
        public LogLine(String line, String msg) {
            this.line = line;
            this.msg = msg;
        }

        /// <summary>
        /// Overridden method, return the object in a report format.
        /// </summary>
        /// <returns>The object in a report format.</returns>
        public override string ToString() {
            return String.Format("{0,-30} | {1,-100}", line, msg);
        }
    }
}
