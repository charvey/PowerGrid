using System.Collections.Generic;

namespace PowerGrid.Core
{
	public static class PlayerCountRules
	{
		public static Dictionary<int, int> RegionCounts = new Dictionary<int, int>
		{
			{2, 3},
			{3, 3},
			{4, 4},
			{5, 5},
			{6, 5}
		};
	}
}
