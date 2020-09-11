using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class SpriteRendererComponent : Component
    {
        public string myTexturePath = "";
        public Color myColor = Color.White;

        protected Texture2D myTexture2D = null;

        private TransformComponent myTransformComponent = null;

        public SpriteRendererComponent(string aTexturePath)
        {
            myTexturePath = aTexturePath;
        }

        public override void Initialize(Entity anEntity)
        {
            base.Initialize(anEntity);

            myTransformComponent = anEntity.GetComponent<TransformComponent>() as TransformComponent;
        }

        public override void LoadContent()
        {
            myTexture2D = ContentManager.GetContentManager().Load<Texture2D>(myTexturePath);
        }

        public override void Draw()
        {
            if (myTexture2D == null)
                return;

            Vector2 pos = Vector2.Zero;
            //Vector2 scale = Vector2.One;

            if (myTransformComponent != null)
            {
                pos = myTransformComponent.myPosition;
                //scale = myTransformComponent.myScale;
            }

            Renderer.mySpriteBatch.Draw(myTexture2D, pos, myColor);
        }

        public void SetTexture(Texture2D aTexture2D)
        {
            myTexture2D = aTexture2D;
        }

        public Texture2D GetTexture()
        {
            return myTexture2D;
        }
    }
}
