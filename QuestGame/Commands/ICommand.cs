namespace QuestGame.Commands
{
    public interface ICommand
    { 
        string Description { get; }
        void Execute();
    }
}