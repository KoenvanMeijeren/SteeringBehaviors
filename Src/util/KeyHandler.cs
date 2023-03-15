using System.Windows.Forms;

namespace Src.util
{
    public static class KeyHandler
    {
        private static bool s_wKeyPressed;
        private static bool s_aKeyPressed;
        private static bool s_sKeyPressed;
        private static bool s_dKeyPressed;

        private const int _speed = 20;

        public static void RegisterPressedKeys(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    s_wKeyPressed = true;
                    return;
                case Keys.A:
                    s_aKeyPressed = true;
                    return;
                case Keys.S:
                    s_sKeyPressed = true;
                    return;
                case Keys.D:
                    s_dKeyPressed = true;
                    return;
            }
        }

        public static void RegisterUnpressedKeys(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    s_wKeyPressed = false;
                    return;
                case Keys.A:
                    s_aKeyPressed = false;
                    return;
                case Keys.S:
                    s_sKeyPressed = false;
                    return;
                case Keys.D:
                    s_dKeyPressed = false;
                    return;
            }
        }

        public static Vector GetKeysDirection()
        {
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
