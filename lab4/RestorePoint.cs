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
        private string _typeOfPoint;
        private string _typeOfStorage;

        public RestorePoint(string name, int size)
        {
            _name = name;
            _size = size;
            _date = DateTime.Now;
        }

        public RestorePoint(List<FileCopy> list, string typeOfStorage, string typeOfPoint)
        {
            for (var i = 0; i < list.Count; i++)
            {
                _listOfFile.Add(new Point(list[i].GetName(), list[i].GetSize()));
            }

            _date = DateTime.Now;
            _typeOfPoint = typeOfPoint;
            _typeOfStorage = typeOfStorage;
        }

        public RestorePoint(int difSize, string typeOfStorage, string typeOfPoint)
        {
            _size = difSize;
            _date = DateTime.Now;
            _typeOfPoint = typeOfPoint;
            _typeOfStorage = typeOfStorage;
        }

        public int GetSize()
        {
            if (_typeOfStorage == "Separately" && _typeOfPoint == "Full")
            {
                var size = 0;
                for (var i = 0; i < _listOfFile.Count; i++)
                {
                    size += _listOfFile[i].GetSize();
                }

                return size;
                
            }

            return _size;
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public void GetLine()
        {
            Console.WriteLine("Date of creation - " + _date + ":");
            if (_typeOfStorage == "Separately")
            {
                if (_typeOfPoint == "Full")
                {
                    for (var i = 0; i < _listOfFile.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + "\"" + 
                                          _listOfFile[i].GetName() + "\"" + ", size = " +
                                          _listOfFile[i].GetSize());
                    }
                }
                else
                {
                    Console.WriteLine("Difference between current and previous points - " + _size);
                }
            }
            else
            {
                if (_typeOfPoint == "Full")
                {
                    Console.WriteLine("\"" + _name + ", size = " + _size);
                }
                else
                {
                    Console.WriteLine("Difference between current and previous points - " + _size);
                }
            }
        }
    }
}