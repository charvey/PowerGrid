namespace PowerGrid.Domain.Actions
{
    public class MakeRecommendationGameAction : GameAction
    {
        public string Recommendation { get; }

        public MakeRecommendationGameAction(string recommendation)
        {
            this.Recommendation = recommendation;
        }
    }
}