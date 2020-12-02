using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public class FullPoint : IPoint
    {
        private List<Point> _files = new List<Point>();
        private DateTime _date;
        private string _name;
        private int _fullSize;
        public FullPoint(List<FileCopy> files)
        {

            for (var i = 0; i < files.Count; i++)
            {
                _files.Add(new Point(files[i].GetName(), files[i].GetSize()));
            }

            _date = DateTime.Now;
            for (var i = 0; i < files.Count; i++)
            {
                _fullSize += _files[i].GetSize();
            }
            
            _date = DateTime.Now;
        }

        public FullPoint(string name, int size)
        {
            _name = name;
            _fullSize = size;
            _date = DateTime.Now;
        }
        
        public int GetSize()
        {
            if (_files.Count != 0)
            {
                var size = 0;
                for (var i = 0; i < _files.Count; i++)
                {
                    size += _files[i].GetSize();
                }

                return size;
            }

            return _fullSize;
        }

        public bool isFull() { return true; }
        

        public void GetLine()
        {
            Console.WriteLine("Date of creation - " + _date + ":");
            if (_files.Count != 0)
            {
                for (var i = 0; i < _files.Count; i++)
                {
                    Console.WriteLine((i + 1) + ") " + "name = \"" +
                                      _files[i].GetName() + "\"" + ", size = " +
                                      _files[i].GetSize());
                }
            }
            else
            {
                Console.WriteLine("Name = \"" + _name + "\"");   
                Console.WriteLine("Size - " + _fullSize);
            }
        }
    }
}