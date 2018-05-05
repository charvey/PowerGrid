using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using PowerGrid.Act;
using PowerGrid.Decide;
using PowerGrid.Observe;
using PowerGrid.Orient;

namespace PowerGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer = new GameFileObserver("Game.json");
            var orienter = new TrustingOrienter();
            var decider = new BasicDecider();
            var actor = new ConsoleActor();

            while (true)
            {
                var observerations = observer.MakeObservations();
                var gameState = orienter.OrientGameState(observerations);
                var actions = decider.DecideActions(gameState);
                actor.Perform(actions);
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }

        private static void WorkOnMapFile(string filename)
        {
            while (true)
            {
                var inputJson = File.ReadAllText(filename);
                var map = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, int>>>>(inputJson);
                foreach (var region in map.Keys.ToArray())
                {
                    if (map[region] == null)
                        map[region] = new Dictionary<string, Dictionary<string, int>>();
                    foreach (var city in map[region].Keys.ToArray())
                    {
                        if (map[region][city] == null)
                            map[region][city] = new Dictionary<string, int>();
                    }
                }
                foreach (var region in map)
                {
                    foreach (var city in region.Value)
                    {
                        foreach (var neighbor in city.Value)
                        {
                            var otherDirection = map.SelectMany(r => r.Value).SingleOrDefault(c => c.Key == neighbor.Key).Value;
                            if (otherDirection == null)
                                Console.WriteLine($"Missing {neighbor.Key}");
                            else if (otherDirection.ContainsKey(city.Key))
                            {
                                if (otherDirection[city.Key] != neighbor.Value)
                                    Console.WriteLine($"Mismatch between {city.Key} and {neighbor.Key}");
                            }
                            else
                            {
                                Console.WriteLine($"Adding {neighbor.Key} to {city.Key} ({neighbor.Value})");
                                otherDirection[city.Key] = neighbor.Value;
                            }
                        }
                    }
                }
                var outputJson = JsonConvert.SerializeObject(map, Formatting.Indented);
                File.WriteAllText(filename, outputJson);
                Console.WriteLine("Written");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
