using System;

namespace lab4
{
    public class FileCopy
    {
        private string _name;
        private int _size;
        private readonly DateTime _dateTime;
        
        public FileCopy(string name, int size)
        {
            _dateTime = DateTime.Now;
            _name = name + " " + _dateTime;
            _size = size;
        }
        
        public string GetName()
        {
            return _name;
        }

        public int GetSize()
        {
            return _size;
        }

    }
}