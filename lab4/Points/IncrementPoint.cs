using System;
using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public class IncrementPoint : IPoint
    {
        private int _size;
        private int _diffSize;
        private DateTime _date;

        public IncrementPoint(int size, int diffSize)
        {
            _size = size;
            _diffSize = diffSize;
            _date = DateTime.Now;
        }
        
        public int GetSize()
        {
            return _size;
        }
        
        public DateTime GetDate()
        {
            return _date;
        }
        
        public bool IsFull() { return false; }

        public void GetLine()
        {
            Console.WriteLine("Date of creation - " + _date + ":");
            Console.WriteLine("Size - " + _size);
            Console.WriteLine("Difference between current and previous points — " + _diffSize);
        }
    }
}