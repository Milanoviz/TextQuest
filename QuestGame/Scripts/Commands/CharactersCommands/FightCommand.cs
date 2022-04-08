using System;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.CharactersCommands
{
    public class FightCommand : ICharacterCommand
    {
        public string Description { get; }


        public FightCommand()
        {
            Description = "Сражаться";
        }

        public void Execute(ICharacter invoker)
        {
            Console.WriteLine($"Вы убили персонажа {invoker.Name}.");
            
            invoker.Rob();
            invoker.Kill();
        }
    }
}