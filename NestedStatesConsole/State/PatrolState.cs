using System;

namespace NestedStatesConsole.State
{
    public class PatrolState : IState
    {
        public Player Player { get; }

        public PatrolState(Player player)
        {
            Player = player;
        }

        public void Enter()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("On patrol...");
            Console.ResetColor();
        }

        public void Execute()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Player.Strength++;
            Console.WriteLine("Patroling");

            if (!Player.EnemyClose)
            {
                return;
            }

            if (Player.Strength > 5)
            {
                Player.ChangeState(new AttackState(Player));
            }
            else
            {
                Player.ChangeState(new HideState(Player));
            }

            Console.ResetColor();
        }

        public void Exit()
        {
        }
    }
}
