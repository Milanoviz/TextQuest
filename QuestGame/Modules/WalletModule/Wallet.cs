namespace QuestGame.Modules.WalletModule
{
    public class Wallet : IWallet
    {
        private int _goldAmount;

        public int CurrentBalance => _goldAmount;
        
        public void AddToBalance(int amount)
        {
            _goldAmount += amount;
        }

        public void RemoveFromBalance(int amount)
        {
            _goldAmount -= amount;
        }
    }
}