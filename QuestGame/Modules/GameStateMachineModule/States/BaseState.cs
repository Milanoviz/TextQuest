using System;
using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public abstract class BaseState
    {
        public string Name;
        public string Description;
        public List<ICharacter> Characters;
        
        public ICommand StartCommand;

        protected BaseState(string name, string description, List<ICharacter> characters, ICommand startCommand)
        {
            Name = name;
            Description = description;
            Characters = characters;
            StartCommand = startCommand;
        }

        public virtual void Enter()
        {
            Console.WriteLine($"Вы находитесь в {Name}");
            
            StartCommand.Execute();
        }

        public virtual void Exit()
        {
            
        }
    }
}