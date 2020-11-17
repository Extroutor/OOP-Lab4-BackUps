using System;

namespace lab4
{
    public class FileInfo
    {
        private string _name;
        private int _size;
        
        public FileInfo(string name, int size)
        {
            _name = name;
            var rand = new Random();
            _size = size;
        }

        public void ChangeSize(int size)
        {
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