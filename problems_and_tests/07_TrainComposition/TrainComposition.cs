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

        public TrainComposition()
        {
            _list = new LinkedList<int>();
        }
        public void AttachWagonFromLeft(int wagonId)
        {
            _list.AddFirst(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            _list.AddLast(wagonId);
        }

        public int DetachWagonFromLeft()
        {

            var result = _list.First.Value;
            _list.RemoveFirst();
            return result;
        }

        public int DetachWagonFromRight()
        {
            var result = _list.Last.Value;
            _list.RemoveLast();
            return result;
        }
    }
}
