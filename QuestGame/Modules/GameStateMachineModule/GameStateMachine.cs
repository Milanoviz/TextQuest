using System.Collections.Generic;
using System.Linq;
using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame.Modules.GameStateMachineModule
{
    public class GameStateMachine
    {
        private List<BaseState> _allStates;

        private BaseState _activeState;
        
        public GameStateMachine()
        {
            
        }

        public void Enter<TState>() where TState : BaseState
        {
            BaseState state = ChangeState<TState>();
            state.Enter();
        }
        
        private TState ChangeState<TState>() where TState :  BaseState
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