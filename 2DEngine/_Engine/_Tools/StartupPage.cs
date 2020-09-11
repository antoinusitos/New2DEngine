using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class StartupPage : Tool
    {
        public override void Initialize()
        {
            base.Initialize();

            myToolName = "Start up Page";
            myWindowType = WindowType.STARTUP;
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

        }

        public override void Draw()
        {
            base.Draw();

            Renderer.mySpriteBatch.DrawString(Renderer.myFont, "Press F1 to enter in Start up Page", new Vector2((Renderer.myWindow_Width / 2) - 150, 200), Color.Black);
            Renderer.mySpriteBatch.DrawString(Renderer.myFont, "Press F2 to enter in Game Mode", new Vector2((Renderer.myWindow_Width / 2) - 150, 300), Color.Black);
            Renderer.mySpriteBatch.DrawString(Renderer.myFont, "Press F3 to enter in Animator Tool", new Vector2((Renderer.myWindow_Width / 2) - 150, 400), Color.Black);
            Renderer.mySpriteBatch.DrawString(Renderer.myFont, "Press F4 to enter in Level Tool", new Vector2((Renderer.myWindow_Width / 2) - 150, 500), Color.Black);
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
