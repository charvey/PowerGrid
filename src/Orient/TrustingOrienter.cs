using System;
using System.Collections.Generic;
using System.Linq;
using PowerGrid.Domain;
using PowerGrid.Domain.Game;
using PowerGrid.Domain.Observations;

namespace PowerGrid.Orient
{
    public class TrustingOrienter : IOrienter
    {
        public GameState OrientGameState(IEnumerable<Observation> observations)
        {
            Map map = null;
            Phase phase = null;
            ISet<Region> regionsInPlay = null;
            foreach (var observation in observations)
            {
                if (observation is MapObservation mapObservation)
                {
                    map = OrientMap(mapObservation);
                }
                else if (observation is CurrentPhaseObservation currentPhaseObservation)
                {
                    phase = OrientPhase(currentPhaseObservation);
                }
                else if (observation is RegionsInPlayObservation regionsInPlayObservation)
                {
                    regionsInPlay = OrientRegionsInPlay(regionsInPlayObservation);
                }
            }
            return new PowerGridGameState(map, phase, regionsInPlay);
        }

        private static Map OrientMap(MapObservation mapObservation)
        {
            var mapData = mapObservation.Map.ToDictionary(
                r => new Region(r.Key),
                r => (ISet<City>)new HashSet<City>(r.Value.Keys.Select(c => new City(c)))
            );
            return new Map(mapData);
        }

        private static Phase OrientPhase(CurrentPhaseObservation currentPhaseObservation) => new Phase(currentPhaseObservation.Phase);

        private static ISet<Region> OrientRegionsInPlay(RegionsInPlayObservation regionsInPlayObservation)
        {
            return new HashSet<Region>(regionsInPlayObservation.Regions.Select(r => new Region(r)));
        }
    }
}