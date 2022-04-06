using System.Collections.Generic;
using System.Linq;
using QuestGame.Commands;
using QuestGame.Commands.RoomCommands;
using QuestGame.Factories;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame.Modules.GameStateMachineModule
{
    public class GameStateMachine
    {
        public BaseState ActiveState => _activeState;

        private readonly ICharactersFactory _characterFactory;

        private readonly List<BaseState> _allStates;

        private BaseState _activeState;

        public GameStateMachine(ICharactersFactory characterFactory)
        {
            _characterFactory = characterFactory;
            _allStates = new List<BaseState>();

            InitializeTavernaState();
            InitializeBrothelState();
            InitializeTownState();
        }

        #region Initialization States
        private void InitializeTavernaState()
        {
            var name = "Таверна";
            
            var characters = new List<ICharacter>()
            {
                _characterFactory.CreateCharacter(CharacterType.Tramp),
                _characterFactory.CreateCharacter(CharacterType.Barman),
            };

            var lookAroundCommand = new LookAroundCommand();
            var startDialogueCommand = new StartDialogueCommand(characters);
            var choiceDirectionCommand = new ChoiceDirectionCommand(this, _allStates, name);

            var startCommand = new RoomEntryCommand(new List<IRoomCommand>()
            {
                lookAroundCommand,
                startDialogueCommand,
                choiceDirectionCommand,
            });

            var tavernaState = new TavernaState(name, characters, startCommand);
            
            _allStates.Add(tavernaState);
        }
        
        private void InitializeBrothelState()
        {
            var name = "Бордель";
            
            var characters = new List<ICharacter>()
            {
                _characterFactory.CreateCharacter(CharacterType.Tramp),
            };

            var lookAroundCommand = new LookAroundCommand();
            var startDialogueCommand = new StartDialogueCommand(characters);
            var choiceDirectionCommand = new ChoiceDirectionCommand(this, _allStates, name);

            var startCommand = new RoomEntryCommand(new List<IRoomCommand>()
            {
                lookAroundCommand,
                startDialogueCommand,
                choiceDirectionCommand,
            });

            var tavernaState = new BrothelState(name, characters, startCommand);
            
            _allStates.Add(tavernaState);
        }

        private void InitializeTownState()
        {
            var name = "Город";
            
            var characters = new List<ICharacter>()
            {
                _characterFactory.CreateCharacter(CharacterType.Tramp),
                _characterFactory.CreateCharacter(CharacterType.Barman),
            };

            var lookAroundCommand = new LookAroundCommand();
            var choiceDirectionCommand = new ChoiceDirectionCommand(this, _allStates, name);
            
            var startCommand = new RoomEntryCommand(new List<IRoomCommand>()
            {
                lookAroundCommand,
                choiceDirectionCommand,
            });

            var tavernaState = new TownState(name, characters, startCommand);
            
            _allStates.Add(tavernaState);
        }
        #endregion
        
        public void Enter<TState>() where TState : BaseState
        {
            BaseState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : BaseState
        {
            _activeState?.Exit();

            var state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is TState);

            return state as TState;
        }
    }
}