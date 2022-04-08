using QuestGame.Factories;
using QuestGame.GameDataModel.Models;
using QuestGame.GameDataModel.Providers;
using QuestGame.Modules.GameStateMachineModule;
using QuestGame.Modules.PlayerModule;

namespace QuestGame
{
    public class GameInitializer
    {
        public GameInitializer(string playerName)
        {
            var player = new Player(playerName);

            var charactersConfig = new CharactersConfig();
            var charactersDataProvider = new CharactersDataModelProvider(charactersConfig);

            var characterFactory = new CharacterFactory(charactersDataProvider);
            
            var gameStateMachine = new GameStateMachine(characterFactory);
            
            var characterListener = new CharacterListener(player, gameStateMachine, characterFactory);

            var gameBootstrapper = new GameBootstrapper(player, gameStateMachine);
        }
    }
}