using System;
using System.Collections.Generic;
using System.Linq;
namespace GraphApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var graph = new Dictionary<string, List<string>>
			{
				{ "A", new List<string> { "B", "C" } },
				{ "B", new List<string> { "A", "D" } },
				{ "C", new List<string> { "A", "D" } },
				{ "D", new List<string> { "B", "C", "E" } },
				{ "E", new List<string> { "D" } }
			};
			// -------- Task 2-3: BFS and DFS Search --------
			Console.WriteLine("BFS Search for E from A:");
			BFS_Search(graph, "A", "E");
			Console.WriteLine("\nDFS Search for E from A:");
			DFS_Search(graph, "A", "E");
			Console.WriteLine("\nBFS Search for Z from A (non-existent):");
			BFS_Search(graph, "A", "Z");
			Console.WriteLine("\nDFS Search for Z from A (non-existent):");
			DFS_Search(graph, "A", "Z");
			// -------- Task 4: Social Network Friend Suggestions --------
			Console.WriteLine("\nFriend suggestions for A:");
			FriendSuggestions(graph, "A");
		}
		// ---------------- BFS with Path, Visit Order, Depth Levels ----------------
		static void BFS_Search(Dictionary<string, List<string>> graph, string start, string target)
		{
			var visited = new HashSet<string>();
			var queue = new Queue<string>();
			var parent = new Dictionary<string, string>();
			var visitOrder = new List<string>();
			var depth = new Dictionary<string, int>();
			visited.Add(start);
			queue.Enqueue(start);
			parent[start] = null;
			depth[start] = 0;
			while (queue.Count > 0)
			{
				var current = queue.Dequeue();
				visitOrder.Add(current);
				if (current == target)
				{
					// Reconstruct path
					var path = new List<string>();
					var node = current;
					while (node != null)
					{
						path.Add(node);
						node = parent[node];
					}
					path.Reverse();
					Console.WriteLine("Path to target: " + string.Join(" -> ", path));
					Console.WriteLine("BFS Visit Order: " + string.Join(" -> ", visitOrder));
					Console.WriteLine("BFS Depth Levels:");
					foreach (var n in visitOrder)
					Console.WriteLine($"{n}: {depth[n]}");
					return;
				}
				foreach (var neighbor in graph[current])
				{
					if (!visited.Contains(neighbor))
					{
						visited.Add(neighbor);
						queue.Enqueue(neighbor);
						parent[neighbor] = current;
						depth[neighbor] = depth[current] + 1;
					}
				}
			}
			Console.WriteLine($"Target {target} not found.");
			Console.WriteLine("BFS Visit Order: " + string.Join(" -> ", visitOrder));
		}
		// ---------------- DFS with Path and Visit Order ----------------
		static void DFS_Search(Dictionary<string, List<string>> graph, string start, string target)
		{
			var visited = new HashSet<string>();
			var parent = new Dictionary<string, string>();
			var visitOrder = new List<string>();
			bool found = DFS_Helper(graph, start, target, visited, parent, visitOrder);
			if (!found)
			{
				Console.WriteLine($"Target {target} not found.");
				Console.WriteLine("DFS Visit Order: " + string.Join(" -> ", visitOrder));
				return;
			}
			// Reconstruct path
			var path = new List<string>();
			var node = target;
			while (node != null)
			{
				path.Add(node);
				node = parent.ContainsKey(node) ? parent[node] : null;
			}
			path.Reverse();
			Console.WriteLine("Path to target: " + string.Join(" -> ", path));
			Console.WriteLine("DFS Visit Order: " + string.Join(" -> ", visitOrder));
		}
		static bool DFS_Helper(Dictionary<string, List<string>> graph, string current, string target,
		HashSet<string> visited, Dictionary<string, string> parent,
		List<string> visitOrder)
		{
			visited.Add(current);
			visitOrder.Add(current);
			if (current == target)
			return true;
			foreach (var neighbor in graph[current])
			{
				if (!visited.Contains(neighbor))
				{
					parent[neighbor] = current;
					if (DFS_Helper(graph, neighbor, target, visited, parent, visitOrder))
					return true;
				}
			}
			return false;
		}
		// ---------------- Task 4: Friend Suggestions ----------------
		static void FriendSuggestions(Dictionary<string, List<string>> graph, string person)
		{
			if (!graph.ContainsKey(person))
			{
				Console.WriteLine($"Person {person} not found in graph.");
				return;
			}
			var directFriends = new HashSet<string>(graph[person]); // Level 1
			var suggestions = new HashSet<string>(); // Level 2
			var visited = new HashSet<string> { person };
			var queue = new Queue<(string node, int depth)>();
			foreach (var friend in directFriends)
			{
				queue.Enqueue((friend, 1));
				visited.Add(friend);
			}
			while (queue.Count > 0)
			{
				var (current, depth) = queue.Dequeue();
				if (depth == 2 && !directFriends.Contains(current))
				suggestions.Add(current);
				if (graph.ContainsKey(current))
				{
					foreach (var neighbor in graph[current])
					{
						if (!visited.Contains(neighbor))
						{
							visited.Add(neighbor);
							queue.Enqueue((neighbor, depth + 1));
						}
					}
				}
			}
			Console.WriteLine("Direct friends: " + string.Join(", ", directFriends));
			if (suggestions.Count > 0)
			Console.WriteLine("Friends of friends (suggestions): " + string.Join(", ", suggestions));
			else
			Console.WriteLine("Friends of friends (suggestions): None");
		}
	}
}