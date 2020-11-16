using System.Collections.Generic;

namespace lab4
{
    public class SystemBackUp
    {
        private Dictionary<int, BackUp> _backUp = new Dictionary<int, BackUp>();
        private int _idBackup = 0;
        private readonly string _storageType;

        public SystemBackUp(string typeOfStorage)
        {
            _storageType = typeOfStorage;
            _backUp[_idBackup] = new BackUp();
            _idBackup++;
        }

        public void CreatRestorePoint(List<FileInfo> listOfFiles)
        {
            _backUp[_idBackup].RestorePoint(listOfFiles, _storageType);
        }

    }

}