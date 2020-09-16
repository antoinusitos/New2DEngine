using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Utils
{
    class Text : Entity
    {
        protected TransformComponent myTransformComponent = null;

        public Text(string aName) : base(aName)
        {

        }

        public override void Initialize()
        {
            base.Initialize();

            myTransformComponent = GetComponent<TransformComponent>() as TransformComponent;
        }

        public override void Draw()
        {
            if (!myIsActive)
                return;

            base.Draw();

            Renderer.mySpriteBatch.DrawString(Renderer.myFont, myName, myTransformComponent.myPosition, Color.Black);
        }
    }
}
