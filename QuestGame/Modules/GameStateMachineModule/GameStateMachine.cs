using System.Collections.Generic;
using System.Linq;
using QuestGame.Commands;
using QuestGame.Commands.CharactersCommands;
using QuestGame.Commands.RoomCommands;
using QuestGame.GameDataModel.Providers;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame.Modules.GameStateMachineModule
{
    public class GameStateMachine
    {
        public BaseState ActiveState => _activeState;
        public List<ICharacter> AllCharacters => _allCharacters;

        private readonly List<BaseState> _allStates;
        private readonly List<ICharacter> _allCharacters;
        
        private BaseState _activeState;
        
        public GameStateMachine(ICharactersDataModelProvider charactersDataModelProvider)
        {
            _allStates = new List<BaseState>();
            _allCharacters = new List<ICharacter>();

            InitializeTavernaState(charactersDataModelProvider);
        }

        private void InitializeTavernaState(ICharactersDataModelProvider charactersDataModelProvider)
        {
            var characters = new List<ICharacter>()
            {
                CreateCharacter(CharacterType.Tramp, charactersDataModelProvider),
                CreateCharacter(CharacterType.Barman, charactersDataModelProvider),
                
            };

            var lookAroundCommand = new LookAroundCommand();
            var startDialogueCommand = new StartDialogueCommand(characters);
            
            var startCommand = new RoomEntryCommand(new List<IRoomCommand>()
            {
                lookAroundCommand,
                startDialogueCommand,
            });
            
            var tavernaState = new TavernaState("Таверна", characters, startCommand);
            
            _allStates.Add(tavernaState);
        }

        private ICharacter CreateCharacter(CharacterType type, ICharactersDataModelProvider charactersDataModelProvider)
        {
            var newCharacter = new Character(charactersDataModelProvider.GetCharacterDataModelOfType(type));
            
            _allCharacters.Add(newCharacter);

            return newCharacter;
        }
        
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