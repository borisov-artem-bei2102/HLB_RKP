using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLB_ITIP_LR3
{
    internal class Program
    {
        static Graph InitGraph()
        {
            Graph graph = new Graph();
            graph.AddVertex(1, 0);

            graph.AddEdge(1, 2, 7);
            graph.AddEdge(1, 5, 6);
            graph.AddEdge(2, 4, 2);
            graph.AddEdge(2, 7, 4);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(3, 4, 3);
            graph.AddEdge(3, 7, 3);
            graph.AddEdge(4, 5, 5);
            graph.AddEdge(4, 6, 1);
            graph.AddEdge(6, 7, 4);
            graph.AddEdge(6, 8, 2);
            graph.AddEdge(7, 8, 5);

            return graph;
        }

        static int[,] InitMatrix()
        {
            int[,] matrix =
            {
                { 0, 7, int.MaxValue, int.MaxValue, 6, int.MaxValue, int.MaxValue, int.MaxValue, },
                { 7, 0, int.MaxValue, 2, int.MaxValue, int.MaxValue, 4, 2, },
                { int.MaxValue, int.MaxValue, 0, 3, int.MaxValue, int.MaxValue, 3, int.MaxValue, },
                { int.MaxValue, 2, 3, 0, 5, 1, int.MaxValue, int.MaxValue, },
                { 6, int.MaxValue, int.MaxValue, 5, 0, int.MaxValue, int.MaxValue, int.MaxValue, },
                { int.MaxValue, int.MaxValue, int.MaxValue, 1, int.MaxValue, 0, 4, 2, },
                { int.MaxValue, 4, 3, int.MaxValue, int.MaxValue, 4, 0, 5, },
                { int.MaxValue, 2, int.MaxValue, int.MaxValue, int.MaxValue, 2, 5, 0, },
            };

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int n = 8;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == int.MaxValue)
                    {
                        Console.Write("INF ");
                    }
                    else if (matrix[i, j] == 0)
                    {
                        Console.Write("-   ");
                    }
                    else
                    {
                        if (matrix[i, j].ToString().Length == 1)
                        {
                            Console.Write(matrix[i, j] + "   ");
                        }
                        if (matrix[i, j].ToString().Length == 2)
                        {
                            Console.Write(matrix[i, j] + "  ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Graph dijkstraGraph = InitGraph();
            int sumVisitAll = Algorithms.Dijkstra(dijkstraGraph);
            int sumGoHome = Algorithms.DijkstraFromTo(dijkstraGraph, 3, 1);
            Console.WriteLine("Дейкстра\n");
            dijkstraGraph.Print();
            Console.WriteLine("\n=====\n");
            Console.WriteLine("Флойд\n");
            int[,] floydMatrix = InitMatrix();
            Algorithms.Floyd(floydMatrix);
            PrintMatrix(floydMatrix);
            Console.WriteLine("\n=====\n");
            Console.WriteLine($"Самый короткий путь с посещением всех друзей: {sumVisitAll}");
            Console.WriteLine($"Самый короткий путь от последнего друга до дома: {sumGoHome}");
            Console.WriteLine($"Итоговый путь: {sumVisitAll + sumGoHome}");


            Console.ReadLine();
        }
    }
}
