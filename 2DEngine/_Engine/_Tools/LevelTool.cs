using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class LevelTool : Tool
    {
        private Text myToolLabel = null;
        private Text myLevelNameLabel = null;
        private InputField myInputField = null;
        private Button mySaveButton = null;

        private Scene myScene = null;

        public LevelTool(Engine anEngine) : base(anEngine)
        {
            myToolName = "Level Tool";
        }

        public override void Initialize()
        {
            base.Initialize();

            myToolLabel = new Text("Level Tool");
            myWindowType = WindowType.LEVEL;

            myLevelNameLabel = new Text("Level Name:");
            myInputField = new InputField("Input Name");
            mySaveButton = new Button("Save");
        }

        public override void LoadContent()
        {
            base.LoadContent();

            myInputField.LoadContent();
            mySaveButton.LoadContent();
            mySaveButton.myOnClickDelegate += () => Save();
        }

        public override void Start()
        {
            base.Start();

            myToolLabel.Initialize();
            myLevelNameLabel.Initialize();
            myInputField.Initialize();
            mySaveButton.Initialize();

            ((TransformComponent)myToolLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 0);

            ((TransformComponent)myLevelNameLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 50);

            ((TransformComponent)myInputField.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6 + 200, 50);

            ((TransformComponent)mySaveButton.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 3 * 2.5f), 50);

            myScene = new Scene();
            myScene.Initialize();

            Entity player = Resources.GetPrefab("Player");
            if (player != null)
            {
                myScene.AddEntity(player, false);
                ((TransformComponent)player.GetComponent<TransformComponent>()).myPosition = new Vector2(0, 500);
            }
            else
            {
                Debug.Log("Cannot find Prefab 'Player'");
            }

            Entity trigger = Resources.GetPrefab("Trigger");
            if (trigger != null)
            {
                myScene.AddEntity(trigger, false);
                ((TransformComponent)trigger.GetComponent<TransformComponent>()).myPosition = new Vector2(100, 450);
            }
            else
            {
                Debug.Log("Cannot find Prefab 'Trigger'");
            }

            Entity floor = Resources.GetPrefab("Floor");
            if (floor != null)
            {
                myScene.AddEntity(floor, false);
                ((TransformComponent)floor.GetComponent<TransformComponent>()).myPosition = new Vector2(0, 550);
            }
            else
            {
                Debug.Log("Cannot find Prefab 'Floor'");
            }
        }

        public override void Update()
        {
            myInputField.InternalUpdate();
            mySaveButton.InternalUpdate();
        }

        public override void Draw()
        {
            base.Draw();

            myToolLabel.InternalDraw();

            myLevelNameLabel.InternalDraw();
            myInputField.InternalDraw();

            mySaveButton.InternalDraw();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void Save()
        {
            if (myInputField.GetText() == "")
                return;

            myScene.SetName(myInputField.GetText());

            Resources.SaveScene(myScene);

            Debug.Log("Saved the scene " + myInputField.GetText());
        }
    }
}
