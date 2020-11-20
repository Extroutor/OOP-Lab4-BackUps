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

        public void Delete(int id, string type, object obj)
        {
            _backUp[id].Delete(type, obj);

        }
        
        public void DeleteByHybrid(int id, Dictionary<string, object> dict, string limit)
        {
            _backUp[id].DeletePointByHybrid(dict, limit);
            
        }

        public void GetList(int id)
        {
            _backUp[id].GetList();
        }
    }
}