using System;
using System.Collections.Generic;
using System.Threading;

namespace lab4
{
    public static class Program
    {
        public static void Main()
        {
            var systemBackUp = new SystemBackUp();
            // Case №1
            var file1 = new FileInfo("file1", 300);
            var file2 = new FileInfo("file2", 340);
            
            var listOfFiles = new List<FileInfo> {file1, file2};
            
            var id1 = systemBackUp.AddBackUp("Separately");
            
            
            systemBackUp.CreatRestorePoint(id1, "Full", listOfFiles);

            Console.WriteLine("");
            Console.WriteLine("Case №1");
            Console.WriteLine("~Listing of backup №1:");
            systemBackUp.GetList(id1);
            
            Console.WriteLine("wait 5 seconds...");
            Thread.Sleep(5000);
            
            systemBackUp.CreatRestorePoint(id1, "Full", listOfFiles);

            Console.WriteLine("");
            Console.WriteLine("~Listing after adding:");
            systemBackUp.GetList(id1);
            
            systemBackUp.DeleteByCount(id1, 1);
            
            Console.WriteLine("");
            Console.WriteLine("~Listing after removing:");
            systemBackUp.GetList(id1);
            
            
            // Case №2
            
            var file3 = new FileInfo("file3", 100);
            var file4 = new FileInfo("file4", 100);
            
            var listOfFiles2 = new List<FileInfo> {file3, file4};
            
            var id2 = systemBackUp.AddBackUp("Separately");
            systemBackUp.CreatRestorePoint(id2, "Full", listOfFiles2);
            
            Console.WriteLine("");
            Console.WriteLine("Case №2");
            Console.WriteLine("~Listing of backup №2:");
            systemBackUp.GetList(id2);
            
            systemBackUp.CreatRestorePoint(id2, "Full", listOfFiles2);
            Console.WriteLine("listing after adding a point:");
            systemBackUp.GetList(id2);
            
            
            systemBackUp.DeleteBySize(id2, 250);
            
            Console.WriteLine("listing after removing:");
            systemBackUp.GetList(id2);
            
            
            //
            // listOfFiles.Remove(file1);
            // systemBackUp.CreatRestorePoint(id1, "Full", listOfFiles);
            // Console.WriteLine("");
            // Console.WriteLine("~New listing of backup №1:");
            // systemBackUp.GetList(id1);
            //
            // systemBackUp.DeleteByCount(id1, 1);
            // systemBackUp.DeleteBySize(id1, 300);
            // var date = DateTime.Now;
            // systemBackUp.DeleteByDate(id1, date);
            // systemBackUp.DeleteByDate(id1, date);
            //
            //
            //
            //
            
            // var file3 = new FileInfo("file3");
            // var file4 = new FileInfo("file4");
            //
            // var listOfFiles2 = new List<FileInfo> {file3, file4};
            //
            // var id2 = systemBackUp.AddBackUp("Archive");
            // systemBackUp.CreatRestorePoint(id2, "Full", listOfFiles2);
            //
            // Console.WriteLine("");
            // Console.WriteLine("~Listing of backup №2:");
            // systemBackUp.GetList(id2);

        }
    }
}