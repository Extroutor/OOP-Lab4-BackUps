using System;
using System.Collections.Generic;

namespace lab4
{
    public interface IPoint
    {
        public int GetSize();
        public void GetLine();
        public DateTime GetDate();
        public bool IsFull();
    }
}