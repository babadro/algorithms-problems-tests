using System;

namespace DataStructures.Lists
{
    public class DynamicArray<T>
    {
        private int _capacity;
        private T[] _array;

        public DynamicArray()
        {
            ItemsCount = 0;
            _capacity = 1;
            _array = MakeArray(_capacity);
        }

        public T this[int index]
        {
            get
            {
                if (!(index >= 0 && index < ItemsCount))
                    throw new IndexOutOfRangeException("Index is out of bounds !");
                return _array[index];
            }
        }

        public void Append(T item)
        {
            if (ItemsCount == _capacity)
                Resize(2 * _capacity);

            _array[ItemsCount] = item;
            ItemsCount += 1;
        }

        private void Resize(int newCapacity)
        {
            var newArray = MakeArray(newCapacity);
            for (var i = 0; i < ItemsCount; i++)
                newArray[i] = _array[i];

            _array = newArray;
            _capacity = newCapacity;
        }

        public int ItemsCount { get; private set; }

        private T[] MakeArray(int newCapacity) => new T[newCapacity];
    }
}
