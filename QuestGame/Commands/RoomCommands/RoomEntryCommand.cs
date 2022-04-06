using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.RoomCommands
{
    public class RoomEntryCommand : ICommand
    {
        public List<ICommand> Commands;

        public string Description { get; } = "Выберите действие";

        public void Execute()
        {
            List<ICharacter> characters = new List<ICharacter>();
            
            Console.WriteLine(Description);

            for (int i = 0; i < Commands.Count; i++)
            {
                var optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {Commands[i].Description}");
            }
            
            var optionsCount = Commands.Count - 1;
            
            var number = DialogueHelper.GetIntInRange(optionsCount);

            var index = number - 1;
            
            Commands[index].Execute();
        }
    }
}