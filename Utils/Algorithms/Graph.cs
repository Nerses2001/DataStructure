using System;
using System.Collections.Generic;


namespace DataStructure.Utils.Algorithms
{
    class Graph
    {
        // Dfs  - Depth First Traversal (or Search) for a graph is similar to the Depth First Traversal of a tree.
        // The only catch here is, that, unlike trees, graphs may contain cycles (a node may be visited twice).
        // To avoid processing a node more than once, use a boolean visited array.
        // A graph can have more than one DFS traversal.
        // In algorithm has 3 case (observed, observable,unobserved,)
        // O(V + E)
        public void DFS(Dictionary<int, List<int>> graph, int v, List<bool> used) 
        {
            used[v] = true;
            foreach (int u in graph[v])
            {
                if (!used[u])
                {
                    DFS(graph, u, used);
                }
            }
            Console.WriteLine(v + 1);
        }

        // Bfs The breadth-first search (BFS) algorithm is used to search a tree or graph data structure for a node that meets a set of criteria.
        // It starts at the tree’s root or graph and searches/visits all nodes at the current depth level before moving on to the nodes at the next depth level.
        // Breadth-first search can be used to solve many problems in graph theory.
        // O(V + E)
        public void BFS(Dictionary<int, List<int>> graph)
        {
            bool[] visited = new bool[graph.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            visited[0] = true;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                Console.WriteLine(v + 1); // Print the visited vertex here

                if (graph.ContainsKey(v))
                {
                    foreach (int u in graph[v])
                    {
                        if (!visited[u])
                        {
                            visited[u] = true;
                            queue.Enqueue(u);
                        }
                    }
                }
            }
        }



    }
}
