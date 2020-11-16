﻿using System.Collections.Generic;

namespace lab4
{
    public class SystemBackUp
    {
        private Dictionary<int, BackUp> _backUp = new Dictionary<int, BackUp>();
        private int _idBackup = 0;
        private string _storageType;
        

        public int AddBackUp(string typeOfStorage)
        {
            _storageType = typeOfStorage;
            _backUp[_idBackup] = new BackUp();
            _idBackup++;
            return _idBackup;
        }
        
        public void CreatRestorePoint(int id, List<FileInfo> listOfFiles)
        {
            _backUp[id].RestorePoint(listOfFiles, _storageType);
        }
    }
}