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
        private Stack<int> _leftPart;
        private Stack<int> _rightPart;

        public TrainComposition()
        {
            _leftPart = new Stack<int>();
            _rightPart = new Stack<int>();
        }
        public void AttachWagonFromLeft(int wagonId)
        {
            _leftPart.Push(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            _rightPart.Push(wagonId);
        }

        public int DetachWagonFromLeft()
        {
            if (_leftPart.Count == 0)
                DivideStack(true);
            return _leftPart.Pop();
        }

        public int DetachWagonFromRight()
        {
            if (_rightPart.Count == 0)
                DivideStack(false);
            return _rightPart.Pop();
        }

        private void DivideStack(bool right)
        {
            var temp = new List<int>();
            if (right)
            {
                var count = _rightPart.Count / 2;
                for (var i = 1; i <= count; i++)
                    temp.Add(_rightPart.Pop());

                while (_rightPart.Count > 0)
                    _leftPart.Push(_rightPart.Pop());

                temp.Reverse();
                _rightPart = new Stack<int>(temp);
            }
            else
            {
                var count = _leftPart.Count / 2;
                for (var i = 1; i <= count; i++)
                    temp.Add(_leftPart.Pop());

                while (_leftPart.Count > 0)
                    _rightPart.Push(_leftPart.Pop());

                temp.Reverse();
                _leftPart = new Stack<int>(temp);
            }
        }
    }
}
