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
            
            _name = name + "_" + _dateTime;
            _size = size;
            _dateTime = DateTime.Now;

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