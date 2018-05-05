using System.Collections.Generic;

namespace PowerGrid.Domain.Observations
{
    public abstract class MapObservation : Observation
    {
        public abstract Dictionary<string, Dictionary<string, Dictionary<string, int>>> Map { get; }
    }
}