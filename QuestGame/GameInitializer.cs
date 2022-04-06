using QuestGame.Modules.GameStateMachineModule;

namespace QuestGame
{
    public class GameInitializer
    {
        public GameStateMachine GameStateMachine { get; }

        public GameInitializer(string playerName)
        {
            GameStateMachine = new GameStateMachine();
        }
    }
}