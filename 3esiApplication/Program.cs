using _3esiApplication.Business;
using _3esiApplication.Exception;
using _3esiApplication.Model;
using _3esiApplication.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace _3esiApplication {

    /// <summary>
    /// Main class of this application.
    /// Application was developed using a three-layer and MVC architecture as they complement each other. Due to the size and type, console, of the application some of the layers are fused together,
    /// for example this class has elements from the View and the Control layer
    /// </summary>
    public class Program {

        /// <summary>
        /// Application's entry point, controls the flow of the program.
        /// </summary>
        static void Main() {

            int opt = -1;
            do {
                Console.WriteLine("Select an option:\n1-Load a CSV file\n2-Print loaded content\n0-Exit");
                Console.Write("Option: ");
                bool inpt = int.TryParse(Console.ReadLine(), out opt);
                if (!inpt)
                    opt = -1;

                ApplicationServices appServ = new ApplicationServices();
                switch (opt) {
                    case 1:

                        FileManager fm = InitializeFileManager();
                        String[] lines = fm.ReadAllLines();

                        List<int> wIndexs = CreateGroups(lines, fm.DELIMITER);

                        //Assumption: Several files can be loaded in sequence and Oprhan Wells should be reassigned
                        //If more than one file has been loaded in the same program run, check to see if old Wells don't belong to newly added groups                     
                        if(appServ.GetLoadedFileCounter() > 1) {
                            appServ.CheckOrphanWells();
                        }

                        CreateWells(lines, fm.DELIMITER, wIndexs);

                        Console.WriteLine("File loaded see report below");

                        Logger logger = Logger.GetInstance();
                        Console.Write(logger);
                        logger.Clear();
                        break;
                    case 2:

                        Console.WriteLine("========================================");
                        foreach (Group g in appServ.GetGroups()) {
                            Console.WriteLine(g);
                        }

                        Console.WriteLine();
                        foreach (Well w in appServ.GetWells()) {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("========================================");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option\n");
                        break;
                }
            } while (opt != 0);
        }

        /// <summary>
        /// Initialize the file manager, handling any exception related to the path provided by the user being invalid and promting the user for it again
        /// </summary>
        /// <returns>An initialized FileManager instance</returns>
        private static FileManager InitializeFileManager() {
            FileManager fm = null;
            bool success = true;
            do {
                Console.Write("Enter full file path: ");
                String path = Console.ReadLine();

                try {
                    fm = new FileManager(path);
                } catch (FileNotFoundException) {
                    Console.WriteLine("Invalid path, please reenter path and file name");
                    success = false;
                }
            } while (!success);
            return fm;
        }

        /// <summary>
        /// Handles the creation of groups based on the input file. It loops through every line read from the file manager, split the lines marked as Group
        /// using the passed delimiter and feed the list of arguments to the factory to receive a Group object.
        /// After that it sends the object to the service layer to be persisted.
        /// It set the index of the other lines, that are not marked as Group, so assumed to be Wells, asside so the next function, 
        /// control the creation of Wells don't have to loop through the whole file.
        /// Although in theory both loops will be O(n), the loop used in <see cref="CreateWells(string[], char, List{int})"/> will actually be O(m) where m ⊆ n. 
        /// After a group has been loaded the operation is logged in the logger as either a success or a fail with an appropriated message.
        /// </summary>
        /// <param name="lines">The lines read from the input file</param>
        /// <param name="delimiter">The delimiter used in the file</param>
        /// <returns>The list containing the index of all the lines that are not groups, assumed here to be Wells</returns>
        private static List<int> CreateGroups(String[] lines, char delimiter) {

            ApplicationServices appServ = new ApplicationServices();
            Logger logger = Logger.GetInstance();  
            List<int> wIndexs = new List<int>();

            for (int i = 0; i < lines.Length; i++) {
                //Split the line with the given delimiter, isolation the potential object's attributes
                String[] args = lines[i].Split(delimiter);
                if (String.Equals(args[0], "Group", StringComparison.OrdinalIgnoreCase)) {
                    try {
                        Group g = Factory.CreateGroup(args);
                        appServ.AddGroup(g);
                        logger.add(lines[i], "Loaded successfully");
                    } catch (CustomException e) {
                        logger.add(lines[i], e.Message);
                    }
                } else
                    wIndexs.Add(i);
            }
            return wIndexs;
        }

        /// <summary>
        /// Loop through each index in wIndex, using it to access specific elements in the lines array. Although this is theoretically a O(n) operation in practice it should be 
        /// faster than loop through every line in the lines array. After a line is accessed it is split using the passed delimiter and the arguments are fed to the factory
        /// to create a Well object, the object is then passed to the service layer to be persisted and the operation is logged.
        /// </summary>
        /// <param name="lines">The array containing all the lines read from the input file</param>
        /// <param name="delimiter">The delimiter used in the file</param>
        /// <param name="wIndexs">A list containing the indexes from the lines that describe Well objects</param>
        private static void CreateWells(String[] lines, char delimiter, List<int> wIndexs) {
            ApplicationServices appServ = new ApplicationServices();
            Logger logger = Logger.GetInstance();

            foreach (int i in wIndexs) {
                //Split the line with the given delimiter, isolation the potential object's attributes
                String[] args = lines[i].Split(delimiter);
                if (String.Equals(args[0], "Well", StringComparison.OrdinalIgnoreCase)) {
                    try {
                        Well w = Factory.CreateWell(args);
                        appServ.AddWell(w);
                        logger.add(lines[i], "Loaded successfully");
                    } catch (CustomException e) {
                        logger.add(lines[i], e.Message);
                    }
                }
            }
        }
    }
}
