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

    public static class KeyHandler
    {
        private static bool s_wKeyPressed,
            s_aKeyPressed,
            s_sKeyPressed,
            s_dKeyPressed;

        private const int Speed = 20;
        private const int SpeedDiagonal = 15;

        public static void Reset()
        {
            s_wKeyPressed = false;
            s_aKeyPressed = false;
            s_sKeyPressed = false;
            s_dKeyPressed = false;
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
                    break;
            }
        }

        public static Vector GetKeysDirection()
        {
            int x = 0;
            int y = 0;

            int speed = Speed;

            if ((s_wKeyPressed ? 1 : 0) +
                (s_aKeyPressed ? 1 : 0) +
                (s_sKeyPressed ? 1 : 0) +
                (s_dKeyPressed ? 1 : 0)
                >= 2)
            {
                speed = SpeedDiagonal;
            }

            if (s_wKeyPressed)
            {
                y -= speed;
            }

            if (s_aKeyPressed)
            {
                x -= speed;
            }

            if (s_sKeyPressed)
            {
                y += speed;
            }

            if (s_dKeyPressed)
            {
                x += speed;
            }

            return new Vector(x, y);
        }
    }
}
