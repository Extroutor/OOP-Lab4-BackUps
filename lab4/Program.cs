using System.Collections.Generic;

namespace lab4
{
    public static class Program
    {

        
        public static void Main()
        {
            var file1 = new FileInfo("/home/user/lab3/file1.txt", "file1.txt");
            var file2 = new FileInfo("/home/user/lab3/file2.txt", "file2.txt");

            var listOfFiles = new List<FileInfo> {file1, file2};

            var first = new SystemBackUp("Separately");
            
            first.CreatRestorePoint(listOfFiles);


        }
    }
}