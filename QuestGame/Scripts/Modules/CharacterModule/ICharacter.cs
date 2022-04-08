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
        event EventHandler<CharacterType> Killed;
      
        CharacterType Type { get; }
        string Name { get; }

        bool IsTransactionCompleted { get; set; }

        void StartDialogue();
        void StopDialogue(bool isGameOver = false);

        void Rob();
        void Kill();
        void TakeCoins(int count);
    }
}