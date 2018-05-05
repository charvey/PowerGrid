using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PowerGrid.Domain.Observations;

namespace PowerGrid.Observe
{
    public class MapFileObservation : MapObservation
    {
        private readonly string fileName;

        public override Dictionary<string, Dictionary<string, Dictionary<string, int>>> Map
        {
            get
            {
                var inputJson = File.ReadAllText(fileName);
                var map = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, int>>>>(inputJson);
                return map;
            }
        }

        public MapFileObservation(string fileName)
        {
            this.fileName = fileName;
        }
    }
}