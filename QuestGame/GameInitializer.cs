using QuestGame.Factories;
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

            var characterFactory = new CharacterFactory(charactersDataProvider);
            
            GameStateMachine = new GameStateMachine(characterFactory);
            
            var characterListener = new CharacterListener(player, GameStateMachine, characterFactory);
        }
    }
}