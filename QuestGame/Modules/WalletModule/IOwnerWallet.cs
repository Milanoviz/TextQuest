namespace QuestGame.Modules.WalletModule
{
    public interface IOwnerWallet
    {
        int CurrentBalance { get; }
        void AddToBalance(int amount);
        void RemoveFromBalance(int amount);
    }
}