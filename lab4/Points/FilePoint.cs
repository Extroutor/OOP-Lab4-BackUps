using System;

namespace lab4
{
    public partial class FilePoint
    {
        private string _name;
        private DateTime _date;
        private int _size;

        public FilePoint(string name, int size)
        {
            _name = name;
            _size = size;
            _date = DateTime.Now;
        }

        public int GetSize()
        {
            return _size;
        }

        public string GetName()
        {
            return _name;
        }
    }
}