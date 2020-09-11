using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace _2DEngine._Engine
{
    public struct AudioClip
    {
        public string myClipName;
    }

    class AudioManager
    {
        private static AudioManager myInstance = null;

        public static AudioManager GetInstance()
        {
            if (myInstance == null)
                myInstance = new AudioManager();

            return myInstance;
        }

        public static List<AudioClip> myClips = null;

        public AudioManager()
        {
            myClips = new List<AudioClip>();
        }
    }
}
