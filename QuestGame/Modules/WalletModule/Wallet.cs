namespace QuestGame.Modules.WalletModule
{
    public class Wallet : IWallet
    {
        private int _coinsAmount;

        public Wallet()
        {
        }

        public Wallet(int coinsAmount)
        {
            _coinsAmount = coinsAmount;
        }

        public int CurrentBalance => _coinsAmount;
        
        public void AddToBalance(int amount)
        {
            _coinsAmount += amount;
        }

        public void RemoveFromBalance(int amount)
        {
            _coinsAmount -= amount;
        }
    }
}