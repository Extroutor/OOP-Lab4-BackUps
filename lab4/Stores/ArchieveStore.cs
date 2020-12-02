using System;
using System.Collections.Generic;

namespace lab4
{
    public class ArchieveStore : IStore
    {
        private List<IPoint> _listOfPoints = new List<IPoint>();
        private IStore _storeImplementation;

        public void AddFullPoint(List<FileInfo> files)
        {
            var size = 0;
            for (var i = 0; i < files.Count; i++)
            {
                size += files[i].GetSize();
            }

            size = (int) (size * 0.95);
            _listOfPoints.Add(new FullPoint("backup " + DateTime.Now + ".rar", size));
        }

        public void AddIncPoint(List<FileInfo> files)
        {
            var size = 0;
            for (var i = 0; i < files.Count; i++)
            {
                size += files[i].GetSize();
            }

            if (_listOfPoints.Count == 0)
                throw new Exception("Error: it is the incremental point without a father point");

            size = (int) (size * 0.95);
            var diffSize = _listOfPoints[_listOfPoints.Count - 1].GetSize() - size;
            _listOfPoints.Add(new IncrementPoint(size, diffSize));
        }

        public void Delete(IRemove typeOfRemove)
        {
            var newList = new List<IPoint>();
            newList = typeOfRemove.Delete(_listOfPoints);
            _listOfPoints.Clear();
            _listOfPoints.AddRange(newList.ToArray());
        }

        private int GetFullSize(List<IPoint> list)
        {
            var fullSize = 0; 
            for (var i = 0; i < list.Count; i++)
            {
                fullSize += list[i].GetSize();
            }

            return fullSize;
        }
        
        public void GetListOfPoints()
        {
            Console.WriteLine("Size of BackUp - " + GetFullSize(_listOfPoints));
            for (var i = 0; i < _listOfPoints.Count; i++)
            {
                Console.WriteLine("Point №" + (i + 1));
                _listOfPoints[i].GetLine();
                Console.WriteLine("");
            }
            
        }
    }
}