using System;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.CharactersCommands
{
    public class SpendCoinsCommand : ICharacterCommand
    {
        public string Description { get; }
        
        private readonly int _coinsCount;
        private readonly string _descriptionAfterPurchase;

        public SpendCoinsCommand(int coinsCount, string descriptionAfterPurchase)
        {
            Description = "Отдать моенты.";
            
            _coinsCount = coinsCount;
            _descriptionAfterPurchase = descriptionAfterPurchase;
        }

        public void Execute(ICharacter invoker)
        {
            invoker.TakeCoins(_coinsCount);

            if (invoker.IsTransactionCompleted)
            {
                Console.WriteLine($"{invoker.Name} - {_descriptionAfterPurchase}");
            }
            else
            {
                Console.WriteLine($"{invoker.Name} - У тебя недостаточно денег. Возвращайся когда их раздабудешь.");
            }
            
            invoker.StopDialogue();
        }
    }
}