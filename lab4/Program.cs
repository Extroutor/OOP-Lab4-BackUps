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
            backUp1.AddFullPoint(listOfFiles);
            backUp1.GetList();
            backUp1.Delete(new RemoveBySize(600));
            backUp1.GetList();
          //
          //   var list = new List<IRemove>();
          //   list.Add(new RemoveByCount(1));
          // list.Add(new RemoveBySize(600));
          //  
          //   backUp1.HybridDelete(list, listOfFiles, Limits.Min);
          //   
// backUp1.GetList();
        }
    }
}