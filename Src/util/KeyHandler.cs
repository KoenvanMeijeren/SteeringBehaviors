namespace Src.util
{
    public enum PressedKey
    {
        W,
        A,
        S,
        D,
        DoNothing
    }

    public static class a
    {
        private static bool s_wKeyPressed,
            s_aKeyPressed,
            s_sKeyPressed,
            s_dKeyPressed,
            s_doNothingKeyPressed;

        private const int _speed = 20;

        public static void Reset()
        {
            s_wKeyPressed = false;
            s_aKeyPressed = false;
            s_sKeyPressed = false;
            s_dKeyPressed = false;
            s_doNothingKeyPressed = false;
        }

        public static void RegisterPressedKeys(PressedKey pressedKey)
        {
            switch (pressedKey)
            {
                case PressedKey.W:
                    s_wKeyPressed = true;
                    break;
                case PressedKey.A:
                    s_aKeyPressed = true;
                    break;
                case PressedKey.S:
                    s_sKeyPressed = true;
                    break;
                case PressedKey.D:
                    s_dKeyPressed = true;
                    break;
                case PressedKey.DoNothing:
                default:
                    s_doNothingKeyPressed = true;
                    break;
            }
        }

        public static void RegisterUnpressedKeys(PressedKey pressedKey)
        {
            switch (pressedKey)
            {
                case PressedKey.W:
                    s_wKeyPressed = false;
                    break;
                case PressedKey.A:
                    s_aKeyPressed = false;
                    break;
                case PressedKey.S:
                    s_sKeyPressed = false;
                    break;
                case PressedKey.D:
                    s_dKeyPressed = false;
                    break;
                case PressedKey.DoNothing:
                default:
                    s_doNothingKeyPressed = false;
                    break;
            }
        }

        public static Vector GetKeysDirection()
        {
            if (s_doNothingKeyPressed)
            {
                return new Vector(0, 0);
            }

            int x = 0;
            int y = 0;

            if (s_wKeyPressed)
            {
                y -= _speed;
            }

            if (s_aKeyPressed)
            {
                x -= _speed;
            }

            if (s_sKeyPressed)
            {
                y += _speed;
            }

            if (s_dKeyPressed)
            {
                x += _speed;
            }

            return new Vector(x, y);
        }
    }
}
