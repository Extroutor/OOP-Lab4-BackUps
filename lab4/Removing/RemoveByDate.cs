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
            // var flagIncr = false;
            //
            // for (var i = _list.Count - 1; i >= 0; i--)
            // {
            //     if (_list[i]._typeOfPoint == "Increment")
            //     {
            //         if (_list[i].GetDate() <= date)
            //         {
            //             list.Add(_list[i]);
            //         }
            //
            //         flagIncr = true;
            //     }
            //     else if (_list[i]._typeOfPoint == "Full")
            //     {
            //         if (flagIncr == true)
            //         {
            //             list.Add(_list[i]);
            //         }
            //         else if (_list[i].GetDate() <= date)
            //
            //         {
            //             list.Add(_list[i]);
            //         }
            //
            //         flagIncr = false;
            //     }
            //     else
            //         throw new Exception("Error: wrong type of point");
            // }
            //
            return list;
        }
    }
}