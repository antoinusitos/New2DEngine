using Microsoft.Xna.Framework.Input;

namespace _2DEngine.Engine
{
    static class Input
    {
        public static KeyboardState myKeyboardState;

        public static void Update()
        {
            // Poll for current keyboard state
            myKeyboardState = Keyboard.GetState();
        }
    }
}
