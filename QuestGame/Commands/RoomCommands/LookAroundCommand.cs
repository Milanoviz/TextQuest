using System;

namespace QuestGame.Commands.RoomCommands
{
    public class LookAroundCommand : IRoomCommand
    {
        public string Description { get; }

        public LookAroundCommand()
        {
            Description = "Осмотреть комнату";
        }
        
        public void Execute(IRoomCommand previousCommand)
        {
            Console.WriteLine("Вы осмотрели комнату" + "\n");
            previousCommand.Execute(this);
        }
    }
}