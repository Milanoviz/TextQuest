using QuestGame.Modules.WalletModule;

namespace QuestGame.Modules.PlayerModule
{
    public class Player : IPlayer
    {
        private readonly IWallet _wallet;
        
        public string Name { get; }
        public int CurrentBalance => _wallet.CurrentBalance;

        public Player(string name)
        {
            Name = name;
            _wallet = new Wallet();
        }
        
        public void AddToBalance(int amount)
        {
            
        }

        public void RemoveFromBalance(int amount)
        {
            
        }
    }
}