using System;
using System.Collections.Generic;

namespace lab4
{
    public class RemoveByDate : IRemove
    {
        private DateTime _dateLimit;
        
        public RemoveByDate(DateTime date)
        {
            _dateLimit = date;
        }
        public List<IPoint> Delete(List<IPoint> listOfPoints)
        {
            var list = new List<IPoint>();
            var flagIncr = false;
            
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                var size = 0;
                for (var tmp = 0; i < list.Count; i++)
                {
                    size = list[tmp].GetSize();
                }
                
                if (listOfPoints[i].isFull() == false)
                {
                    if (listOfPoints[i].GetDate() <= _dateLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    flagIncr = true;
                } 
                else if (listOfPoints[i].isFull() == true)
                {
                    if (flagIncr == true)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    else if (listOfPoints[i].GetDate() <= _dateLimit)
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