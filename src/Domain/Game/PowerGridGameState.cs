using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerGrid.Domain.Game
{
    public class PowerGridGameState : GameState
    {
        public Map Map { get; }
        public Phase Phase { get; }
        public ISet<Region> RegionsInPlay { get; }

        public PowerGridGameState(Map map, Phase phase, ISet<Region> regionsInPlay)
        {
            this.Map = map;
            this.Phase = phase;
            this.RegionsInPlay = regionsInPlay;
        }
    }

    public class Map
    {
        private readonly Dictionary<Region, ISet<City>> map;

        public ISet<City> Cities => new HashSet<City>(map.SelectMany(r => r.Value));
        public ISet<Region> Regions => new HashSet<Region>(map.Keys);

        public Map(Dictionary<Region, ISet<City>> map)
        {
            this.map = map;
        }

        public ISet<City> CitiesInRegion(Region region) => new HashSet<City>(map[region]);
    }

    public class City
    {
        public string Name { get; }

        public City(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode() => Name.GetHashCode();
        public override bool Equals(object obj) => (obj is City otherCity) && otherCity.Name == this.Name;
    }

    public class Region
    {
        public string Name { get; }

        public Region(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode() => Name.GetHashCode();
        public override bool Equals(object obj) => (obj is Region otherRegion) && otherRegion.Name == this.Name;
    }

    public class Phase
    {
        public int Number { get; }

        public Phase(int number)
        {
            if (number < 1 || number > 3)
                throw new ArgumentOutOfRangeException(nameof(number), number, "Phase must be between 1 and 3");

            this.Number = number;
        }

        public override int GetHashCode() => Number.GetHashCode();
        public override bool Equals(object obj) => (obj is Phase otherPhase) && otherPhase.Number == this.Number;
    }
}