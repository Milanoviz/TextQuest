using System.Collections.Generic;

namespace QuestGame.Modules.CharacterModule
{
    public interface ICharacter
    {
        string Name { get; }
        string Description { get; }
        void StartDialogue();
    }
}