using System.Windows.Forms;
using Src.util;

namespace SteeringCS.util
{
    public static class KeyEventArgsConverter
    {
        public static PressedKey CreateFromEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    return PressedKey.W;
                case Keys.A:
                    return PressedKey.A;
                case Keys.S:
                    return PressedKey.S;
                case Keys.D:
                    return PressedKey.D;
                default:
                    return PressedKey.DoNothing;
            }
        }
    }
}
