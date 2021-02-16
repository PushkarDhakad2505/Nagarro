using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace solutions
{
    class FileOperations
    {
        static int count = 0;
        public static void Main(string[] arg)
        {
                String[] paths = { "C:\\Users\\HP\\Newrepository\\solutions", "C:\\Users\\HP\\Desktop\\nagarro\\learning materials\\C# Assignments 2019 (1)\\C# Material\\Day 4", "C:\\Users\\HP\\Desktop\\nagarro\\learning materials\\C# Assignments 2019 (1)" };

             

            foreach (string path in paths)
                {
                    if (File.Exists(path))
                    {
                    // This path is a file
                    searchFile(path);
                    }
                    else if (Directory.Exists(path))
                    {
                    // This path is a directory
                    searchDirect(path);
                    }
                    else
                    {
                        Console.WriteLine(path + " is not a valid path please provide correct path");
                    }

                }
            Console.WriteLine("total count of txt file is" + count);


        }

        public static void searchDirect(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.txt");
            foreach (string fileName in fileEntries)
                searchFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                searchDirect(subdirectory);
        }

        // Insert logic for processing found files here.
        public static void searchFile(string path)
        {
            count += 1;
            
            Console.WriteLine("path of files are "+ path);
        }
        

    }
}
