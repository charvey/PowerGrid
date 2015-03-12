using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerGrid.Core
{
	public class GameState
	{
		public readonly int Players;
		public readonly int Round;
		public readonly IReadOnlyDictionary<City, CityState> CityStates;

		public GameState(int players)
		{
			Players = players;
			Round = 1;
			CityStates = new Dictionary<City, CityState>();
		}
	}
}
