using Microsoft.Xna.Framework;

namespace _2DEngine._Engine
{
    static class Time
    {
        public static float myDeltaTime = 0;
        public static float myTime = 0;

        private static float myLastTime = 0;

        public static void Update(GameTime aGameTime)
        {
            myTime = (float)aGameTime.TotalGameTime.TotalSeconds;
            myDeltaTime = myTime - myLastTime;
            myLastTime = myTime;
        }
    }
}
