using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine
{
    public class Engine : Game
    {
        private GraphicsDeviceManager myGraphics;

        private Pool myPool = null;

        private EngineWindow myCurrentWindow = null;
        private int myCurrentWindowIndex = 0;
        private int myNextWindowIndex = 0;
        private EngineWindow[] myEngineWindows = null;

        public Engine()
        {
            //Window side
            myGraphics = new GraphicsDeviceManager(this);
            myGraphics.ApplyChanges();
            myGraphics.PreferredBackBufferHeight = Renderer.myWindow_Height;
            myGraphics.PreferredBackBufferWidth = Renderer.myWindow_Width;
            myGraphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Title";

            ContentManager.myContentManager = Content;

            //Engine
            AudioManager.GetInstance();
            myPool = new Pool();

            //Game
            if (Renderer.myInEngine)
            {
                myEngineWindows = new EngineWindow[] {
                    new _Tools.StartupPage(this) ,
                    new _ExampleGame.Game(this) ,
                    new _Tools.AnimatorTool(this) ,
                    new _Tools.LevelTool(this) ,
                    new _Tools.ObjectTool(this) ,
                    new _Tools.ComponentTool(this) ,
                    new _Tools.CompileAll(this) ,
                };
            }
            else
            {
                myEngineWindows = new EngineWindow[] {
                    new _ExampleGame.Game(this) ,
                };
            }
            myCurrentWindow = myEngineWindows[0];
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Renderer.myGraphicsDevice = myGraphics.GraphicsDevice;

            //Engine
            myPool.Initialize();
            Entities.GetInstance().Initialize();

            //Game
            for (int i = 0; i < myEngineWindows.Length; i++)
            {
                myEngineWindows[i].Initialize();
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Engine
            Renderer.mySpriteBatch = new SpriteBatch(GraphicsDevice);
            Renderer.myFont = Content.Load<SpriteFont>("Font/Arial");

            Resources.LoadComponents();
            Resources.LoadEntities();

            //Game
            for (int i = 0; i < myEngineWindows.Length; i++)
            {
                myEngineWindows[i].LoadContent();
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime aGameTime)
        {
            if(!myCurrentWindow.GetIsStarted())
            {
                myCurrentWindow.Start();
            }

            if (Renderer.myInEngine && (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)))
                Exit();

            // TODO: Add your update logic here

            //Engine
            Time.Update(aGameTime);
            Entities.GetInstance().InternalUpdate();
            Input.Update();

            if (Renderer.myInEngine)
            {
                for (int i = 0; i < myEngineWindows.Length; i++)
                {
                    if (Input.myKeyboardState.IsKeyDown((Keys)(112 + i)))
                    {
                        myNextWindowIndex = i;
                        break;
                    }
                }

                if (myNextWindowIndex != myCurrentWindowIndex)
                {
                    myCurrentWindowIndex = myNextWindowIndex;
                    myCurrentWindow.Stop();
                    myCurrentWindow = myEngineWindows[myNextWindowIndex];
                    myCurrentWindow.Awake();
                    myCurrentWindow.Start();

                    if (myCurrentWindow.myOneFrameWindow)
                        myCurrentWindowIndex = 0;
                }
            
            }

            //Game
            if(myCurrentWindow != null)
                myCurrentWindow.Update();

            Input.EndUpdate();

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
            if (myCurrentWindow != null)
                myCurrentWindow.Draw();

            Renderer.mySpriteBatch.End();

            base.Draw(aGameTime);
        }

        public EngineWindow[] GetEngineWindows()
        {
            return myEngineWindows;
        }
    }
}
