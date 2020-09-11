using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DEngine._Engine
{
    static class Renderer
    {
        public const int myWindow_Width = 1920;
        public const int myWindow_Height = 1080;

        public const bool myInEngine = true;

        public static GraphicsDevice myGraphicsDevice = null;
        public static SpriteBatch mySpriteBatch;
        public static SpriteFont myFont;

        public const float myGravityValue = 1.0f;
        public static Vector2 myGravityVector = Vector2.UnitY * myGravityValue;
        //public static Vector2 myGravityVector = Vector2.UnitX * myGravityValue;
    }
}
