using System;
using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public abstract class BaseState
    {
        public string Name;
        public List<ICharacter> Characters;
        public IRoomCommand StartCommand;

        protected BaseState(string name, List<ICharacter> characters, IRoomCommand startCommand)
        {
            Name = name;
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