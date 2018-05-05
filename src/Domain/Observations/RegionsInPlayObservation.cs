namespace PowerGrid.Domain.Observations
{
    public class RegionsInPlayObservation : Observation
    {
        public string[] Regions { get; }

        public RegionsInPlayObservation(string[] regions)
        {
            this.Regions = regions;
        }
    }
}