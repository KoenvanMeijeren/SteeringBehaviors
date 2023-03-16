using System;
using System.Diagnostics.CodeAnalysis;

namespace Src.util
{
    [ExcludeFromCodeCoverage]
    public static class Randomizer
    {
        private static readonly Random s_randomizerObject = new Random();

        public static int GetRandomNumber(int minimum, int maximum)
        {
            return s_randomizerObject.Next(minimum, maximum);
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            return s_randomizerObject.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int RandomClamped()
        {
            return s_randomizerObject.NextDouble() >= 0.5 ? -1 : 1;
        }
    }
}
