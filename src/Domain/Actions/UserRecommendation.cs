namespace PowerGrid.Domain.Actions
{
    public class UserRecommendation : GameAction
    {
        public string Recommendation { get; }

        public UserRecommendation(string recommendation)
        {
            this.Recommendation = recommendation;
        }
    }
}