using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path");
            string path = Console.ReadLine();
            // Get full info about all files  in current dir and subdirs
            List<System.IO.FileInfo> files = getRecursiveFiles(path);
            foreach(var file in files)
            {
               Console.WriteLine(file.FullName);
            }

        }
        // Get full info about all files  in current dir and subdirs
        public static List<System.IO.FileInfo> getRecursiveFiles(string path)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            return getRecursiveFiles(directory);
        }

        // Get full info about all files  in current dir and subdirs
        public static List<System.IO.FileInfo> getRecursiveFiles(System.IO.DirectoryInfo directory)
        {
            // Create an empty list
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();
            // Fill the list
            files.AddRange(directory.GetFiles());
            System.IO.DirectoryInfo[] dirs = directory.GetDirectories();

            // Get files from all subdirs
            foreach (System.IO.DirectoryInfo dir in dirs)
            {
                files.AddRange(getRecursiveFiles(dir));
            }
            return files;
        }
    }
}
