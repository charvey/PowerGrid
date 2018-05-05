using System.Collections.Generic;

namespace PowerGrid.Domain
{
    public interface IObserver
    {
        IEnumerable<Observation> MakeObservations();
    }
}