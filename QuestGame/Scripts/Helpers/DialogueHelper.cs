using System;

namespace QuestGame.Helpers
{
    public static class DialogueHelper
    {
        public static int GetIntInRange(int optionsCount)
        {
            var input = Console.ReadLine();
            var number = -1;
            bool isConverted = int.TryParse(input, out number);
            bool isInRange = number >= 1 && number <= optionsCount;

            while (!isConverted || !isInRange)
            {
                Console.WriteLine("Неверная опция, попробуй ещё раз");
                input = Console.ReadLine();
                isConverted = int.TryParse(input, out number);
                isInRange = number >= 1 && number <= optionsCount;
            }

            return number;
        }
    }
}