using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public static class Dictionary
    {
        public class Graph : Dictionary<string, List<KeyValuePair<string, int>>> { };

        public class Edge
        {
            public Node node;
            public int distance;
        }
        public class Node
        {
            public string name;
            public List<Edge> connections;
        }

    }
}
