using QuestGame.GameDataModel.Models;
using QuestGame.GameDataModel.Providers;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.PlayerModule;

namespace QuestGame
{
    public class GameInitializer
    { 
        public GameStateMachine GameStateMachine { get; }

        public GameInitializer(string playerName)
        {
            var player = new Player(playerName);

            var charactersConfig = new CharactersConfig();
            var charactersDataProvider = new CharactersDataModelProvider(charactersConfig);
            
            GameStateMachine = new GameStateMachine(charactersDataProvider);
            
            var gameFacade = new GameFacade(player, GameStateMachine);
        }
    }
}