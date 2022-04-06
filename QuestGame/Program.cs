using System;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста, введите ваше имя:");
            var playerName = Console.ReadLine();
            
            var game = new GameInitializer(playerName);
            game.GameStateMachine.Enter<TownState>();
        }
    }
}