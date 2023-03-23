using System;

namespace NestedStatesConsole.State
{
    public class AttackState : IState
    {
        public Player Player { get; }
        private IAttackState _attackState;
        public int Power { get; set; } = 5;

        public AttackState(Player player)
        {
            Player = player;
        }

        public void ChangeState(IAttackState newState)
        {
            _attackState?.Exit();
            _attackState = newState;
            _attackState.Enter();
        }

        public void Enter()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start the fight!");
            Console.ResetColor();

            ChangeState(new DoAttackState(this));
        }

        public void Execute()
        {
            _attackState.Execute();
        }

        public void Exit()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Defeated the enemy!");
            Console.ResetColor();
        }
    }

    public class RegenerateAttackPowerState : IAttackState
    {
        public AttackState AttackState { get; }

        public RegenerateAttackPowerState(AttackState attackState)
        {
            AttackState = attackState;
        }

        public void Enter()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Re-generate attack power");
            Console.ResetColor();
        }

        public void Execute()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            AttackState.Power++;
            Console.WriteLine("Re-generate...");

            if (AttackState.Power > 6)
            {
                AttackState.ChangeState(new DoAttackState(AttackState));
            }

            Console.ResetColor();
        }

        public void Exit()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Achieved full attack power!");
            Console.ResetColor();
        }
    }

    public class DoAttackState : IAttackState
    {
        public AttackState AttackState { get; }

        public DoAttackState(AttackState attackState)
        {
            AttackState = attackState;
        }

        public void Enter()
        {

        }

        public void Execute()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            AttackState.Power--;
            AttackState.Player.Strength--;
            Console.WriteLine("Fighting");
            Console.ResetColor();

            if (AttackState.Player.Strength < 5)
            {
                AttackState.Player.ChangeState(new HideState(AttackState.Player));
                return;
            }

            if (AttackState.Power < 4)
            {
                AttackState.ChangeState(new RegenerateAttackPowerState(AttackState));
            }
        }

        public void Exit()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Running out of attack power...");
            Console.ResetColor();
        }
    }
}
