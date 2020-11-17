using System;
using System.Collections.Generic;

namespace lab4
{
    public class SystemBackUp
    {
        private Dictionary<int, BackUp> _backUp = new Dictionary<int, BackUp>();
        private int _idBackup = 0;
        private string _storageType;
        

        public int AddBackUp(string typeOfStorage)
        {
            _idBackup++;
            _storageType = typeOfStorage;
            _backUp[_idBackup] = new BackUp();
            return _idBackup;
        }
        
        public void CreatRestorePoint(int id, string typeOfPoint, List<FileInfo> listOfFiles)
        {
            try
            {
                _backUp[id].RestorePoint(listOfFiles, _storageType, typeOfPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteByCount(int id, int n)
        {
            _backUp[id].DeletePointByCount(n);
            
        }
        
        public void DeleteBySize(int id, int size)
        {
            _backUp[id].DeletePointByCount(size);
            
        }
        
        public void DeleteByDate(int id, DateTime date)
        {
            _backUp[id].DeletePointByDate(date);
            
        }
        
        public void DeleteByHybrid(int id, DateTime date)
        {
            _backUp[id].DeletePointByDate(date);
            
        }

        public void GetList(int id)
        {
            _backUp[id].GetList();
        }
    }
}