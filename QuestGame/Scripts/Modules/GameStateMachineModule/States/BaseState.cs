using System;
using QuestGame.Commands;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public abstract class BaseState
    {
        public string Name => _name;
        public IRoomCommand StartCommand => _startCommand;

        private readonly string _name;
        private readonly IRoomCommand _startCommand;
        
        protected BaseState(string name, IRoomCommand startCommand)
        {
            _name = name;
            _startCommand = startCommand;
        }

        public virtual void Enter()
        {
            Console.WriteLine($"\nВы находитесь в {_name}");
            
            _startCommand.Execute();
        }

        public virtual void Exit()
        {
            
        }
    }
}