using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using _2DEngine._Engine._Component;

namespace _2DEngine._Engine
{
    class Animator : Component
    {
        public struct AnimatorStruct
        {
            public int myFrame;
            public Texture2D myTexture;
            public string myTexturePath;
        }

        private SpriteRendererComponent mySpriteRendererComponent = null;
        private List<AnimatorStruct> myAnimations = null;
        private int myCurrentFrame = 0;

        public override void Initialize(Entity anEntity)
        {
            base.Initialize(anEntity);

            mySpriteRendererComponent = anEntity.GetComponent<SpriteRendererComponent>() as SpriteRendererComponent;
            myAnimations = new List<AnimatorStruct>();
        }

        public override void LoadContent()
        {
            for (int i = 0; i < myAnimations.Count; i++)
            {
                AnimatorStruct animatorStruct = myAnimations[i];
                animatorStruct.myTexture = ContentManager.GetContentManager().Load<Texture2D>(myAnimations[i].myTexturePath);
                myAnimations[i] = animatorStruct;
            }
        }

        public override void Update()
        {


        }
    }
}
