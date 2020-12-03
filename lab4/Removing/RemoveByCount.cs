using System;
using System.Collections.Generic;

namespace lab4
{
    public class RemoveByCount : IRemove
    {
        private int _countLimit;

        public RemoveByCount(int n)
        {
            _countLimit = n;
        }
        public List<IPoint> Delete(List<IPoint> listOfPoints)
        {
            var list = new List<IPoint>();
            var flagIncr = false;

            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                if (listOfPoints[i].IsFull() == false)
                {
                    if (list.Count + 1 <= _countLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    flagIncr = true;
                } 
                else if (listOfPoints[i].IsFull() == true)
                {
                    if (flagIncr == true && list.Count + 1 > _countLimit)
                    {
                        break;
                    }
                    else if (list.Count + 1 <= _countLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    
                    flagIncr = false;
                }
                else 
                    throw new Exception("Error: wrong type of point");
            }
            return list;
        }
    }
}