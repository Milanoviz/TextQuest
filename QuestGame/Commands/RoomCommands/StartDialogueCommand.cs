using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.RoomCommands
{
    public class StartDialogueCommand : ICommand
    {
        private List<ICharacter> Characters;
        private ICommand _previousCommand;
        public string Description { get; } = "Начать диалог";

        public void Execute()
        {
            if (Characters.Count > 0)
            {
                Console.WriteLine("С кем бы вы хотели поговорить?");
                
                for (int i = 0; i < Characters.Count; i++)
                {
                    var optionNumber = i + 1;
                    Console.WriteLine($"{optionNumber}. {Characters[i].Name}");
                }
                
                var optionsCount = Characters.Count - 1;

                var number = DialogueHelper.GetIntInRange(optionsCount);

                var index = number - 1;
                
                Characters[index].StartDialogue();
            }
            else
            {
                Console.WriteLine("В комнате никого нет");
                _previousCommand.Execute();
            }
            
        }
    }
}