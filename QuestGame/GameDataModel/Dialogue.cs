using System.Collections.Generic;
using QuestGame.Helpers;

namespace QuestGame.GameDataModel
{
    public class Dialogue
    {
        private readonly DialogueType _type;
        private readonly List<string> _dialogueText;

        public DialogueType Type => _type;

        public List<string> DialogueText => _dialogueText;

        public Dialogue(DialogueType type, List<string> dialogueText)
        {
            _type = type;
            _dialogueText = dialogueText;
        }
    }
}