using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine.Engine
{
    public class Engine : Game
    {
        private GraphicsDeviceManager myGraphics;

        private const int myWindow_Width = 800;
        private const int myWindow_Height = 600;

        private Pool myPool = null;

        private ExampleGame.Game myGame = null;

        public Engine()
        {
            //Window side
            myGraphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = myWindow_Height,
                PreferredBackBufferWidth = myWindow_Width
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Title";

            ContentManager.myContentManager = Content;

            //Engine
            AudioManager.GetInstance();
            myPool = new Pool();

            //Game
            myGame = new ExampleGame.Game();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Engine
            myPool.Initialize();
            Entities.GetInstance().Initialize();

            //Game
            myGame.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Engine
            Renderer.mySpriteBatch = new SpriteBatch(GraphicsDevice);

            //Game
            myGame.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime aGameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Engine
            Time.Update(aGameTime);
            Entities.GetInstance().InternalUpdate();
            Input.Update();

            //Game
            myGame.Update();

            base.Update(aGameTime);
        }

        protected override void Draw(GameTime aGameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Renderer.mySpriteBatch.Begin();
            //Engine
            Entities.GetInstance().InternalDraw();

            //Game
            myGame.Draw();
            Renderer.mySpriteBatch.End();

            base.Draw(aGameTime);
        }
    }
}
