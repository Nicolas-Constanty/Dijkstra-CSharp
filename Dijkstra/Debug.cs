using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public static class Debug
    {
        public static void PrintResult(int[] distance, int startingPoint)
        {
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"Distance between vertex {startingPoint} and vertex {i} : {(distance[i] == int.MaxValue ? "Can't reach this vertex!" : distance[i].ToString())}");
            }
        }

        public static void PrintResult(List<int>[] distances, int startingPoint)
        {
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"Path from {startingPoint} to {i}:");
                for (int j = 0; j < distances[i].Count; j++)
                {
                    Console.Write(j == 0 ? $"({distances[i][j]})" : $"->({distances[i][j]})");
                }
                if (distances[i].Count != 0 || i == startingPoint)
                    Console.Write((i == startingPoint ? $"({i})->({i})" : $"->({i})") + Environment.NewLine);
                else
                    Console.WriteLine("Can't reach this vertex");
            }
        }
    }
}
