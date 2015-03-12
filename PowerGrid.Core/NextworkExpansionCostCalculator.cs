using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerGrid.Core
{
	class NextworkExpansionCostCalculator
	{
		public Dictionary<string,int> Calculate(GameState state, int player)
		{
			var networkCities = new HashSet<City>(state.CityStates
				.Where(kvp => kvp.Value.Generators.Any(c => c.Player == player))
				.Select(kvp => kvp.Key));
			var psuedoCity = new City
			{
				Connections = networkCities
					.SelectMany(c => c.Connections)
					.GroupBy(c => c.Key, c => c.Value)
					.ToDictionary(g => g.Key, g => g.Min())
			};
			var outOfNetwork = state.CityStates
				.Where(kvp => kvp.Value.Generators.All(c => c.Player != player))
				.Select(kvp => kvp.Key)
				.Select(c => new City
				{
					Name = c.Name,
					Connections = c.Connections
						.GroupBy(conn => networkCities.Contains(conn.Key) ? psuedoCity : conn.Key, conn => conn.Value)
						.ToDictionary(conn => conn.Key, conn => conn.Min())
				});

			throw new NotImplementedException();
		}
	}
}
