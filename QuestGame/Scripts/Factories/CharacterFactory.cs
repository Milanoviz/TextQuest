using System.Collections.Generic;
using QuestGame.GameDataModel.Providers;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.Factories
{
    public class CharacterFactory : ICharactersFactory
    {
        private readonly ICharactersDataModelProvider _charactersDataModelProvider;

        private List<ICharacter> _allCharacters;

        public List<ICharacter> AllCharacters => _allCharacters;

        public CharacterFactory(ICharactersDataModelProvider charactersDataModelProvider)
        {
            _charactersDataModelProvider = charactersDataModelProvider;

            _allCharacters = new List<ICharacter>();
        }

        public ICharacter CreateCharacter(CharacterType type)
        {
            var characterDataModel = _charactersDataModelProvider.GetCharacterDataModelOfType(type);
            
            var newCharacter = new Character(characterDataModel);
            
            _allCharacters.Add(newCharacter);
            
            return newCharacter;
        }
    }
}