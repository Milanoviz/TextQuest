namespace QuestGame.Modules.WalletModule
{
    public interface IWallet
    {
        int CurrentBalance { get; }
        void AddToBalance(int amount);
        void RemoveFromBalance(int amount);
    }
}