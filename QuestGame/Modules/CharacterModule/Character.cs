using QuestGame.Commands;

namespace QuestGame.Modules.CharacterModule
{
    public class Character : ICharacter
    {
        public string Name { get; }
        public string Description { get; }
        public ICommand Command { get; }
        
        public void StartDialogue()
        {
            Command.Execute();
        }
    }
}