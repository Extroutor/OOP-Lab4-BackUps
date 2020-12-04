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
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                if (listOfPoints[i].GetDate() <= _dateLimit)
                {
                    list.Add(listOfPoints[i]);
                }
            }
            return list;
        }
    }
}