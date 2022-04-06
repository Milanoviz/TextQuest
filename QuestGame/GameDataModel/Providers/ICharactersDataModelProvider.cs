using QuestGame.GameDataModel.Models;
using QuestGame.Helpers;

namespace QuestGame.GameDataModel.Providers
{
    public interface ICharactersDataModelProvider
    {
        CharacterDataModel GetCharacterDataModelOfType(CharacterType type);
    }
}