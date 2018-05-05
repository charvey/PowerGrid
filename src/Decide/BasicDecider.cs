using System;
using System.Collections.Generic;
using System.Linq;
using PowerGrid.Domain;
using PowerGrid.Domain.Actions;
using PowerGrid.Domain.Game;

namespace PowerGrid.Decide
{
    public class BasicDecider : IDecider
    {
        public IEnumerable<GameAction> DecideActions(GameState gameState)
        {
            var powerGridGameState = gameState as PowerGridGameState;
            return new GameAction[]
            {
                new MakeRecommendationGameAction("Keep playing!"),
                new InformUser($"Currently in Phase {powerGridGameState.Phase.Number}"),
                new InformUser($"There are {powerGridGameState.Map.Cities.Count} cities on the map"),
                new InformUser($"There are {powerGridGameState.RegionsInPlay.SelectMany(r=>powerGridGameState.Map.CitiesInRegion(r)).Count()} cities in play")
            };
        }
    }
}