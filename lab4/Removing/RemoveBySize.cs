using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace lab4
{
    public class RemoveBySize : IRemove
    {
        private int _sizeLimit;

        public RemoveBySize(int n)
        {
            _sizeLimit = n;
        }
        
        public List<IPoint> Delete(List<IPoint> listOfPoints)
        {
            var list = new List<IPoint>();
            var flagIncr = false;
            
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                var size = 0;
                for (var tmp = 0; tmp < list.Count; tmp++)
                {
                    size = list[tmp].GetSize();
                }
                
                if (listOfPoints[i].IsFull() == false)
                {
                    if (listOfPoints[i].GetSize() + size < _sizeLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    flagIncr = true;
                } 
                else if (listOfPoints[i].IsFull() == true)
                {
                    if (flagIncr == true)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    else if (listOfPoints[i].GetSize() + size < _sizeLimit)
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
