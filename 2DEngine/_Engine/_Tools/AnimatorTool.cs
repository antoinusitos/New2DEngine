using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class AnimatorTool : Tool
    {
        private Text myToolLabel = null;

        public AnimatorTool(Engine anEngine) : base(anEngine)
        {
            myToolName = "Object Tool";
        }

        public override void Initialize()
        {
            base.Initialize();

            myToolLabel = new Text("Animator Tool");
            myWindowType = WindowType.ANIMATOR;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Start()
        {
            base.Start();

            myToolLabel.Initialize();
            ((TransformComponent)myToolLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 0);
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            base.Draw();

            myToolLabel.InternalDraw();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
