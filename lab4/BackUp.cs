using System;
using System.Collections.Generic;

namespace lab4
{
    public class BackUp
    {
        private List<RestorePoint> _list = new List<RestorePoint>();
        public void RestorePoint(List<FileInfo> listOfFiles, string type)
        {
            switch (type)
            {
                case "Separately":
                {
                    var listOfCopy = new List<FileCopy>();
                    for (var i = 0; i < listOfFiles.Count; i++)
                    {
                        listOfCopy[i] = new FileCopy(listOfFiles[i].GetName(), listOfFiles[i].GetSize());
                    }

                    for (var i = 0; i < listOfCopy.Count; i++)
                    {
                        _list.Add(new RestorePoint(listOfCopy[i].GetName(), listOfCopy[i].GetSize()));
                    }
                    break;
                }
                case "Archive":
                {
                    int size = 0;
                    for (int i = 0; i < listOfFiles.Count; i++)
                    {
                        size += listOfFiles[i].GetSize();
                    }

                    size = (int) (size * 0.95);
                    _list.Add(new RestorePoint("backup_" + DateTime.Now + ".rar", size));
                    break;
                }
                default:
                    throw new Exception("Error: wrong type of Storage");
            }
        }
        
    }
}