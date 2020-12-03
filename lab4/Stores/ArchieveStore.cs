using System;
using System.Collections.Generic;
using System.Transactions;

namespace lab4
{
    public class ArchieveStore : Store
    {
        public override void AddFullPoint(List<FileInfo> files)
        {
            var size = 0;
            for (var i = 0; i < files.Count; i++)
            {
                size += files[i].GetSize();
            }

            size = (int) (size * 0.95);
            var list = new List<IPoint>(GetList().ToArray());
            list.Add(new FullPoint("backup " + DateTime.Now + ".rar", size));
            ReturnList(list);
        }
    }
}