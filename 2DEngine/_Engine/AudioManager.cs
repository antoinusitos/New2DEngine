using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace _2DEngine._Engine
{
    public struct AudioClip
    {
        public string myClipName;
        public Song myClip;
    }

    public struct SoundEffectClip
    {
        public string myEffectName;
        public SoundEffect myEffect;
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

        //single instance of clip played at one time
        public static List<AudioClip> myClips = null;
        //multiple instance of clip played at one time
        public static List<SoundEffectClip> mySoundEffects = null;

        public AudioManager()
        {
            myClips = new List<AudioClip>();
            mySoundEffects = new List<SoundEffectClip>();
        }

        public void PlaySound(string aName)
        {
            for(int i = 0; i < myClips.Count; i++)
            {
                if(myClips[i].myClipName == aName)
                {
                    MediaPlayer.Play(myClips[i].myClip);
                    return;
                }
            }
        }

        public void PlaySoundEffect(string aName)
        {
            for (int i = 0; i < mySoundEffects.Count; i++)
            {
                if (mySoundEffects[i].myEffectName == aName)
                {
                    mySoundEffects[i].myEffect.Play();
                    return;
                }
            }
        }
    }
}
