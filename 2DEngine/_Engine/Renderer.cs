using Microsoft.Xna.Framework.Graphics;

namespace _2DEngine._Engine
{
    static class Renderer
    {
        public const int myWindow_Width = 1920;
        public const int myWindow_Height = 1080;

        public static GraphicsDevice myGraphicsDevice = null;
        public static SpriteBatch mySpriteBatch;
        public static SpriteFont myFont;
    }
}
