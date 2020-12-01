using System;
using System.Collections.Generic;
using System.Threading;

namespace lab4
{
    public static class Program
    {
        public static void Main()
        {
            var backUp1 = new BackUp(new ArchieveStore());
            
            var file1 = new FileInfo("file1", 300);
            var file2 = new FileInfo("file2", 200);

            var listOfFiles = new List<FileInfo> {file1, file2};
            
            backUp1.AddFullPoint(listOfFiles);
            backUp1.GetList();

            
            backUp1.AddIncrementPoint(listOfFiles);
            
            backUp1.GetList();
        }
    }
}