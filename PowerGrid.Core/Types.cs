using System.Collections.Generic;
using System.Linq;

namespace PowerGrid.Core
{
	public class City
	{
		public string Name;
		public string Region;
		public Dictionary<City, int> Connections;
	}

	public class Map
	{
		public ISet<City> Cities;
	}

	public class CityState
	{
		public IEnumerable<GeneratorSpaceState> Generators = new[] {10, 15, 20}.Select(c => new GeneratorSpaceState {Cost = c, Player = 0});
	}

	public class GeneratorSpaceState
	{
		public int Cost;
		public int Player;
	}
}
