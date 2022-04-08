using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.RoomCommands
{
    public class LookAroundCommand : IRoomCommand
    {
        public string Description { get; }
        
        private readonly List<ICharacter> _characters;
        
        public LookAroundCommand(List<ICharacter> characters)
        {
            Description = "Осмотреться";
            _characters = characters;
        }
        
        public void Execute(IRoomCommand previousCommand)
        {
            Console.WriteLine("Вы осмотрелись.");
            
            ShowAvailableCharacters();
            
            previousCommand.Execute(this);
        }

        private void ShowAvailableCharacters()
        {
            var result = new StringBuilder();

            if (_characters.Count > 0)
            {
                result.Append("В комнате находятся: ");
                
                foreach (var character in _characters)
                {
                    result.Append(character != _characters.Last() ? $"{character.Name}, " : $"{character.Name}.");
                }
            }
            else
            {
                result.Append("В комнате никого нет.");
            }
            
            Console.WriteLine(result);
        }
    }
}