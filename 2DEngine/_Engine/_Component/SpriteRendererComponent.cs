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

        public SpriteRendererComponent()
        {
            myName = "SpriteRendererComponent";
        }

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
            myTexture2D = ContentManager.GetContentManager().Load<Texture2D>(Renderer.myTexturePath + myTexturePath);
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

        public void SetTexturePath(string aPath)
        {
            myTexturePath = aPath;
        }

        public void SetTexture(Texture2D aTexture2D)
        {
            myTexture2D = aTexture2D;
        }

        public Texture2D GetTexture()
        {
            return myTexture2D;
        }

        public override string Save()
        {
            string text = "COMPONENT:SpriteRendererComponent\n";
            text += "ID:" + myID + "\n";
            text += "TEXTURE:" + myTexturePath + "\n";
            text += "COLORR:" + myColor.R.ToString() + "\n";
            text += "COLORG:" + myColor.G.ToString() + "\n";
            text += "COLORB:" + myColor.B.ToString() + "\n";
            text += "COLORA:" + myColor.A.ToString();

            return text;
        }

        public override void Load(string aLine)
        {
        }

        public override void ReadArg(string aLine)
        {
            string[] args = aLine.Split(':');
            if(args[0] == "TEXTURE")
                myTexturePath = args[1];
            else if(args[0] == "COLORR")
                myColor.R = byte.Parse(args[1]);
            else if (args[0] == "COLORG")
                myColor.G = byte.Parse(args[1]);
            else if (args[0] == "COLORB")
                myColor.B = byte.Parse(args[1]);
            else if (args[0] == "COLORA")
                myColor.A = byte.Parse(args[1]);
        }
    }
}
