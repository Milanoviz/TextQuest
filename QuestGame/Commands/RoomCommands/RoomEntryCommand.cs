using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.RoomCommands
{
    public class RoomEntryCommand : IRoomCommand
    {
        public List<IRoomCommand> Commands;

        public string Description { get; }


        public RoomEntryCommand(List<IRoomCommand> commands)
        {
            Commands = commands;

            Description = "Выберите действие:";
        }

        public void Execute(IRoomCommand previousCommand)
        {
            List<ICharacter> characters = new List<ICharacter>();
            
            Console.WriteLine(Description);

            for (int i = 0; i < Commands.Count; i++)
            {
                var optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {Commands[i].Description}");
            }
            
            var optionsCount = Commands.Count;
            
            var number = DialogueHelper.GetIntInRange(optionsCount);

            var index = number - 1;
            
            Commands[index].Execute(this);
        }
    }
}