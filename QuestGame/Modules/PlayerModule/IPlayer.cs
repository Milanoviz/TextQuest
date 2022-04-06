using QuestGame.Modules.WalletModule;

namespace QuestGame.Modules.PlayerModule
{
    public interface IPlayer : IOwnerWallet
    {
        string Name { get; }
    }
}