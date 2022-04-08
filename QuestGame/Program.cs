using System;

namespace QuestGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста, введите ваше имя:");
            var playerName = Console.ReadLine();
            
            var gameInitializer = new GameInitializer(playerName);
        }
    }
}