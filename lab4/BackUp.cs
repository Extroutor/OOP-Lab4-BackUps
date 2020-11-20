using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

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

                            if (_list.Count == 0)
                                throw new Exception("Error: it is the incremental point without a father point");

                            var difSize = _list[_list.Count - 1].GetSize() - size;
                            _list.Add(new RestorePoint(difSize, size, storageType, typeOfPoint));

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
                            _list.Add(new RestorePoint("backup " + DateTime.Now + ".rar", size, storageType,
                                typeOfPoint));
                            break;
                        }

                        case "Increment":
                        {
                            var size = 0;
                            for (var i = 0; i < listOfFiles.Count; i++)
                            {
                                size += listOfFiles[i].GetSize();
                            }

                            if (_list.Count == 0)
                                throw new Exception("Error: it is the incremental point without a father point");

                            size = (int) (size * 0.95);
                            var difSize = _list[_list.Count - 1].GetSize() - size;
                            _list.Add(new RestorePoint(difSize, size, storageType, typeOfPoint));
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

        public List<RestorePoint> DeletePointByCount(int n)
        {
            var list = new List<RestorePoint>();
            var flagIncr = false;

            for (var i = _list.Count - 1; i >= 0; i--)
            {
                if (_list[i]._typeOfPoint == "Increment")
                {
                    if (list.Count + 1 <= n)
                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = true;
                }
                else if (_list[i]._typeOfPoint == "Full")
                {
                    if (flagIncr == true && list.Count + 1 > n)
                    {
                        break;
                    }
                    else if (list.Count + 1 <= n)
                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = false;
                }
                else
                    throw new Exception("Error: wrong type of point");
            }

            return list;
        }


        public List<RestorePoint> DeletePointBySize(int size)
        {
            var list = new List<RestorePoint>();
            var flagIncr = false;

            for (var i = _list.Count - 1; i >= 0; i--)
            {
                if (_list[i]._typeOfPoint == "Increment")
                {
                    if (GetFullSize(list) + _list[i].GetSize() < size)
                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = true;
                }
                else if (_list[i]._typeOfPoint == "Full")
                {
                    if (flagIncr == true)
                    {
                        list.Add(_list[i]);
                    }
                    else if ((GetFullSize(list) + _list[i].GetSize()) < size)
                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = false;
                }
                else
                    throw new Exception("Error: wrong type of point");
            }

            return list;
        }


        public List<RestorePoint> DeletePointByDate(DateTime date)
        {
            var list = new List<RestorePoint>();
            var flagIncr = false;

            for (var i = _list.Count - 1; i >= 0; i--)
            {
                if (_list[i]._typeOfPoint == "Increment")
                {
                    if (_list[i].GetDate() <= date)
                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = true;
                }
                else if (_list[i]._typeOfPoint == "Full")
                {
                    if (flagIncr == true)
                    {
                        list.Add(_list[i]);
                    }
                    else if (_list[i].GetDate() <= date)

                    {
                        list.Add(_list[i]);
                    }

                    flagIncr = false;
                }
                else
                    throw new Exception("Error: wrong type of point");
            }

            return list;
        }


        public void DeletePointByHybrid(Dictionary<string, object> dict, string limit)
        {
            var list = new List<RestorePoint>();
            var nMax = int.MaxValue;
            var nMin = -1;

            foreach (var tmp in dict)
            {
                if (tmp.Key == "byCount")
                {
                    list.AddRange(DeletePointByCount((int) tmp.Value).ToArray());
                    if (_list.Count - list.Count < nMax)
                        nMax = list.Count;
                    else
                        nMin = list.Count;
                }
                else if (tmp.Key == "bySize")
                {
                    list.AddRange(DeletePointBySize((int) tmp.Value).ToArray());
                    if (_list.Count - list.Count < nMax)
                        nMax = list.Count;
                    else
                        nMin = list.Count;
                }
                else if (tmp.Key == "byDate")
                {
                    list.AddRange(DeletePointByDate((DateTime) tmp.Value).ToArray());
                    if (_list.Count - list.Count < nMax)
                        nMax = list.Count;
                    else
                        nMin = list.Count;
                }
                else
                    throw new Exception("Error: wrong type of removing");
            }

            if (limit == "min")
            {
                while (nMax > 0)
                {
                    _list.RemoveAt(0);
                    nMax--;
                }
            }
            else if (limit == "max")
            {
                while (nMin > 0)
                {
                    _list.RemoveAt(0);
                    nMin--;
                }
            }
            else
                throw new Exception("Error: wrong type of limit");
        }

        public void Delete(string type, object n)
        {
            var list = new List<RestorePoint>();

            switch (type)
            {
                case "byCount":
                {
                    list.AddRange(DeletePointByCount((int) n).ToArray());
                    break;
                }
                case "bySize":
                {
                    list.AddRange(DeletePointBySize((int) n).ToArray());
                    break;
                }
                case "byDate":
                {
                    list.AddRange(DeletePointByDate((DateTime) n).ToArray());
                    break;
                }
            }

            _list.Clear();
            _list.AddRange(list.ToArray());
            _list.Reverse();
        }


        private int GetFullSize(List<RestorePoint> list)
        {
            var fullSize = 0;
            for (var i = 0;
                i < list.Count;
                i++)
            {
                fullSize += list[i].GetSize();
            }

            return fullSize;
        }

        public void GetList()
        {
            Console.WriteLine("Size of BackUp - " + GetFullSize(_list));
            for (var i = 0;
                i < _list.Count;
                i++)
            {
                Console.WriteLine("Point №" + (i + 1));
                _list[i].GetLine();
                Console.WriteLine("");
            }
        }
    }
}