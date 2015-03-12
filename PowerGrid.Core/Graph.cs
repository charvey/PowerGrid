using System.Collections.Generic;

namespace PowerGrid.Core
{
	public class Graph<TNode,TEdge>
	{
		public class Edge
		{
			public readonly TEdge Value;
			public readonly Node Destination;
		}

		public class Node
		{
			public readonly TNode Value;
			public readonly IReadOnlyList<Edge> Edges;
		}
	}
}
