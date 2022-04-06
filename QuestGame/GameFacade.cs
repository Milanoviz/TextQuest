using System;
using System.Collections.Generic;
using System.Linq;
using QuestGame.Modules.CharacterModule;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.GameStateMachineModule.States;
using QuestGame.Modules.PlayerModule;

namespace QuestGame
{
    public class GameFacade
    {
        private readonly IPlayer _player;
        private readonly GameStateMachine _gameStateMachine;
        
        private List<ICharacter> _characters => _gameStateMachine.AllCharacters;

        public GameFacade(IPlayer player, GameStateMachine gameStateMachine)
        {
            _player = player;
            _gameStateMachine = gameStateMachine;

            Initialize();
        }

        private void Initialize()
        {
            foreach (var character in _characters)
            {
                character.CharacterRobbed += HandleCharacterRobbed;
                character.DialogueCompleted += HandleDialogueCompleted;
                character.TookCoins += HandleTookCoins;
            }
        }

        private void HandleTookCoins(object sender, int coinsCount)
        {
            var character =  sender as ICharacter;
            
            if (_player.CurrentBalance >= coinsCount)
            {
                _player.RemoveFromBalance(coinsCount);
                
                Console.WriteLine($"Вы отдали {coinsCount} монет {character.Name}");
                Console.WriteLine($"Теперь ваш баланс составляет {_player.CurrentBalance} монет.");
                
                character.IsTransactionCompleted = true;
            }
            else
            {
                character.IsTransactionCompleted = false;
            }
        }

        private void HandleDialogueCompleted(object sender, bool isGameOver)
        {
            if (!isGameOver)
            {
                var activeState = _gameStateMachine.ActiveState;

                activeState.StartCommand.Execute();
            }
            else
            {
                Console.WriteLine("Ты проиграл!");
            }
        }

        private void HandleCharacterRobbed(object sender, int amount)
        {
            _player.AddToBalance(amount);
            
            Console.WriteLine($"Вы получили {amount} монет");
            Console.WriteLine($"Теперь ваш баланс составляет {_player.CurrentBalance} монет");
        }
    }
}