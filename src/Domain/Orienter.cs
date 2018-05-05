using System.Collections.Generic;

namespace PowerGrid.Domain
{
    public interface IOrienter
    {
        GameState OrientGameState(IEnumerable<Observation> observations);
    }
}