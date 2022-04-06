using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.WalletModule;

namespace QuestGame.Modules.CharacterModule
{
    public interface ICharacter : IOwnerWallet
    {
        event EventHandler<int> CharacterRobbed;
        event EventHandler<bool> DialogueCompleted;
        event EventHandler<int> TookCoins;
      
        CharacterType Type { get; }
        string Name { get; }
        
        void StartDialogue();
        void StopDialogue(bool isGameOver = false);

        void Rob();
        void TakeCoins(int count);
        bool IsTransactionCompleted { get; set; }
    }
}