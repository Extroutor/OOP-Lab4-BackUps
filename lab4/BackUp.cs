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
        private IStore _store;
        private List<IPoint> _listOfPoints = new List<IPoint>();

        public BackUp(IStore store)
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
     
        public void GetList()
        {
            _store.GetListOfPoints();
        }
    }
}