using System;
using QuestGame.Helpers;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.GameStateMachineModule.States;
using QuestGame.Modules.PlayerModule;

namespace QuestGame
{
    public class GameBootstrapper
    {
        private readonly IPlayer _player;
        private readonly GameStateMachine _gameStateMachine;

        public GameBootstrapper(IPlayer player, GameStateMachine gameStateMachine)
        {
            _player = player;
            _gameStateMachine = gameStateMachine;
            
            StartGame();
        }

        private void StartGame()
        {
            Console.WriteLine($"Сэр {_player.Name}, вы рыцарь средневековья. Сейчас вы находитесь на окраине города Венеция. " +
                              $"Несколько дней назад вы были обмануты и ограблены шайкой разбойников на подступах к городу. " +
                              $"Вам предстоит найти и наказать этих негодяев и вернуть утраченное обмундирование.");
            
            Console.WriteLine($"Вы готовы начать поиски?");
            Console.WriteLine($"1. Да, готов.");
            Console.WriteLine($"2. Нет, отправлюсь домой.");
            
            var option = DialogueHelper.GetIntInRange(2);
            
            if (option == 1)
            {
                _gameStateMachine.Enter<TownState>();
            }
        }
    }
}