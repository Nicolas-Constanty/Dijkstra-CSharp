using DataStructure;
using System;

namespace Djikstra
{
    public class MinHeapNode : IComparable
    {
        public int distance;
        public int vertexIndex;

        public MinHeapNode(int dist, int v)
        {
            distance = dist;
            vertexIndex = v;
        }

        public int CompareTo(object obj)
        {
            if (distance < (obj as MinHeapNode).distance)
                return -1;
            return 0;
        }
    }

    public class MinHeapDijkstra : MinHeap<MinHeapNode>
    {
        public int[] positions;
        public MinHeapDijkstra(int capacity) : base(capacity)
        {
            positions = new int[capacity];
        }

        public override void InsertKey(MinHeapNode value)
        {
            positions[_heapSize] = _heapSize;
            base.InsertKey(value);
        }

        public override MinHeapNode ExtractMin()
        {
            if (_heapSize <= 0)
                return null;

            var root = _heap[0];
            _heapSize--;
            _heap[0] = _heap[_heapSize];
            positions[root.vertexIndex] = _heapSize;
            positions[_heap[0].vertexIndex] = 0;
            MinHeapify(0);
            return root;
        }

        public override void DecreaseKey(int v, MinHeapNode value)
        {
            var i = positions[v];
            if (value.CompareTo(_heap[i]) == -1)
            {
                _heap[i].distance = value.distance;
                while (i != 0 && _heap[i].CompareTo(_heap[ParentIndex(i)]) == -1)
                {
                    positions[_heap[i].vertexIndex] = ParentIndex(i);
                    positions[_heap[ParentIndex(i)].vertexIndex] = i;
                    Swap(i, ParentIndex(i));
                    i = ParentIndex(i);
                }
            }
        }

        public override void MinHeapify(int i)
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
                // Swap positions 
                positions[_heap[smallest].vertexIndex] = i;
                positions[_heap[i].vertexIndex] = smallest;
                Swap(i, smallest);
                MinHeapify(smallest);
            }
        }

        public bool IsInMinHeap(int vertex)
        {
            return positions[vertex] < _heapSize;
        }
    }
}
