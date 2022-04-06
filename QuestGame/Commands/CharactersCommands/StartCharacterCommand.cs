using System;
using System.Collections.Generic;
using QuestGame.Helpers;

namespace QuestGame.Commands.CharactersCommands
{
    public class StartCharacterCommand : ICommand
    {
        private List<string> _dialogue;
        private List<ICommand> _commands;
        public string Description { get; }

        public void Execute()
        {
            foreach (var element in _dialogue)
            {
                Console.WriteLine("- " + element);
            }
            
            for (int i = 0; i < _commands.Count; i++)
            {
                var optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {_commands[i].Description}");
            }
            
            var optionsCount = _commands.Count - 1;
            
            var number = DialogueHelper.GetIntInRange(optionsCount);

            var index = number - 1;
            
            _commands[index].Execute();
        }
    }
}