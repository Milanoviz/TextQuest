using System;
using System.Collections.Generic;
using QuestGame.Helpers;

namespace QuestGame.Commands.RoomCommands
{
    public class RoomEntryCommand : IRoomCommand
    {
        public string Description { get; }
        
        private readonly List<IRoomCommand> _commands;


        public RoomEntryCommand(List<IRoomCommand> commands)
        {
            _commands = commands;

            Description = "Выберите действие:";
        }

        public void Execute(IRoomCommand previousCommand)
        {
            Console.WriteLine("\n" + Description);
            
            ShowOptions();
            
            var optionsCount = _commands.Count;
            var number = DialogueHelper.GetIntInRange(optionsCount);
            var index = number - 1;
            
            _commands[index].Execute(this);
        }

        private void ShowOptions()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                var optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {_commands[i].Description}");
            }
        }
    }
}