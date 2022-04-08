using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands
{
    public interface ICharacterCommand
    { 
        string Description { get; }
        void Execute(ICharacter invoker);
    }
}