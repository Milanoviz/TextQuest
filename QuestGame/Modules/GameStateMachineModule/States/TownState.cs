using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public class TownState : BaseState
    {
        public TownState(string name, List<ICharacter> characters, IRoomCommand startCommand) 
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