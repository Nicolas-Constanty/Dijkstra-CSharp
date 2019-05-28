using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    /*
     * Implementation of Dijkstra Algorithm with adjacency matrix
     * without and with jagged array
     */

    public static class AdjacencyMatrix
    {
        //Find the nearest vertex who have not been previouly visisted return -1 if can't find
        private static int FindNearest(int[] distances, bool[] visisted)
        {
            int min = int.MaxValue;
            int min_index = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                var dist = distances[i];
                if (!visisted[i] && dist < min)
                {
                    min = dist;
                    min_index = i;
                }
            }
            return min_index;
        }
        #region two dimentional array
        //Return an array with the lowest distance from startingPoint to each vertex
        public static int[] Dijkstra(int[,] graph, int startingPoint)
        {
            /*
             * INIT
             * Init an int array named distances with int.MaxValue
             * Init a boolean array named visited with false
             * Init distances[startingPoint] to 0
             */
            var SIZE = graph.GetLength(0);
            var distances = Enumerable.Repeat(int.MaxValue, SIZE).ToArray();
            var visited = new bool[SIZE];
            distances[startingPoint] = 0;

            /*
             * Get the nearest vertex's index
             * Check if it is possible
             * Go throught all the connections
             *  Check if visisted[j] is false (cond 1)
             *  Check if connection to graph[index, j] exist (cond 2)
             *  Check if distance from startingPoint + distance to nearest connection is < to the currentDistance from startingPoint (cond 3)
             *  Check if distance from startingPoint less than int.MaxValue (cond 4)
             */
            for (int i = 0; i < SIZE - 1; i++)
            {
                var index = FindNearest(distances, visited);
                if (index == -1) continue;
                visited[index] = true;

                for (int j = 0; j < SIZE; j++)
                {
                    if (!visited[j] && graph[index, j] != 0 && graph[index, j] + distances[index] < distances[j] && distances[index] != int.MaxValue)
                    {
                        distances[j] = graph[index, j] + distances[index];
                    }
                }
            }
            return distances;
        }

        public static List<int>[] DijkstraPath(int[,] graph, int startingPoint)
        {
            var SIZE = graph.GetLength(0);
            var distances = Enumerable.Repeat(int.MaxValue, SIZE).ToArray();
            var visited = new bool[SIZE];
            distances[startingPoint] = 0;
            var result = new List<int>[SIZE];
            for (int i = 0; i < SIZE; i++)
                result[i] = new List<int>();

            for (int i = 0; i < SIZE - 1; i++)
            {
                var index = FindNearest(distances, visited);
                if (index == -1)
                {
                    continue;
                }
                visited[index] = true;

                for (int j = 0; j < SIZE; j++)
                {
                    if (!visited[j] && graph[index, j] != 0 && graph[index, j] + distances[index] < distances[j] && distances[index] != int.MaxValue)
                    {
                        result[j] = new List<int>(result[index]);
                        result[j].Add(index);
                        distances[j] = graph[index, j] + distances[index];
                    }
                }
            }
            return result;
        }
        #endregion

        #region jagged array
        public static int[] Dijkstra(int[][] graph, int startingPoint)
        {
            var SIZE = graph.Length;
            var distances = Enumerable.Repeat(int.MaxValue, SIZE).ToArray();
            var visited = new bool[SIZE];
            distances[startingPoint] = 0;

            for (int i = 0; i < SIZE - 1; i++)
            {
                var index = FindNearest(distances, visited);
                if (index == -1) continue;
                visited[index] = true;

                for (int j = 0; j < SIZE; j++)
                {
                    if (!visited[j] && graph[index][j] != 0 && graph[index][j] + distances[index] < distances[j] && distances[index] != int.MaxValue)
                    {
                        distances[j] = graph[index][j] + distances[index];
                    }
                }
            }
            return distances;
        }

        public static List<int>[] DijkstraPath(int[][] graph, int startingPoint)
        {
            var SIZE = graph.Length;
            //Init the distance to the max value
            var distances = Enumerable.Repeat(int.MaxValue, SIZE).ToArray();
            var visited = new bool[SIZE];
            distances[startingPoint] = 0;
            var result = new List<int>[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                result[i] = new List<int>();
            }
            for (int i = 0; i < SIZE - 1; i++)
            {
                var index = FindNearest(distances, visited);
                if (index == -1) continue;
                visited[index] = true;
                for (int j = 0; j < SIZE; j++)
                {
                    var last = result[index].Count;
                    if (!visited[j] && graph[index][j] != 0 && graph[index][j] + distances[index] < distances[j] && distances[index] != int.MaxValue)
                    {
                        result[j] = new List<int>(result[index]);
                        result[j].Add(index);
                        distances[j] = graph[index][j] + distances[index];
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
