using System;
using Dijkstra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdjacencyList
{
    [TestClass]
    public class Simple
    {
        [TestMethod]
        public void Basic()
        {
            var size = 9;
            var g = new Graph(size);

            g.AddEdge(0, 1, 4);
            g.AddEdge(0, 7, 8);
            g.AddEdge(1, 2, 8);
            g.AddEdge(1, 7, 11);
            g.AddEdge(2, 3, 7);
            g.AddEdge(2, 8, 2);
            g.AddEdge(2, 5, 4);
            g.AddEdge(3, 4, 9);
            g.AddEdge(3, 5, 14);
            g.AddEdge(4, 5, 10);
            g.AddEdge(5, 6, 2);
            g.AddEdge(6, 7, 1);
            g.AddEdge(6, 8, 6);
            g.AddEdge(7, 8, 7);

            var startingPoint = 0;
            var results = Graph.Dijkstra(g, startingPoint);
            Djikstra.Debug.PrintResult(results, startingPoint);

            Assert.IsTrue(results[0] == 0);
            Assert.IsTrue(results[1] == 4);
            Assert.IsTrue(results[2] == 12);
            Assert.IsTrue(results[3] == 19);
            Assert.IsTrue(results[4] == 21);
            Assert.IsTrue(results[5] == 11);
            Assert.IsTrue(results[6] == 9);
            Assert.IsTrue(results[7] == 8);
            Assert.IsTrue(results[8] == 14);
        }
 /*          2        8
         A ----- B ------ G  
         | \     | \      |3
         |  \    | 2\   1 |
        5|  3\  4|    E - F
         |    \  | 3/
         |     \ | /
         C ----- D ------ H
             3        1
*/
        [TestMethod]
        public void ReadmeExemple()
        {
            var size = 8;
            var g = new Graph(size);

            g.AddEdge(0, 1, 2);
            g.AddEdge(0, 2, 5);
            g.AddEdge(0, 3, 3);

            g.AddEdge(1, 3, 4);
            g.AddEdge(1, 4, 2);
            g.AddEdge(1, 6, 8);

            g.AddEdge(2, 3, 3);

            g.AddEdge(3, 4, 3);
            g.AddEdge(3, 7, 1);

            g.AddEdge(4, 5, 1);

            g.AddEdge(5, 6, 3);
            
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"==> Start from {i}");
                var results = Graph.Dijkstra(g, i);
                Djikstra.Debug.PrintResult(results, i);
            }
            
        }

        [TestMethod]
        public void LittleRandom()
        {
            var g = GenerateRandomGraph(100, 5, 10);
            var startingPoint = 0;
            var results = Graph.Dijkstra(g, startingPoint);
            Djikstra.Debug.PrintResult(results, startingPoint);
        }

        [TestMethod]
        public void BigRandom()
        {
            var g = GenerateRandomGraph(1000000, 5, 100);
            var startingPoint = 0;
            var results = Graph.Dijkstra(g, startingPoint);
            Djikstra.Debug.PrintResult(results, startingPoint);
        }

        private Graph GenerateRandomGraph(int vertexCount, int maxEdgeCount, int maxDistance, float edgeDistribution=1f)
        {
            var g = new Graph(vertexCount);
            var rand = new Random();
            for (int i = 0; i < vertexCount; i++)
            {
                var edgeCount = rand.Next(i == 0 ? 1 : 0, (int)(maxEdgeCount * edgeDistribution));
                for (int j = 0; j < edgeCount; j++)
                {
                    var dest = rand.Next(0, vertexCount);
                    dest = dest == i ? (dest < vertexCount ? dest + 1 : dest - 1) : dest;
                    g.AddEdge(i, dest, rand.Next(1, maxDistance));
                }
            }
            return g;
        }
    }
}
