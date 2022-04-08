using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public class TavernaState : BaseState
    {
        public TavernaState(string name, List<ICharacter> characters, IRoomCommand startCommand) 
            : base(name, startCommand)
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