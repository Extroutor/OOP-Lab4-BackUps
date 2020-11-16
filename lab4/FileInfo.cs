using System;

namespace lab4
{
    public class FileInfo
    {
           
        private string _path;
        private string _name;
        private int _size;
        
        public FileInfo(string path, string name)
        {
            
            _path = path;
            _name = name;
            var rand = new Random();
            _size = rand.Next(0, 500);

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