using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PowerGrid.Domain;
using PowerGrid.Domain.Observations;

namespace PowerGrid.Observe
{
    public class GameFileObserver : IObserver
    {
        private readonly string fileName;

        public GameFileObserver(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<Observation> MakeObservations()
        {
            var inputJson = File.ReadAllText(fileName);
            var gameFile = JsonConvert.DeserializeObject<GameFile>(inputJson);
            return new Observation[]{
                new MapFileObservation(gameFile.MapFile),
                new RegionsInPlayObservation(gameFile.RegionsInPlay),
                new CurrentPhaseObservation(gameFile.Phase)
            };
        }
    }

    public class GameFile
    {
        public string MapFile;
        public string[] RegionsInPlay;
        public int Phase;
        public Dictionary<string, string[]> Generators;
    }
}