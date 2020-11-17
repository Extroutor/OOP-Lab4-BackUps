using System;
using System.Collections.Generic;

namespace lab4
{
    public class BackUp
    {
        private List<RestorePoint> _list = new List<RestorePoint>();

        public void RestorePoint(List<FileInfo> listOfFiles, string storageType, string typeOfPoint)
        {
            switch (storageType)
            {
                case "Separately":
                {
                    switch (typeOfPoint)
                    {
                        case "Full":

                            var listOfCopy = new List<FileCopy>();
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                listOfCopy.Add(new FileCopy(listOfFiles[i].GetName(), listOfFiles[i].GetSize()));
                            }

                            _list.Add(new RestorePoint(listOfCopy));

                            break;

                        case "Increment":

                            var size = 0;
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                size += listOfFiles[i].GetSize();
                            }

                            var difSize = _list[_list.Count - 1].GetSize() - size;
                            _list.Add(new RestorePoint(difSize));

                            break;

                        default:
                            throw new Exception("Error: wrong type of Point");
                    }

                    break;
                }
                case "Archive":
                {
                    switch (typeOfPoint)
                    {
                        case "Full":
                        {
                            var size = 0;
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                size += listOfFiles[i].GetSize();
                            }

                            size = (int) (size * 0.95);
                            _list.Add(new RestorePoint("backup " + DateTime.Now + ".rar", size));
                            break;
                        }

                        case "Increment":
                        {
                            var size = 0;
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                size += listOfFiles[i].GetSize();
                            }

                            size = (int) (size * 0.95);
                            var difSize = _list[_list.Count - 1].GetSize() - size;
                            _list.Add(new RestorePoint(difSize));
                            break;
                        }

                        default:
                            throw new Exception("Error: wrong type of Point");
                    }
                    break;
                }
                default:
                    throw new Exception("Error: wrong type of Storage");
            }
        }
    }
}