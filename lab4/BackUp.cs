using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

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

                            _list.Add(new RestorePoint(listOfCopy, storageType, typeOfPoint));

                            break;

                        case "Increment":

                            var size = 0;
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                size += listOfFiles[i].GetSize();
                            }

                            if (_list == null)
                                throw new Exception("Error: it is the incremental point without a father point");

                            var difSize = _list[_list.Count - 1].GetSize() - size;
                            _list.Add(new RestorePoint(difSize, storageType, typeOfPoint));

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
                            _list.Add(new RestorePoint(difSize, storageType, typeOfPoint));
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

        public void DeletePointByCount(int n)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i]._typeOfPoint == "Full" && 
                    (_list[i + 1]._typeOfPoint == "Increment" || _list[i + 1] == null))
                    continue;
                else if (_list.Count > n)
                    _list.RemoveAt(i);
            }
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list.Count > n)
                    _list.RemoveAt(i);
            }
        }

        public void DeletePointBySize(int size)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i]._typeOfPoint == "Full" &&
                    (_list[i + 1]._typeOfPoint == "Increment" || _list[i + 1] == null))
                    continue;
                else if (GetFullSize() > size)
                    _list.RemoveAt(i);
            }

            for (var i = 0; i < _list.Count; i++)
            {
                if (GetFullSize() > size)
                    _list.RemoveAt(i);
            }
        }


        public void DeletePointByDate(DateTime date)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i]._typeOfPoint == "Full" &&
                    (_list[i + 1]._typeOfPoint == "Increment" || _list[i + 1] == null))
                    continue;
                else if (_list[i].GetDate() < date)
                    _list.RemoveAt(i);
            }

            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i].GetDate() < date)
                    _list.RemoveAt(i);
            }
        }

        public void DeletePointByHybrid()
        {
            
        }


        private int GetFullSize()
        {
            var fullSize = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                fullSize += _list[i].GetSize();
            }

            return fullSize;
        }

        public void GetList()
        {
            Console.WriteLine("Size of BackUp - " + GetFullSize());
            for (var i = 0; i < _list.Count; i++)
            {
                _list[i].GetLine();
                Console.WriteLine("");
            }
        }
    }
}