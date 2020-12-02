using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public interface IStore
    {
        public void AddFullPoint(List<FileInfo> files);
        public void AddIncPoint(List<FileInfo> files);

        public void Delete(IRemove typeOfRemove);

        public void HybridDelete(List<IRemove> list, List<FileInfo> listOfFiles, Limits limits); 
        public void GetListOfPoints();
    }
}