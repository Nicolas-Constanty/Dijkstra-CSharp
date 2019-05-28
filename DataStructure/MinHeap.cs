using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class MinHeap<T> where T : IComparable
    {
        protected T[] _heap;
        protected int _heapSize;
        protected int _capacity;

        public MinHeap(int capacity)
        {
            _heap = new T[capacity];
            _heapSize = 0;
            _capacity = capacity;
        }

        public bool Empty()
        {
            return _heapSize == 0;
        }

        public T[] GetData()
        {
            return _heap;
        }

        public T Parent(int i) => _heap[ParentIndex(i)];

        public T Left(int i) => _heap[LeftIndex(i)];

        public T Right(int i) => _heap[RightIndex(i)];

        public int ParentIndex(int i) => (i - 1) / 2;

        public int LeftIndex(int i) => (i * 2) + 1;

        public int RightIndex(int i) => (i * 2) + 2;

        public T GetMin() => _heap[0];

        protected void Swap(int a, int b)
        {
            var c = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = c;
        }

        public virtual void InsertKey(T value)
        {
            if (_heapSize == _capacity)
            {
                throw new IndexOutOfRangeException();
            }

            var i = _heapSize;
            _heapSize++;
            _heap[i] = value;
            
            while (i != 0 && _heap[ParentIndex(i)].CompareTo(_heap[i]) == - 1)
            {
                Swap(i, ParentIndex(i));
                i = ParentIndex(i);
            }
        }

        public virtual void DecreaseKey(int i, T value)
        {
            if (value.CompareTo(_heap[i]) == -1)
            {
                _heap[i] = value;
                while (i != 0 && _heap[ParentIndex(i)].CompareTo(_heap[i]) == -1)
                {
                    Swap(i, ParentIndex(i));
                    i = ParentIndex(i);
                }
            }
        }

        public virtual T ExtractMin()
        {
            if (_heapSize <= 0)
                return default(T);
            if (_heapSize == 1)
            {
                _heapSize--;
                return _heap[0];
            }

            var root = _heap[0];
            _heapSize--;
            _heap[0] = _heap[_heapSize];
            MinHeapify(0);
            return root;
        }

        public virtual void MinHeapify(int i)
        {
            int l = LeftIndex(i);
            int r = RightIndex(i);
            int smallest = i;

            if (l < _heapSize && _heap[l].CompareTo(_heap[i]) == -1)
                smallest = l;
            if (r < _heapSize && _heap[r].CompareTo(_heap[smallest]) == -1)
                smallest = r;
            if (smallest != i)
            {
                Swap(i, smallest);
                MinHeapify(smallest);
            }
        }
    }
}
