using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.IO;

namespace lab4
{
    public class BackUp
    {
        private Store _store;
        private List<IPoint> _listOfPoints = new List<IPoint>();

        public BackUp(Store store)
        {
            _store = store;
        }

        public void AddFullPoint(List<FileInfo> files)
        {
            _store.AddFullPoint(files);
        }

        public void AddIncrementPoint(List<FileInfo> files)
        {
            _store.AddIncPoint(files);
        }

        public void Delete(IRemove typeOfRemoving)
        {
            _store.Delete(typeOfRemoving);
        }

        public void HybridDelete(List<IRemove> list, List<FileInfo> listOfPoints, Limits limit)
        {
            _store.HybridDelete(list, listOfPoints, limit);
        }
        public void GetList()
        {
            _store.GetListOfPoints();
        }
    }
}