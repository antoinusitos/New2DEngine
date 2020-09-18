using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine
{
    static class Input
    {
        public static KeyboardState myKeyboardState;

        public static MouseState myMouseState;

        private static Keys[] myLastPressedKeys = null;

        public static void Update()
        {
            // Poll for current keyboard state
            myKeyboardState = Keyboard.GetState();

            myMouseState = Mouse.GetState();
        }

        public static bool GetKeyPressed(Keys aKey)
        {
            if(!Utils.ContainsKey(myLastPressedKeys, aKey) && myKeyboardState.IsKeyDown(aKey))
            {
                return true;
            }

            return false;
        }

        public static bool GetKeyPress(Keys aKey)
        {
            if (myKeyboardState.IsKeyDown(aKey))
            {
                return true;
            }

            return false;
        }

        public static bool GetKeyReleased(Keys aKey)
        {
            if (Utils.ContainsKey(myLastPressedKeys, aKey) && !myKeyboardState.IsKeyDown(aKey))
            {
                return true;
            }

            return false;
        }

        public static void EndUpdate()
        {
            myLastPressedKeys = myKeyboardState.GetPressedKeys();
        }
    }
}
