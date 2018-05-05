using System.Collections.Generic;

namespace PowerGrid.Domain
{
    public interface IDecider
    {
        IEnumerable<GameAction> DecideActions(GameState gameState);
    }
}