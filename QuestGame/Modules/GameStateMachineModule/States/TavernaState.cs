using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public class TavernaState : BaseState
    {
        public TavernaState(string name, string description, List<ICharacter> characters, ICommand startCommand) 
            : base(name, description, characters, startCommand)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}