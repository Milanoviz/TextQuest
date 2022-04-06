using System;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame.Commands.RoomCommands
{
    public class LookAroundCommand : ICommand
    {
        private BaseState _invokerState;
        private ICommand _previousCommand;
        public string Description { get; } = "Осмотреть комнату";

        public void Execute()
        {
            Console.WriteLine("Вы осмотрели комнату");
            Console.WriteLine(_invokerState.Description);
            _previousCommand.Execute();
        }
    }
}