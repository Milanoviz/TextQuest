using QuestGame.Modules.GameStateMachineModule.States;

namespace QuestGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new GameInitializer("Артём");
            game.GameStateMachine.Enter<TavernaState>();
        }
    }
}