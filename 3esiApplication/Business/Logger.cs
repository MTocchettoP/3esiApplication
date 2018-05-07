using _3esiApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace _3esiApplication.Business {
    /// <summary>
    /// This class holds the information regarding each processed line to be displayed as a summary after the whole file has been loaded.
    /// </summary>
    public class Logger {

        /// <summary>
        /// A list structure that hold all logged information. Should be cleared with a call to <see cref="Clear"/> between file loads.
        /// </summary>
        private List<LogLine> logs;

        /// <summary>
        /// An object holding the reference to this class's single instance to satisfy the singleton pattern
        /// </summary>
        private static Logger instance;

        /// <summary>
        /// Constructor is set as private to enforce singelton pattern
        /// </summary>
        private Logger() {
            logs = new List<LogLine>();
        }

        /// <summary>
        /// Entry point for this class's single instance. Class was designed as a singleton pattern to enforce
        /// persistence of log data during program execution and streamline code
        /// </summary>
        /// <returns>The single instance of this class</returns>
        public static Logger GetInstance() {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        /// <summary>
        /// Add a line to the log. A line is composed of what information was loaded and the resulting message.
        /// If the load was successful the message will convey that, otherwise it should carry the exception's error message.   
        /// </summary>
        /// <param name="line">The line that was operated on</param>
        /// <param name="msg">The message conveying success or the exception's message related to the operation</param>
        public void add(String line, String msg) {
            logs.Add(new LogLine(line, msg));
        }

        /// <summary>
        /// Overridden method. Return this object's log lines in a report format
        /// </summary>
        /// <returns>The log lines in a report format</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder("========================================\n");

            foreach (LogLine ll in logs) {
                sb.AppendLine(ll.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Clears the list of LogLines, use this method between file loads.
        /// </summary>
        public void Clear() {
            logs = new List<LogLine>();
        }   
    }
}
