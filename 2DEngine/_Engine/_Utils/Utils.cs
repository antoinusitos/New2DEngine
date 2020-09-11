using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine._Utils
{
    static class Utils
    {
        public static bool ContainsKey(Keys[] someKeys, Keys aKey)
        {
            for (int i = 0; i < someKeys.Length; i++)
            {
                if (someKeys[i] == aKey)
                    return true;
            }
            return false;
        }
    }
}
