namespace QuestGame.Commands
{
    public interface IRoomCommand
    { 
        string Description { get; }
        void Execute(IRoomCommand previousCommand = null);
    }
}