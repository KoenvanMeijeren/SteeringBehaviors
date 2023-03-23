using System;

namespace NestedStatesConsole.State
{
    public class HideState : IState
    {
        public Player Player { get; }

        public HideState(Player player)
        {
            Player = player;
        }
        
        public void Enter()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Enemy in sight!");
            Console.ResetColor();
        }

        public void Execute()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Player.Strength++;
            Console.WriteLine("Hiding...");

            if (!Player.EnemyClose)
            {
                Player.ChangeState(new PatrolState(Player));
            }
            Console.ResetColor();
        }

        public void Exit()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("It's save again");
            Console.ResetColor();
        }
    }
}
