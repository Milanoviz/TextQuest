using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.RoomCommands
{
    public class StartDialogueCommand : IRoomCommand
    {
        private readonly List<ICharacter> _characters;
        public string Description { get; }


        public StartDialogueCommand(List<ICharacter> characters)
        {
            Description = "Начать диалог";
            
            _characters = characters;
        }

        public void Execute(IRoomCommand previousCommand)
        {
            if (_characters.Count > 0)
            {
                Console.WriteLine("С кем бы вы хотели поговорить?");
                
                ShowOptions();
                
                var optionsCount = _characters.Count;
                var number = DialogueHelper.GetIntInRange(optionsCount);
                var index = number - 1;
                
                _characters[index].StartDialogue();
            }
            else
            {
                Console.WriteLine("В комнате никого нет.");
                previousCommand.Execute();
            }
        }

        private void ShowOptions()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                var optionNumber = i + 1;
                Console.WriteLine($"{optionNumber}. {_characters[i].Name}");
            }
        }
    }
}