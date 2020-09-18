using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class StartupPage : Tool
    {
        private Text[] myLabels = null;

        public StartupPage(Engine anEngine) : base(anEngine)
        {
            myToolName = "Start up Page";
        }

        public override void Initialize()
        {
            base.Initialize();

            myWindowType = WindowType.STARTUP;

            myLabels = new Text[myEngine.GetEngineWindows().Length];

            for(int i = 0; i < myEngine.GetEngineWindows().Length; i++)
            {
                myLabels[i] = new Text("Press F" + (i+1) + " to enter in " + myEngine.GetEngineWindows()[i].GetToolName());
            }
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < myLabels.Length; i++)
            {
                myLabels[i].Initialize();
                ((TransformComponent)myLabels[i].GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 150, 200 + 100 * i);
            }
        }   

        public override void Update()
        {

        }

        public override void Draw()
        {
            base.Draw();

            for (int i = 0; i < myLabels.Length; i++)
            {
                myLabels[i].InternalDraw();
            }
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
