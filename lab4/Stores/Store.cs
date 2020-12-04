using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public abstract class Store
    {
        private List<IPoint> _listOfPoints = new List<IPoint>();

        public abstract void AddFullPoint(List<FileInfo> files);

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

        public void HybridDelete(List<IRemove> listOfTypes, Limits limit)
        {
            var list = new List<IPoint>();
            var nMax = int.MaxValue;
            var nMin = 0;

            foreach (var tmp in listOfTypes)
            {
                list.AddRange(tmp.Delete(_listOfPoints).ToArray());

                if (_listOfPoints.Count - list.Count <= nMax)
                    nMax = _listOfPoints.Count - list.Count;
                if (_listOfPoints.Count - list.Count >= nMin)
                    nMin = _listOfPoints.Count - list.Count;
                list.Clear();
            }

            if (limit == Limits.Min)
            {
                while (nMin > 0)
                {
                    _listOfPoints.RemoveAt(0);
                    nMin--;
                }
            }
            else if (limit == Limits.Max)
            {
                while (nMax > 0)
                {
                    _listOfPoints.RemoveAt(0);
                    nMax--;
                }
            }
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

        public void ReturnList(List<IPoint> list)
        {
            _listOfPoints.Clear();
            _listOfPoints.AddRange(list.ToArray());
        }

        public List<IPoint> GetList()
        {
            return _listOfPoints;
        }
    }
}