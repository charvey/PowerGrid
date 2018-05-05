namespace PowerGrid.Domain.Observations
{
    public class CurrentPhaseObservation : Observation
    {
        public int Phase { get; }

        public CurrentPhaseObservation(int phase)
        {
            this.Phase = phase;
        }
    }
}