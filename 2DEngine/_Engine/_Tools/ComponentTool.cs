using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class ComponentTool : Tool
    {
        private Text myToolLabel = null;
        private Text myObjectNameLabel = null;
        private InputField myInputField = null;
        private Button mySaveButton = null;
        private Button mySaveButtonCustom = null;

        public ComponentTool(Engine anEngine) : base(anEngine)
        {
            myToolName = "Component Tool";
        }

        public override void Initialize()
        {
            base.Initialize();

            myToolLabel = new Text("Component Tool");

            myObjectNameLabel = new Text("Component Name:");
            myWindowType = WindowType.OBJECT;

            myInputField = new InputField("Input Name");
            mySaveButton = new Button("Create");
            mySaveButtonCustom = new Button("Create Custom");
        }

        public override void LoadContent()
        {
            base.LoadContent();

            mySaveButton.LoadContent();
            mySaveButton.myOnClickDelegate += () => Create(true);
            myInputField.LoadContent();
            mySaveButtonCustom.LoadContent();
            mySaveButtonCustom.myOnClickDelegate += () => Create(false);
        }

        public override void Start()
        {
            base.Start();

            myToolLabel.Initialize();
            myObjectNameLabel.Initialize();
            myInputField.Initialize();
            mySaveButton.Initialize();
            mySaveButtonCustom.Initialize();

            ((TransformComponent)myToolLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 0);

            ((TransformComponent)myObjectNameLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 50);

            ((TransformComponent)myInputField.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 100);

            ((TransformComponent)mySaveButton.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 3 * 2.5f), 50);
            
            ((TransformComponent)mySaveButtonCustom.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 3 * 2.5f), 100);
        }

        public override void Update()
        {
            mySaveButton.InternalUpdate();
            mySaveButtonCustom.InternalUpdate();
            myInputField.InternalUpdate();
        }

        public override void Draw()
        {
            base.Draw();

            myToolLabel.InternalDraw();

            myObjectNameLabel.InternalDraw();

            mySaveButton.InternalDraw();
            mySaveButtonCustom.InternalDraw();
            myInputField.InternalDraw();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void Create(bool aInEngine)
        {
            string name = myInputField.GetText();
            if (name == "")
                return;

            Resources.CreateComponent(name, aInEngine);

            Debug.Log("Created Component " + name);
        }
    }
}
