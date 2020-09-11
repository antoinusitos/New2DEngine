using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine
{
    static class Input
    {
        public static KeyboardState myKeyboardState;

        public static MouseState myMouseState;

        public static void Update()
        {
            // Poll for current keyboard state
            myKeyboardState = Keyboard.GetState();

            myMouseState = Mouse.GetState();
        }
    }
}
