using System;
using System.Collections.Generic;
using QuestGame.Factories;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.PlayerModule;

namespace QuestGame
{
    public class CharacterListener
    {
        private readonly IPlayer _player;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICharactersFactory _charactersFactory;

        private List<ICharacter> _characters => _charactersFactory.AllCharacters;

        public CharacterListener(IPlayer player, GameStateMachine gameStateMachine, ICharactersFactory charactersFactory)
        {
            _player = player;
            _gameStateMachine = gameStateMachine;
            _charactersFactory = charactersFactory;

            Initialize();
        }

        private void Initialize()
        {
            foreach (var character in _characters)
            {
                character.CharacterRobbed += HandleCharacterRobbed;
                character.DialogueCompleted += HandleDialogueCompleted;
                character.TookCoins += HandleTookCoins;
                character.Killed += HandleKilled;
            }
        }

        private void HandleKilled(object sender, CharacterType type)
        {
            if (type == CharacterType.Robber)
            {
                Console.WriteLine($"Поздравяем Вас, сэр {_player.Name}! Вы уничтожили грабителя обокравшего вас и вернули свои вещи!");
                Console.WriteLine("Теперь вы можете вернуться домой с чувством выполненного долга!");
                Console.WriteLine();
                Console.WriteLine("Конец игры!");
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
            
            Console.WriteLine($"Вы получили {amount} монет.");
            Console.WriteLine($"Теперь ваш баланс составляет {_player.CurrentBalance} монет.");
        }
    }
}