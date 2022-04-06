using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Commands.CharactersCommands;
using QuestGame.Helpers;
using QuestGame.Modules.CharacterModule;

namespace QuestGame.GameDataModel.Models
{
    public class CharactersConfig
    {
        private List<CharacterDataModel> _charactersDataModels;

        public List<CharacterDataModel> CharactersDataModels => _charactersDataModels;

        public CharactersConfig()
        {
            _charactersDataModels = new List<CharacterDataModel>();

            InitializeTramp();
            InitializeBarman();
        }

        private void InitializeTramp()
        {
            var type = CharacterType.Tramp;
            var name = "Бродяга";
            var startBalance = 10;

            var dialogueDefault = new List<string>()
            {
                "Вы - 'Жизнь или смерть, грязный бродяга!'",
                $"{name} - 'Вот возьми всё что у меня есть, только не трогай меня.'",
            };
            
            var dialogues = new List<Dialogue>()
            {
                new Dialogue(DialogueType.Default, dialogueDefault)
            };
            
            var reactionToRobberyDescription = $"{name} - 'О, нет... Теперь я умру с голода' ";
            var robCommand = new RobCommand(reactionToRobberyDescription, false);

            var reactionToLeaveDescription = "Бродяга всадил Вам нож в спину как только Вы отвернулись.";
            var leaveAloneCommand = new LeaveAloneCommand(reactionToLeaveDescription, true);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                robCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type ,name, startBalance, startCharacterCommand);
            
            _charactersDataModels.Add(newCharacter);
        }

        private void InitializeBarman()
        {
            var type = CharacterType.Barman;
            var name = "Бармен";
            var startBalance = 100;
            var priceInfo = 10;
            
            var dialogueDefault = new List<string>()
            {
                "Вы - 'Я ищу трёх мужчин, которые меня ограбили. У одного из был огромный шрам на лице. Не поможешь их найти? '",
                $"{name} - 'Моя информация стоит {priceInfo} монет'.",
            };
            
            var dialogueAfterPurchase = new List<string>()
            {
                $"{name} - 'Нашёл тех ребят?'.",
                "Вы - 'Нет, ещё в поисках'",
                $"{name} - 'Удачи!'.",
                
            };
            
            var dialogues = new List<Dialogue>()
            {
                new Dialogue(DialogueType.Default, dialogueDefault),
                new Dialogue(DialogueType.AfterPurchase, dialogueAfterPurchase),
            };
            
            var reactionToRobberyDescription = $"{name} - 'Ах ты ублюдок.' \n Бармен позвал охранников и вас убили на улице города ";
            var robCommand = new RobCommand(reactionToRobberyDescription, true);
            
            var descriptionAfterPurchase = "Те кого ты ищешь сейчас находятся сейчас в барделе 'Красная роза'. Удачи!";
            var spendCoinsCommand = new SpendCoinsCommand(priceInfo, descriptionAfterPurchase);
            
            

            var reactionDescription = "Буду рад нашей новой встрече";
            var leaveAloneCommand = new LeaveAloneCommand(reactionDescription, false);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                robCommand,
                spendCoinsCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type, name, startBalance, startCharacterCommand);
            
            _charactersDataModels.Add(newCharacter);
        }
    }
}