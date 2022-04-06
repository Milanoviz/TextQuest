namespace QuestGame.Modules.PlayerModule
{
    public interface IPlayer
    {
        string Name { get; }
        int CurrentBalance { get; }
        void AddToBalance(int amount);
        void RemoveFromBalance(int amount);
    }
}