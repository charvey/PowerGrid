namespace PowerGrid.Domain.Actions
{
    public class WarnUser : GameAction
    {
        public string Warning { get; }

        public WarnUser(string warning)
        {
            this.Warning = warning;
        }
    }
}