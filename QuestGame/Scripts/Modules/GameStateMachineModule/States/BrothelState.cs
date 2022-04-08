using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Modules.GameStateMachineModule.States
{
    public class BrothelState : BaseState
    {
        public BrothelState(string name, List<ICharacter> characters, IRoomCommand startCommand) 
            : base(name, startCommand)
        {
        }
    }
}