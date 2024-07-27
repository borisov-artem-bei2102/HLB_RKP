using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLB_ITIP_LR3
{
    internal class Graph
    {
        public SortedDictionary<int, Vertex> adjacencyList;
        public int activeVertexNum;

        public Graph() 
        {
            adjacencyList = new SortedDictionary<int, Vertex>();
            activeVertexNum = 1;
        }

        public void AddVertex(int number, int startValue = int.MaxValue)
        {
            if (!adjacencyList.ContainsKey(number))
            {
                adjacencyList[number] = new Vertex(startValue);
                
            }
        }

        public void AddEdge(int source, int destination, int length)
        {
            if (!adjacencyList.ContainsKey(source))
            {  
                AddVertex(source);
            }
            if (!adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }

            adjacencyList[source].edges.Add(new Edge(destination, length));
            adjacencyList[destination].edges.Add(new Edge(source, length));
        }

        public void Print()
        {
            foreach (var vertex in adjacencyList)
            {
                Console.WriteLine($"Вершина {vertex.Key} имеет значение {vertex.Value.value}");
                //foreach (var edge in vertex.Value.edges)
                //{
                //    Console.WriteLine("- To vertex " + edge.destination.ToString() + " with length " + edge.length);
                //}
                //Console.WriteLine("===========");
            }
        }

        public int GetVertexesValuesSum()
        {
            int sum = 0;
            foreach (var vertex in adjacencyList)
            {
                sum += vertex.Value.value;
            }
            return sum;
        }
    }

    internal class Vertex
    {
        public int value;
        public List<Edge> edges;

        public Vertex(int value) {
            this.value = value;
            edges = new List<Edge>();
        }
    }

    internal class Edge
    {
        public int destination;
        public int length;

        public Edge(int destination, int length)
        {
            this.destination = destination;
            this.length = length;
        }
    }
}
