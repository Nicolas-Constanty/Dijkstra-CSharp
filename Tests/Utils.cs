using System;
using System.Collections.Generic;
using Dijkstra;
using static Dijkstra.Dictionary;

namespace Tests
{
    using Edge1 = KeyValuePair<string, int>;

    public static class Utils
    {
        public class Matrix<T>
        {
            public virtual T GenerateSimpleGraph()
            {
                return default(T);
            }
            public virtual T GenerateRandomGraph(int size, int maxDistance, float distribution = 0.25f)
            {
                return default(T);
            }
            public virtual void Print(T graph)
            {
            }
        }
        public class Jagged : Matrix<int[][]>
        {
           /*               2
            *           A ------ B
            *           5\   2 / |
            *             \   /  |
            *               C    |4
            *             /   \  |
            *           5/    5\ |
            *           E ------ D
            *               2
            */
            public override int[][] GenerateSimpleGraph()
            {
                var matrix = new int[][]
                {
                    new int[]{ 0, 2, 5, 0, 0 },
                    new int[]{ 2, 0, 2, 4, 0 },
                    new int[]{ 5, 2, 0, 5, 5 },
                    new int[]{ 0, 4, 5, 0, 2 },
                    new int[]{ 0, 0, 5, 2, 0 }
                };
                return matrix;
            }

            public override int[][] GenerateRandomGraph(int size, int maxDistance, float distribution = 0.25f)
            {
                size = size % 2 == 0 ? size : size + 1;
                var matrix = new int[size][];
                var rand = new Random();
                var s = size - 1;
                var index = size / 2;
                var distrib = (int)(size * (1f - distribution));
                if (distrib == 0)
                    distrib = 1;
                for (int i = 0; i < size / 2; i++)
                {
                    matrix[i] = new int[size];
                    matrix[s - i] = new int[size];
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j)
                        {
                            matrix[i][j] = 0;
                            matrix[s - i][s - j] = 0;
                        }
                        else
                        {
                            if (rand.Next(0, distrib) == 0)
                            {
                                var v = rand.Next(0, maxDistance);
                                matrix[i][j] = v;
                                matrix[s - i][s - j] = v;
                            }
                        }
                    }
                }
                return matrix;
            }

            public override void Print(int[][] graph)
            {
                foreach (var rown in graph)
                {
                    foreach (var column in rown)
                    {
                        Console.Write($"{column},");
                    }
                    Console.Write(Environment.NewLine);
                }
            }

