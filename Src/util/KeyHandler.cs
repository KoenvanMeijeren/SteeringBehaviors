using System.Windows.Forms;

namespace Src.util
{
    public static class KeyHandler
    {
        private static bool _wKeyPressed;
        private static bool _aKeyPressed;
        private static bool _sKeyPressed;
        private static bool _dKeyPressed;

        private const int _speed = 20;

        public static void RegisterPressedKeys(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.W)
            {
                _wKeyPressed = true;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.A)
            {
                _aKeyPressed = true;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.S)
            {
                _sKeyPressed = true;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.D)
            {
                _dKeyPressed = true;
                return;
            }
        }

        public static void RegisterUnpressedKeys(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.W)
            {
                _wKeyPressed = false;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.A)
            {
                _aKeyPressed = false;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.S)
            {
                _sKeyPressed = false;
                return;
            }

            if (keyEventArgs.KeyCode == Keys.D)
            {
                _dKeyPressed = false;
                return;
            }
        }

        public static Vector GetKeysDirection()
        {
            int x = 0;
            int y = 0;

            if (_wKeyPressed)
            {
                y -= _speed;
            }

            if (_aKeyPressed)
            {
                x -= _speed;
            }

            if (_sKeyPressed)
            {
                y += _speed;
            }

            if (_dKeyPressed)
            {
                x += _speed;
            }

            return new Vector(x, y);
        }
    }
}
