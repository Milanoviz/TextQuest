using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public class PierState : BaseState
    {
        public PierState(string name, List<ICharacter> characters, IRoomCommand startCommand) 
            : base(name, startCommand)
        {
            
        }
    }
}