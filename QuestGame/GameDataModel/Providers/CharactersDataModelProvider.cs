using System.Linq;
using QuestGame.GameDataModel.Models;
using QuestGame.Helpers;

namespace QuestGame.GameDataModel.Providers
{
    public class CharactersDataModelProvider : ICharactersDataModelProvider
    {
        private CharactersConfig _config;

        public CharactersDataModelProvider(CharactersConfig config)
        {
            _config = config;
        }

        public CharacterDataModel GetCharacterDataModelOfType(CharacterType type)
        {
            return _config.CharactersDataModels.FirstOrDefault(c => c.Type == type);
        }
    }
}