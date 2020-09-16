using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2DEngine._Engine._Tools
{
    class Tool : EngineWindow
    {
        protected Texture2D myPanelTop = null;
        protected string myToolName = "";

        public override void Initialize()
        {
            base.Initialize();

            myPanelTop = new Texture2D(Renderer.myGraphicsDevice, 1, 1);
            myPanelTop.SetData(new[] { Color.White });
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();

            Renderer.mySpriteBatch.Draw(myPanelTop, new Rectangle(0, 0, Renderer.myWindow_Width, 40), Color.Gray);
            //Renderer.mySpriteBatch.DrawString(Renderer.myFont, myToolName, new Vector2((Renderer.myWindow_Width / 2) - 6, 0), Color.Black);
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