            public static void Dijkstra(int startingPoint)
            {
                var m = new Jagged();
                var graph = m.GenerateSimpleGraph();
                var results = AdjacencyMatrix.Dijkstra(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void Dijkstra(int startingPoint, int size, int maxDistance, float distribution = 0.5f)
            {
                var m = new Jagged();
                var graph = m.GenerateRandomGraph(size, maxDistance, distribution);
                var results = AdjacencyMatrix.Dijkstra(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void DijkstraPath(int startingPoint)
            {
                var m = new Jagged();
                var graph = m.GenerateSimpleGraph();
                var results = AdjacencyMatrix.DijkstraPath(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void DijkstraPath(int startingPoint, int size, int maxDistance, float distribution = 0.5f)
            {
                var m = new Jagged();
                var graph = m.GenerateRandomGraph(size, maxDistance, distribution);
                var results = AdjacencyMatrix.DijkstraPath(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }
        }

        public class Dimentional : Matrix<int[,]>
        {
            /*               2
             *           A ------ B
             *           5\   2 / |
             *             \   /  |
             *               C    |4
             *             /   \  |
             *           5/    5\ |
             *           E ------ D
             *               2
             */
            public override int[,] GenerateSimpleGraph()
            {
                var matrix = new int[,]
                {
                { 0, 2, 5, 0, 0 },
                { 2, 0, 2, 4, 0 },
                { 5, 2, 0, 5, 5 },
                { 0, 4, 5, 0, 2 },
                { 0, 0, 5, 2, 0 }
                };
                return matrix;
            }

            public override int[,] GenerateRandomGraph(int size, int maxDistance, float distribution = 0.25f)
            {
                size = size % 2 == 0 ? size : size + 1;
                var matrix = new int[size, size];
                var rand = new Random();
                var s = size - 1;
                var index = size / 2;
                var distrib = (int)(size * (1f - distribution));
                if (distrib == 0)
                    distrib = 1;
                for (int i = 0; i < size / 2; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j)
                        {
                            matrix[i, j] = 0;
                            matrix[s - i, s - j] = 0;
                        }
                        else
                        {
                            if (rand.Next(0, distrib) == 0)
                            {
                                var v = rand.Next(0, maxDistance);
                                matrix[i, j] = v;
                                matrix[s - i, s - j] = v;
                            }
                        }
                    }
                }
                return matrix;
            }

            public override void Print(int[,] graph)
            {
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    for (int j = 0; j < graph.GetLength(0); j++)
                    {
                        Console.Write($"{graph[i, j]},");
                    }
                    Console.Write(Environment.NewLine);
                }
            }

            public static void Dijkstra(int startingPoint)
            {
                var m = new Dimentional();
                var graph = m.GenerateSimpleGraph();
                var results = AdjacencyMatrix.Dijkstra(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void Dijkstra(int startingPoint, int size, int maxDistance, float distribution = 0.5f)
            {
                var m = new Dimentional();
                var graph = m.GenerateRandomGraph(size, maxDistance, distribution);
                var results = AdjacencyMatrix.Dijkstra(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void DijkstraPath(int startingPoint)
            {
                var m = new Dimentional();
                var graph = m.GenerateSimpleGraph();
                var results = AdjacencyMatrix.DijkstraPath(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }

            public static void DijkstraPath(int startingPoint, int size, int maxDistance, float distribution = 0.5f)
            {
                var m = new Dimentional();
                var graph = m.GenerateRandomGraph(size, maxDistance, distribution);
                var results = AdjacencyMatrix.DijkstraPath(graph, startingPoint);
                AdjacencyMatrix.PrintResult(results, startingPoint);
            }
        }

        /*               2
         *           A ------ B
         *           5\   2 / |
         *             \   /  |
         *               C    |4
         *             /   \  |
         *           5/    5\ |
         *           E ------ D
         *               2
         */
        public static Node GenerateGraphList()
        {
            var A = new Node() { name = "A" };
            var B = new Node() { name = "B" };
            var C = new Node() { name = "C" };
            var D = new Node() { name = "D" };
            var E = new Node() { name = "E" };
            var root = A;
            A.connections = new List<Edge>()
        {
            new Edge() { node=B, distance=2 },
            new Edge() { node=C, distance=5 }
        };
            B.connections = new List<Edge>()
        {
            new Edge() { node=A, distance=2 },
            new Edge() { node=C, distance=2 },
            new Edge() { node=D, distance=4 }
        };
            C.connections = new List<Edge>()
        {
            new Edge() { node=A, distance=5 },
            new Edge() { node=B, distance=2 },
            new Edge() { node=E, distance=5 },
            new Edge() { node=D, distance=5 }
        };
            D.connections = new List<Edge>()
        {
            new Edge() { node=B, distance=4 },
            new Edge() { node=C, distance=5 },
            new Edge() { node=E, distance=2 }
        };
            E.connections = new List<Edge>()
        {
            new Edge() { node=C, distance=5 },
            new Edge() { node=D, distance=2 }
        };
            return A;
        }

        /*               2
         *           A ------ B
         *           5\   2 / |
         *             \   /  |
         *               C    |4
         *             /   \  |
         *           5/    5\ |
         *           E ------ D
         *               2
         */
        public static Graph GenerateGraph()
        {
            var graph = new Graph()
        {
            { "A", new List<Edge1>()
                {
                    new Edge1("B", 2),
                    new Edge1("C", 5)
                }
            },
            { "B", new List<Edge1>()
                {
                    new Edge1("A", 2),
                    new Edge1("C", 2),
                    new Edge1("D", 4)
                }
            },
            { "C", new List<Edge1>()
                {
                    new Edge1("A", 5),
                    new Edge1("B", 2),
                    new Edge1("D", 5),
                    new Edge1("E", 5)
                }
            },
            { "D", new List<Edge1>()
                {
                    new Edge1("B", 4),
                    new Edge1("C", 5),
                    new Edge1("E", 2)
                }
            },
            { "E", new List<Edge1>()
                {
                    new Edge1("C", 5),
                    new Edge1("D", 2)
                }
            }
        };
            return graph;
        }

    }
}
