using System;
using System.Timers;
using NestedStatesConsole.State;

namespace NestedStatesConsole
{
    public class Player
    {
        private const int DefaultStrength = 10;
        public int Strength { get; set; } = DefaultStrength;
        public bool EnemyClose { get; private set; }
        private IState _state;
        private readonly Random _random;

        public Player()
        {
            _random = new Random();

            _state = new PatrolState(this);
        }

        public void ChangeState(IState newState)
        {
            _state.Exit();
            _state = newState;
            _state.Enter();
        }

        public void Update(object sender, ElapsedEventArgs e)
        {
            _state.Execute();
            EnemyClose = _random.NextDouble() > 0.75;
        }
    }
}
