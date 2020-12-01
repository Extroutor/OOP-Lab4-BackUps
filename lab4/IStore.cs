using System.Collections;
using System.Collections.Generic;

namespace lab4
{
    public interface IStore
    {
        public void AddFullPoint(List<FileInfo> files);
        public void AddIncPoint(List<FileInfo> files);

        public void GetListOfPoints();


    }
}