namespace _2DEngine._Engine
{
    class ContentManager
    {
        public static Microsoft.Xna.Framework.Content.ContentManager myContentManager = null;

        public static Microsoft.Xna.Framework.Content.ContentManager GetContentManager()
        {
            return myContentManager;
        }
    }
}
