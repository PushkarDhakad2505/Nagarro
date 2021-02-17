using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace solutions
{
    class FileOperations
    {
        static int count = 0;
        static long maximum = 0;
        static string maximumPath;
        static List<string> fileList = new List<string>();
        static List<string> ExtensionOfFile = new List<string>();
        static List<long> FileLength = new List<long>();
        static IDictionary<string,long> numberNames = new Dictionary< string, long>();
        public static void Main(string[] arg)
        {
                String[] paths = { "C:\\Users\\HP\\Newrepository\\solutions" };

            Console.WriteLine("1.Return the number of text files in the directory(*.txt)");
            Console.WriteLine("2.Return the number of files per extension type.");
            Console.WriteLine("3.Return the top 5 largest files, along with their file size");
            Console.WriteLine("4.Return the file with maximum length.");

            Console.WriteLine("Enter choice ");
            

            int choice =Int32.Parse(Console.ReadLine());
            switch (choice)
            {

                case 1:

                    method(paths,"*.txt");
                    Console.WriteLine("total count of txt file is " + count);

                    break;
                case 2:
                    method(paths, "*");
                    int countExten = 0;
                    ExtensionOfFile.Sort();
                    for (int i=0;i<ExtensionOfFile.Count-2;i++)
                    {
                        if(ExtensionOfFile[i]== ExtensionOfFile[i + 1])
                        {
                            countExten += 1;
                        }
                        else
                        {
                            Console.WriteLine("extension is "+ ExtensionOfFile[i]+" and count is "+countExten+1);
                            countExten = 0;
                        }


                    }
                    //foreach(string ex in ExtensionOfFile)
                    //{
                     //   Console.WriteLine(ex);
                    //}
                    break;
                case 3:
                    method(paths, "*");
                    int countNum = 0;
                    foreach (KeyValuePair<string, long> fileDict in numberNames.OrderByDescending(key => key.Value))
                    {
                        countNum += 1;
                        Console.WriteLine("Key: {0}, Value: {1}", fileDict.Key, (long)fileDict.Value);
                        if (countNum == 5)
                            break;
                    }
                  //  FileLength.Sort();
                    //for(int i = 0; i < 5; i++)
                   // {
                     //   Console.WriteLine(FileLength[(FileLength.Count)-i-1]);
                    //}


                   
                    break;
                case 4:
                    method(paths, "*");
                    break;
                default:
                    break;
            }


             static void method(String[] paths,string fileType)
            {
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
                        searchDirect(path,fileType);
                    }
                    else
                    {
                        Console.WriteLine(path + " is not a valid path please provide correct path");
                    }

                }
                
                Console.WriteLine("file with maximum length is" + maximumPath + " and length is " + maximum);

            }
        }

        public static void searchDirect(string targetDirectory,string fileType)
        {
            // Process the list of files found in the directory.
            
                string[] fileEntries = Directory.GetFiles(targetDirectory, fileType);
           
            
            foreach (string fileName in fileEntries)
            {
                searchFile(fileName);

            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                searchDirect(subdirectory,fileType);
        }

        // Insert logic for processing found files here.
        public static void searchFile(string path)
        {
            fileList.Add(path);
            FileInfo fi = new FileInfo(path);
            long lengthOfFile=fi.Length;
            FileLength.Add(lengthOfFile);
            string name=fi.Name;

            numberNames.Add(path, lengthOfFile);

            

            string exten = fi.Extension;
            long len=fi.Length;
            if (len > maximum)
            {
                maximum = len;
                maximumPath = path;
            }
            count += 1;

            ExtensionOfFile.Add(exten);
            
            //Console.WriteLine("path of files are "+ path);
        }
        
    }
}
