using System;
using System.Collections.Generic;

namespace lab4
{
    public class SeparatelyStore : Store
    {
        public override void AddFullPoint(List<FileInfo> files)
        {
            var listOfCopy = new List<FileCopy>();
            for (var i = 0; i < files.Count; i++)
            {
                listOfCopy.Add(new FileCopy(files[i].GetName(), files[i].GetSize()));
            }
            
            var list = new List<IPoint>(GetList().ToArray());
            list.Add(new FullPoint(listOfCopy));
            ReturnList(list);        
        }
    }
}