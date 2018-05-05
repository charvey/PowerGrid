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
            return new GameAction[]
            {
                new UserRecommendation("Keep playing!")
            }.Concat(GameInformation(gameState as PowerGridGameState));
        }

        private IEnumerable<GameAction> GameInformation(PowerGridGameState powerGridGameState)
        {
            if(powerGridGameState == null)
                return new[]{new WarnUser("I'm having trouble understanding what's happening")};

            return new[]
            {
                new InformUser($"Currently in Phase {powerGridGameState.Phase.Number}"),
                new InformUser($"There are {powerGridGameState.Map.Cities.Count} cities on the map"),
                new InformUser($"There are {powerGridGameState.RegionsInPlay.SelectMany(r=>powerGridGameState.Map.CitiesInRegion(r)).Count()} cities in play")
            };
        }
    }
}