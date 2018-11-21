using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures.Lists
{
    public class ArrayList<T>
    {
        private int _capacity;
        private T[] _A;

        public ArrayList(T obj)
        {
            Length = 0;
            _capacity = 1;
            _A = MakeArray(_capacity);
        }

        public T this[int index]
        {
            get
            {
                if (!(index >= 0 && index < Length))
                    throw new IndexOutOfRangeException("Index is out of bounds !");
                return _A[index];
            }
        }

        public void Append(T ele)
        {
            if (Length == _capacity)
                Resize(2 * _capacity);

            _A[Length] = ele;
            Length += 1;
        }

        private void Resize(int newCapacity)
        {
            var b = MakeArray(newCapacity);
            for (var i = 0; i < Length; i++)
                b[i] = _A[i];

            _A = b;
            _capacity = newCapacity;
        }

        public int Length { get; private set; }

        private T[] MakeArray(int newCapacity) => new T[newCapacity];
    }
}
