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
            // // Case №1
            // var file1 = new FileInfo("file1", 300);
            // var file2 = new FileInfo("file2", 340);
            //
            // var listOfFiles = new List<FileInfo> {file1, file2};
            //
            // var id1 = systemBackUp.AddBackUp("Separately");
            //
            //
            // systemBackUp.CreatRestorePoint(id1, "Full", listOfFiles);
            //
            // Console.WriteLine("");
            // Console.WriteLine("============================Case №1============================");
            // Console.WriteLine("~Listing of backup №1:");
            // systemBackUp.GetList(id1);
            //
            // Console.WriteLine("wait 5 seconds...");
            // Thread.Sleep(5000);
            //
            // systemBackUp.CreatRestorePoint(id1, "Full", listOfFiles);
            //
            // Console.WriteLine("");
            // Console.WriteLine("~Listing after adding:");
            // systemBackUp.GetList(id1);
            //
            // systemBackUp.DeleteByCount(id1, 1);
            //
            // Console.WriteLine("");
            // Console.WriteLine("~Listing after removing:");
            // systemBackUp.GetList(id1);
            //
            //
            // // Case №2
            //
            // var file3 = new FileInfo("file3", 100);
            // var file4 = new FileInfo("file4", 100);
            //
            // var listOfFiles2 = new List<FileInfo> {file3, file4};
            //
            // var id2 = systemBackUp.AddBackUp("Separately");
            // systemBackUp.CreatRestorePoint(id2, "Full", listOfFiles2);
            //
            // Console.WriteLine("");
            // Console.WriteLine("============================Case №2============================");
            // Console.WriteLine("~Listing of backup №2:");
            // systemBackUp.GetList(id2);
            //
            // systemBackUp.CreatRestorePoint(id2, "Full", listOfFiles2);
            // Console.WriteLine("listing after adding a point:");
            // systemBackUp.GetList(id2);
            //
            //
            // systemBackUp.DeleteBySize(id2, 250);
            //
            // Console.WriteLine("listing after removing:");
            // systemBackUp.GetList(id2);
            //
            // // Case №3
            // Console.WriteLine("============================Case №3============================");
            //
            // var file5 = new FileInfo("file5", 150);
            // var file6 = new FileInfo("file6", 200);
            //
            // var listOfFiles3 = new List<FileInfo> {file5, file6};
            //
            // var id3 = systemBackUp.AddBackUp("Separately");
            // systemBackUp.CreatRestorePoint(id3, "Full", listOfFiles3);
            // Console.WriteLine("");
            // Console.WriteLine("~Listing of backup №3:");
            // systemBackUp.GetList(id3);
            //
            // Console.WriteLine("");
            //
            // var file7 = new FileInfo("file7", 280);
            // listOfFiles3.Add(file7);
            // systemBackUp.CreatRestorePoint(id3, "Increment", listOfFiles3);
            // Console.WriteLine("~Listing after adding:");
            // systemBackUp.GetList(id3);
            //
            // Console.WriteLine("-----------------------------------------------------------");
            //
            
            // var file8 = new FileInfo("file8", 100);
            // var file9 = new FileInfo("file9", 200);
            //
            // var listOfFiles4 = new List<FileInfo> {file8, file9};
            // var id4 = systemBackUp.AddBackUp("Archive");
            //
            // systemBackUp.CreatRestorePoint(id4, "Full", listOfFiles4);
            // Console.WriteLine("");
            // Console.WriteLine("~Listing of backup №4:");
            // systemBackUp.GetList(id4);
            //
            // listOfFiles4.RemoveAt(0);
            // systemBackUp.CreatRestorePoint(id4, "Increment", listOfFiles4);
            // Console.WriteLine("");
            // Console.WriteLine("~Listing after removing the file:");
            // systemBackUp.GetList(id4);
            //
            Console.WriteLine("============================Case №4============================");

            var file10 = new FileInfo("file10", 140);
            var file11 = new FileInfo("file11", 270);
            
            var listOfFiles5 = new List<FileInfo> {file10, file11};
            var dict = new Dictionary<string, object>();
            dict.Add("byCount", 2);
            dict.Add("bySize", 300);
            
            
            var id5 = systemBackUp.AddBackUp("Separately");
            
            systemBackUp.CreatRestorePoint(id5, "Full", listOfFiles5);
            systemBackUp.CreatRestorePoint(id5, "Full", listOfFiles5);
            systemBackUp.CreatRestorePoint(id5, "Full", listOfFiles5);
            systemBackUp.CreatRestorePoint(id5, "Full", listOfFiles5);
            Console.WriteLine("~Listing after adding:");
            systemBackUp.GetList(id5);
            
            systemBackUp.DeleteByHybrid(id5, dict, "min");

            Console.WriteLine("~Listing after removing:");
            systemBackUp.GetList(id5);





        }
    }
}