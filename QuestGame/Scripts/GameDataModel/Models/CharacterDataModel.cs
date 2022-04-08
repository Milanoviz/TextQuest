using QuestGame.Commands;
using QuestGame.Helpers;

namespace QuestGame.GameDataModel.Models
{
    public class CharacterDataModel
    {
        private readonly CharacterType _type;
        private readonly string _name;
        private readonly int _startBalance;
        private readonly ICharacterCommand _startCommand;

        public CharacterType Type => _type;

        public string Name => _name;

        public int StartBalance => _startBalance;

        public ICharacterCommand StartCommand => _startCommand;

        public CharacterDataModel(CharacterType type, string name, int startBalance, ICharacterCommand startCommand)
        {
            _type = type;
            _name = name;
            _startBalance = startBalance;
            _startCommand = startCommand;
        }
    }
}