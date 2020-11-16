using System;
using System.Collections.Generic;

namespace lab4
{
    public class RestorePoint
    {
        private string _name;
        private DateTime _date;
        private int _size;

        public RestorePoint(string name, int size)
        {
            _name = name;
            _size = size;
            _date = DateTime.Now;
        }
    }
}