using System;
using System.Collections.Generic;
using System.Linq;
using QuestGame.GameDataModel;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.CharactersCommands
{
    public class StartCharacterCharacterCommand : ICharacterCommand
    {
        public string Description { get; }
        
        private List<Dialogue> _dialogues;
        private List<ICharacterCommand> _commands;

        public StartCharacterCharacterCommand(List<Dialogue> dialogues, List<ICharacterCommand> commands)
        {
            _dialogues = dialogues;
            _commands = commands;
        }

        public void Execute(ICharacter invoker)
        {
            ShowDialogue(invoker);
            
            ShowOptions(invoker);
        }

        private void ShowDialogue(ICharacter invoker)
        {
            var currentDialogue = invoker.IsTransactionCompleted 
                ? _dialogues.First(e => e.Type == DialogueType.AfterPurchase) 
                : _dialogues.First(e => e.Type == DialogueType.Default) ;
            
            foreach (var element in currentDialogue.DialogueText)
            {
                Console.WriteLine(element);
            }
        }

        private void ShowOptions(ICharacter invoker)
        {
            if (invoker.IsTransactionCompleted)
            {
                invoker.StopDialogue();
            }
            else
            {
                for (int i = 0; i < _commands.Count; i++)
                {
                    var optionNumber = i + 1;
                    Console.WriteLine($"{optionNumber}. {_commands[i].Description}");
                }
            
                var optionsCount = _commands.Count;
            
                var number = DialogueHelper.GetIntInRange(optionsCount);

                var index = number - 1;
            
                _commands[index].Execute(invoker);
            }
        }
    }
}