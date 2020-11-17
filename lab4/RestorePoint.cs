using System;
using System.Collections.Generic;

namespace lab4
{
    public class RestorePoint
    {
        List<Point> _listOfFile = new List<Point>();
        private string _name;
        private DateTime _date;
        private int _size;
        
        public RestorePoint(string name, int size)
        {
            _name = name;
            _size = size;
            _date = DateTime.Now;
        }

        public RestorePoint(List<FileCopy> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                _listOfFile.Add(new Point(list[i].GetName(), list[i].GetSize()));
            }
        }
        
        public RestorePoint(int difSize)
        {
            _size = difSize;
        }

        public int GetSize()
        {
            var size = 0;
            for (var i = 0; i < _listOfFile.Count; i++)
            {
                size += _listOfFile[i].GetSize();
            }

            return size;
        }
    }
}