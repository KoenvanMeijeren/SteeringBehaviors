using System;

namespace Src.util
{
    public static class Randomizer
    {
        public static Random RandomizerObject = new Random();

        public static int GetRandomNumber(int minimum, int maximum)
        {
            return RandomizerObject.Next(minimum, maximum);
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            return RandomizerObject.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int RandomClamped()
        {
            return RandomizerObject.NextDouble() >= 0.5 ? -1 : 1;
        }
    }
}
