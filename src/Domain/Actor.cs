using System.Collections.Generic;

namespace PowerGrid.Domain
{
    public interface IActor
    {
        void Perform(IEnumerable<GameAction> actions);
    }
}