using System;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands.CharactersCommands
{
    public class RobCommand : ICharacterCommand
    {
        public string Description { get; }
        
        private readonly string _reactionDescription;
        private readonly bool _isGameOver;

        public RobCommand(string reactionDescription, bool isGameOver)
        {
            _reactionDescription = reactionDescription;
            _isGameOver = isGameOver;
            Description = "Ограбить его.";
        }

        public void Execute(ICharacter invoker)
        {
            if (invoker.CurrentBalance > 0)
            {
                invoker.Rob();
                
                Console.WriteLine($"{invoker.Name} - {_reactionDescription} ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{invoker.Name} - 'У меня больше ничего нет!'" );
                Console.WriteLine();
            }
            
            invoker.StopDialogue(_isGameOver);
        }
    }
}