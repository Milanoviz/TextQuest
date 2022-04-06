using System.Collections.Generic;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Factories
{
    public interface ICharactersFactory
    {
        List<ICharacter> AllCharacters { get; }
        ICharacter CreateCharacter(CharacterType type);
    }
}