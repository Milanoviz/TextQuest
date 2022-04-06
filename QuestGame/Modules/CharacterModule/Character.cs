using System;
using QuestGame.Commands;
using QuestGame.GameDataModel.Models;
using QuestGame.Helpers;
using QuestGame.Modules.WalletModule;

namespace QuestGame.Modules.CharacterModule
{
    public class Character : ICharacter
    { 
        public event EventHandler<int> CharacterRobbed;
        public event EventHandler<bool> DialogueCompleted;
        public event EventHandler<int> TookCoins;

        public CharacterType Type { get; }
        public string Name { get; }
        public bool IsTransactionCompleted { get; set; }
        public int CurrentBalance => _wallet.CurrentBalance;
        
        private readonly IWallet _wallet;
        private readonly ICharacterCommand _startCommand;
        

        public Character(CharacterDataModel characterDataModel)
        {
            Type = characterDataModel.Type;
            Name = characterDataModel.Name;
            
            _startCommand = characterDataModel.StartCommand;
            _wallet = new Wallet(characterDataModel.StartBalance);
        }

        public void StartDialogue()
        {
            _startCommand.Execute(this);
        }

        public void AddToBalance(int amount)
        {
            _wallet.AddToBalance(amount);
        }

        public void RemoveFromBalance(int amount)
        {
            _wallet.RemoveFromBalance(amount);
        }

        public void Rob()
        {
            var currentBalance = _wallet.CurrentBalance;
            RemoveFromBalance(currentBalance);

            OnCharacterRobbed(currentBalance);
        }

        public void TakeCoins(int count)
        {
            OnTookCoins(count);
        }

        public void StopDialogue(bool isGameOver)
        {
            OnDialogueCompleted(isGameOver);
        }

        private void OnCharacterRobbed(int coinsAmount)
        {
            CharacterRobbed?.Invoke(this, coinsAmount);
        }        
        private void OnDialogueCompleted(bool isGameOver)
        {
            DialogueCompleted?.Invoke(this, isGameOver);
        }

        private void OnTookCoins(int count)
        {
            TookCoins?.Invoke(this, count);
        }
    }
}