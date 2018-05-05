namespace PowerGrid.Domain.Actions
{
    public class InformUser : GameAction
    {
        public string Information { get; }

        public InformUser(string information)
        {
            this.Information = information;
        }
    }
}