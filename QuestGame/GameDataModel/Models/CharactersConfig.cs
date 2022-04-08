using System.Collections.Generic;
using QuestGame.Commands;
using QuestGame.Commands.CharactersCommands;
using QuestGame.Helpers;

namespace QuestGame.GameDataModel.Models
{
    public class CharactersConfig
    { 
        public List<CharacterDataModel> CharactersDataModels { get; }

        public CharactersConfig()
        {
            CharactersDataModels = new List<CharacterDataModel>();

            InitializeTramp();
            InitializeBarman();
            InitializeAngelica();
            InitializeRobber();
        }

        private void InitializeAngelica()
        {
            var type = CharacterType.Angelica;
            var name = "Анжелика";
            var startBalance = 50;
            var priceInfo = 5;
            
            var dialogueDefault = new List<string>()
            {
                "Вы - 'Я ищу трёх мужчин которые меня ограбили несколько дней назад. Бармен сказал, что я могу найти их здесь.'",
                $"{name} - 'У нас тут бывает много мужчин всех и не припомнишь. Но, возможно, {priceInfo} монет освежат мою память.'",
            };
            
            var dialogueAfterPurchase = new List<string>()
            {
                $"{name} - 'Как дела? Могу ещё чем-то помочь?'",
                "Вы - 'Нет, спасибо.'",
                $"{name} - 'Ну ладно.'",
                
            };
            
            var dialogues = new List<Dialogue>()
            {
                new Dialogue(DialogueType.Default, dialogueDefault),
                new Dialogue(DialogueType.AfterPurchase, dialogueAfterPurchase),
            };
            
            var descriptionAfterPurchase = "'Да, помню этих трёх мужчин. Они явно были при деньга и знатно тут отдохнули.'" +
                                           "'Я слышала, что они говорили о какой-то лодке на пристани. Я думаю они сейчас там.'";
            var spendCoinsCommand = new SpendCoinsCommand(priceInfo, descriptionAfterPurchase);
            
            var reactionDescription = "'До встречи, красавчик!'";
            var leaveAloneCommand = new LeaveAloneCommand(reactionDescription, false);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                spendCoinsCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type ,name, startBalance, startCharacterCommand);
            
            CharactersDataModels.Add(newCharacter);
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
            
            var reactionToRobberyDescription = $"{name} - 'О, нет... Теперь я умру с голода!'";
            var robCommand = new RobCommand(reactionToRobberyDescription, false);

            var reactionToLeaveDescription = "Бродяга всадил Вам нож в спину как только Вы отвернулись.";
            var leaveAloneCommand = new LeaveAloneCommand(reactionToLeaveDescription, true);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                robCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type ,name, startBalance, startCharacterCommand);
            
            CharactersDataModels.Add(newCharacter);
        }

        private void InitializeBarman()
        {
            var type = CharacterType.Barman;
            var name = "Бармен";
            var startBalance = 100;
            var priceInfo = 10;
            
            var dialogueDefault = new List<string>()
            {
                "Вы - 'Я ищу трёх мужчин, которые меня ограбили. У одного из был огромный шрам на лице. Не поможешь их найти?'",
                $"{name} - 'Моя информация стоит {priceInfo} монет.'",
            };
            
            var dialogueAfterPurchase = new List<string>()
            {
                $"{name} - 'Нашёл тех ребят?'",
                "Вы - 'Нет, ещё в поисках...'",
                $"{name} - 'Удачи!'",
                
            };
            
            var dialogues = new List<Dialogue>()
            {
                new Dialogue(DialogueType.Default, dialogueDefault),
                new Dialogue(DialogueType.AfterPurchase, dialogueAfterPurchase),
            };
            
            var reactionToRobberyDescription = $"{name} - 'Ах ты ублюдок.' \nБармен позвал охранников и вас убили на улице города.";
            var robCommand = new RobCommand(reactionToRobberyDescription, true);
            
            var descriptionAfterPurchase = "'Те, кого ты ищешь, сейчас находятся сейчас в барделе 'Красная роза'. Удачи!'";
            var spendCoinsCommand = new SpendCoinsCommand(priceInfo, descriptionAfterPurchase);
            
            var reactionDescription = "'Буду рад нашей новой встрече.'";
            var leaveAloneCommand = new LeaveAloneCommand(reactionDescription, false);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                robCommand,
                spendCoinsCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type, name, startBalance, startCharacterCommand);
            
            CharactersDataModels.Add(newCharacter);
        }
        
        private void InitializeRobber()
        {
            var type = CharacterType.Robber;
            var name = "Гарбитель";
            var startBalance = 1000;

            var dialogueDefault = new List<string>()
            {
                "Вы - 'Вот мы и снова встретились! Сейчас вы пожалеете, что не убили меня тогда!'",
                $"{name} - 'Постой приятель. Возможно мы сможем договориться?'",
            };
            
            var dialogues = new List<Dialogue>()
            {
                new Dialogue(DialogueType.Default, dialogueDefault)
            };

            var fightCommand = new FightCommand();

            var reactionToLeaveDescription = "Грабитель решил просто потянуть время и дождаться сових сообщников чтобы прикончить вас." +
                                             "Как только сообщники вернулись - они вас убили!";
            var leaveAloneCommand = new LeaveAloneCommand(reactionToLeaveDescription, true);
            
            var startCharacterCommand = new StartCharacterCharacterCommand(dialogues, new List<ICharacterCommand>()
            {
                fightCommand,
                leaveAloneCommand,
            });

            var newCharacter = new CharacterDataModel(type ,name, startBalance, startCharacterCommand);
            
            CharactersDataModels.Add(newCharacter);
        }
    }
}