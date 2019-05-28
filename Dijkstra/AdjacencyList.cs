using Djikstra;
using System;
using System.Linq;

namespace Dijkstra
{
    public class Edge
    {
        public int dest;
        public int distance;
        public Edge next;
    }

    public struct AdjacencyList
    {
        public Edge root;
    }

    public class Graph
    {
        public AdjacencyList[] data;
        public MinHeapDijkstra minHeap;

        public Graph(int size)
        {
            data = new AdjacencyList[size];
        }

        public int Length()
        {
            return data.Length;
        }

        private Edge CreateNewEdge(int dest, int distance)
        {
            var edge = new Edge() { dest = dest, distance = distance };
            return edge;
        }

        public void AddEdge(int src, int dest, int distance)
        {
            // From src to dest
            var edge = CreateNewEdge(dest, distance);
            edge.next = data[src].root;
            data[src].root = edge;

            //From dest to src
            edge = CreateNewEdge(src, distance);
            edge.next = data[dest].root;
            data[dest].root = edge;
        }

        public static int[] Dijkstra(Graph graph, int root)
        {
            var SIZE = graph.Length();
            var distances = Enumerable.Repeat(int.MaxValue, SIZE).ToArray();
            var minheap = new MinHeapDijkstra(SIZE);

            for (int i = 0; i < SIZE; i++)
            {
                minheap.InsertKey(new MinHeapNode(distances[i], i));    
            }
            minheap.DecreaseKey(root, new MinHeapNode(0, root));
            distances[root] = 0;

            while (!minheap.Empty())
            {
                var node = minheap.ExtractMin();
                var u = node.vertexIndex;

                var adjNode = graph.data[u].root;
                while (adjNode != null)
                {
                    var v = adjNode.dest;

                    if (minheap.IsInMinHeap(v) && distances[u] != int.MaxValue && adjNode.distance + distances[u] < distances[v])
                    {
                        distances[v] = distances[u] + adjNode.distance;

                        minheap.DecreaseKey(v, new MinHeapNode(distances[v], v));
                    }
                    adjNode = adjNode.next;
                }
            }

            return distances;
        }
    }
}
