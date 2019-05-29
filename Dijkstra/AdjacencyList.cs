using Djikstra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Dijkstra
{
    [Serializable]
    public class Edge
    {
        [XmlAttribute]
        public int src;
        [XmlAttribute]
        public int dest;
        [XmlAttribute]
        public int distance;
        [XmlIgnore]
        public Edge next;
    }
    public struct AdjacencyList
    {
        [XmlIgnore]
        public Edge root;
    }

    [XmlRootAttribute("Graph", IsNullable = false)]
    public class Graph
    {
        [XmlIgnore]
        public AdjacencyList[] data;
        [XmlIgnore]
        public MinHeapDijkstra minHeap;
        [XmlAttribute("Capacity")]
        public int _capacity;
        [XmlArray("Edges")]
        public List<Edge> _edges = new List<Edge>();

        public Graph() { }
        public Graph(int size)
        {
            _capacity = size;
            data = new AdjacencyList[_capacity];
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

        public void AddEdge(int src, int dest, int distance, bool deserialize=false)
        {
            // From src to dest
            var edge = CreateNewEdge(dest, distance);
            edge.src = src;
            edge.next = data[src].root;
            data[src].root = edge;
            if (!deserialize)
                _edges.Add(edge);

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

        public void Save(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Graph));
            TextWriter writer = new StreamWriter(filename);

            serializer.Serialize(writer, this);
            writer.Close();
        }

        public static Graph Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Graph));
            var fs = new FileStream(filename, FileMode.Open);
            var g = (Graph)serializer.Deserialize(fs);
            g.data = new AdjacencyList[g._capacity];
            foreach (var edge in g._edges)
            {
                g.AddEdge(edge.src, edge.dest, edge.distance, true);
            }
            fs.Close();
            return g;
        }

        public static int[,] ConvertToMatrix(Graph g)
        {
            var matrix = new int[g._capacity, g._capacity];
            for (int i = 0; i < g.data.Length; i++)
            {
                var adjList = g.data[i];
                var root = adjList.root;
                while(root != null)
                {
                    matrix[i, root.dest] = root.distance;
                    root = root.next;
                }
            }
            return matrix;
        }

        public static int[][] ConvertToJaggedMatrix(Graph g)
        {
            var matrix = new int[g._capacity][];
            for (int i = 0; i < g.data.Length; i++)
            {
                var adjList = g.data[i];
                var root = adjList.root;
                matrix[i] = new int[g._capacity];
                while (root != null)
                {
                    matrix[i][root.dest] = root.distance;
                    root = root.next;
                }
            }
            return matrix;
        }
    }
}
