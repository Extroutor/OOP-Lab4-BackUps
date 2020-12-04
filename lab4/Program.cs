using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace lab4
{
    public enum Limits
    {
        Min,
        Max
    }
    public static class Program
    {
        public static void Main()
        {
            var backUp1 = new BackUp(new SeparatelyStore());
            
            var file1 = new FileInfo("file1", 300);
            var file2 = new FileInfo("file2", 200);

            var listOfFiles = new List<FileInfo> {file1, file2};
            
            backUp1.AddFullPoint(listOfFiles);
            backUp1.GetList();
            
            Thread.Sleep(5000);
            var date = DateTime.Now;
            Console.WriteLine(date);
            Console.WriteLine("");
            
            backUp1.AddFullPoint(listOfFiles);
            backUp1.GetList();
            
            
            Thread.Sleep(5000);
            backUp1.AddFullPoint(listOfFiles);
            backUp1.GetList();

            backUp1.Delete(new RemoveByDate(date));
            backUp1.GetList();

        }
    }
}