using System.Collections.Generic;

namespace HLB_ITIP_LR3
{
    internal class Algorithms
    {
        public static int Dijkstra(Graph graph)
        {
            HashSet<int> visited = new HashSet<int>
            {
                graph.activeVertexNum
            };
            int sum = 0;

            while (visited.Count < graph.adjacencyList.Count)
            {
                int minimalVertex = -1;
                int minimalValue = int.MaxValue;
                foreach (var edge in graph.adjacencyList[graph.activeVertexNum].edges)
                {
                    if (!visited.Contains(edge.destination))
                    {
                        int newValue = graph.adjacencyList[graph.activeVertexNum].value + edge.length;
                        if (newValue < graph.adjacencyList[edge.destination].value)
                        {
                            graph.adjacencyList[edge.destination].value = newValue;
                        }
                        if (edge.length < minimalValue)
                        {
                            minimalValue = edge.length;
                            minimalVertex = edge.destination;
                        }
                    }
                }

                if (minimalVertex != -1)
                {
                    visited.Add(minimalVertex);
                    graph.activeVertexNum = minimalVertex;
                    sum += minimalValue;
                }
                else
                {
                    graph.activeVertexNum = 1;
                    break;
                }
            }
            return sum;
        }

        public static int DijkstraFromTo(Graph graph, int start = 1, int end = 0)
        {
            graph.activeVertexNum = start;
            HashSet<int> visited = new HashSet<int>
            {
                graph.activeVertexNum
            };
            int sum = 0;

            while (visited.Count < graph.adjacencyList.Count)
            {
                if (graph.activeVertexNum == end)
                {
                    graph.activeVertexNum = 1;
                    break;
                }
                int minimalVertex = -1;
                int minimalValue = int.MaxValue;
                foreach (var edge in graph.adjacencyList[graph.activeVertexNum].edges)
                {
                    if (!visited.Contains(edge.destination))
                    {
                        int newValue = graph.adjacencyList[graph.activeVertexNum].value + edge.length;
                        if (newValue < graph.adjacencyList[edge.destination].value)
                        {
                            graph.adjacencyList[edge.destination].value = newValue;
                        }
                        if (edge.length < minimalValue)
                        {
                            minimalValue = edge.length;
                            minimalVertex = edge.destination;
                        }
                    }
                }

                if (minimalVertex != -1)
                {
                    visited.Add(minimalVertex);
                    graph.activeVertexNum = minimalVertex;
                    sum += minimalValue;
                }
                else
                {
                    graph.activeVertexNum = 1;
                    break;
                }
            }
            return sum;
        }

        public static void Floyd(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            // Обработка каждой вершины k как промежуточной вершины
            for (int k = 0; k < n; k++)
            {
                // Обработка каждой пары вершин i и j
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // Если путь через k короче, обновляем расстояние
                        if (matrix[i, k] != int.MaxValue && matrix[k, j] != int.MaxValue && matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                        }
                    }
                }
            }
        }
    }
}
