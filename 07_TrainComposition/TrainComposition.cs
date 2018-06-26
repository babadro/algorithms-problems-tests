using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TrainComposition
{
    using System;

    public class TrainComposition
    {
        private readonly LinkedList<int> _list;
        private readonly List<int> _list2;

        public TrainComposition()
        {
            _list = new LinkedList<int>();
            _list2 = new List<int>();
        }
        public void AttachWagonFromLeft(int wagonId)
        {
            _list.AddFirst(wagonId);
            _list2.Insert(0, wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            _list.AddLast(wagonId);
            _list2.Add(wagonId);
        }

        public int DetachWagonFromLeft()
        {

            //var result = _list.First();
            //_list.RemoveFirst();
            //return result;
            var result = _list2[0];
            _list2.RemoveAt(0);
            return result;
        }

        public int DetachWagonFromRight()
        {
            //var result = _list.Last();
            //_list.RemoveLast();
            //return result;
            var result = _list2.Last();
            _list2.Remove(result);
            return result;
        }
    }
}
