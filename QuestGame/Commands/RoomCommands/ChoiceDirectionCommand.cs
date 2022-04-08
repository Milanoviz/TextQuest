using System;
using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame.Commands.RoomCommands
{
    public class ChoiceDirectionCommand : IRoomCommand
    {
        public string Description { get; }

        private readonly GameStateMachine _gameStateMachine;
        private readonly List<BaseState> _allStates;
        private readonly string _currentStateName;

        public ChoiceDirectionCommand(GameStateMachine gameStateMachine, List<BaseState> allStates, string currentStateName)
        {
            Description = "Отправиться в другую комнату.";

            _gameStateMachine = gameStateMachine;
            _allStates = allStates;
            _currentStateName = currentStateName;
        }

        public void Execute(IRoomCommand previousCommand = null)
        {
            Console.WriteLine("Куда бы вы хотели отправиться?");
            
            ShowOptions(out var availableRoomNames);
            
            SwitchRoom(availableRoomNames);
        }

        private void ShowOptions(out List<string> availableRoomNames)
        {
            availableRoomNames = new List<string>();
            
            var optionsNumber = 0;

            foreach (var state in _allStates)
            {
                if (!state.Name.Equals(_currentStateName))
                {
                    Console.WriteLine($"{++optionsNumber} Отправиться в {state.Name}");
                    availableRoomNames.Add(state.Name);
                }
            }
        }

        private void SwitchRoom(List<string> availableRoomNames)
        {
            var optionsCount = _allStates.Count - 1;
            var number = DialogueHelper.GetIntInRange(optionsCount);
            var index = number - 1;

            var nextRoomName = availableRoomNames[index];

            switch (nextRoomName)
            {
                case "Таверна":
                    _gameStateMachine.Enter<TavernaState>();
                    break;
                case "Город":
                    _gameStateMachine.Enter<TownState>();
                    break;
                case "Бордель":
                    _gameStateMachine.Enter<BrothelState>();
                    break;
                case "Пристань":
                    _gameStateMachine.Enter<PierState>();
                    break;
            }
        }
    }
}