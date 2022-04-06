using QuestGame.Modules.CharacterModule;

namespace QuestGame.Commands
{
    public interface ICharacterCommand
    { 
        string Description { get; }
        void Execute(ICharacter invoker);
    }
    
    public interface IRoomCommand
    { 
        string Description { get; }
        void Execute(IRoomCommand previousCommand = null);
    }
}