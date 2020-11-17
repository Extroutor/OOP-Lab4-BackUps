using System;

namespace lab4
{
    public class Point
    {
        private string _name;
        private DateTime _date;
        private int _size;

        public Point(string name, int size)
        {
            _name = name;
            _size = size;
            _date = DateTime.Now;
        }

        public int GetSize()
        {
            return _size;
        }
        
    }
}