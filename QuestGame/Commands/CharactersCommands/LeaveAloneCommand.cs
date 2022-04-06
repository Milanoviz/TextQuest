using System;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.CharactersCommands
{
    public class LeaveAloneCommand : ICharacterCommand
    {
        public string Description { get; }

        private readonly string _reactionDescription;
        private readonly bool _isGameOver;

        public LeaveAloneCommand(string reactionDescription, bool isGameOver)
        {
            Description = "Оставить в покое";
            
            _reactionDescription = reactionDescription;
            _isGameOver = isGameOver;
        }

        public void Execute(ICharacter invoker)
        {
            Console.WriteLine(_reactionDescription);
            
            invoker.StopDialogue(_isGameOver);
        }
    }
}