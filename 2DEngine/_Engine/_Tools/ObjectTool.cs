using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Tools
{
    class ObjectTool : Tool
    {
        private Text myToolLabel = null;
        private Text myObjectNameLabel = null;
        private InputField myInputField = null;
        private Button mySaveButton = null;

        private Text mySpriteRendererLabel = null;
        private Button mySpriteRendererButton = null;
        private SpriteRendererComponent mySpriteRendererComponent = null;
        private InputField mySpriteName = null;

        private Entity myEditedEntity = null;

        public override void Initialize()
        {
            base.Initialize();

            myToolLabel = new Text("Object Tool");

            myObjectNameLabel = new Text("Object Name:");
            myWindowType = WindowType.OBJECT;

            myInputField = new InputField("Input Name");
            mySaveButton = new Button("Save");

            mySpriteRendererLabel = new Text("------Sprite Renderer------");
            mySpriteRendererButton = new Button("Add Sprite Renderer");
            mySpriteName = new InputField("Sprite Path");
        }

        public override void LoadContent()
        {
            base.LoadContent();

            mySaveButton.LoadContent();
            mySaveButton.myOnClickDelegate += () => Save();
            myInputField.LoadContent();

            mySpriteRendererButton.LoadContent();
            mySpriteRendererButton.myOnClickDelegate += () => AddSpriteRendererComponent();
            mySpriteName.LoadContent();
        }

        public override void Start()
        {
            base.Start();

            myToolLabel.Initialize();
            myObjectNameLabel.Initialize();
            myInputField.Initialize();
            mySaveButton.Initialize();
            mySpriteRendererLabel.Initialize();
            mySpriteRendererLabel.myIsActive = false;
            mySpriteRendererButton.Initialize();
            mySpriteName.Initialize();
            mySpriteName.myIsActive = false;


            ((TransformComponent)myToolLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 0);
            
            ((TransformComponent)myObjectNameLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6, 50);

            ((TransformComponent)myInputField.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6 + 200, 50);

            ((TransformComponent)mySaveButton.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 3 * 2.5f), 50);

            ((TransformComponent)mySpriteRendererLabel.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2), 150);
            
            ((TransformComponent)mySpriteRendererButton.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2), 150);

            ((TransformComponent)mySpriteName.GetComponent<TransformComponent>()).myPosition = new Vector2((Renderer.myWindow_Width / 2), 200);

            myEditedEntity = new Entity("") { myID = Entities.GetInstance().GetID() };
            myEditedEntity.Initialize();
        }

        public override void Update()
        {
            mySaveButton.InternalUpdate();
            myInputField.InternalUpdate();

            mySpriteName.InternalUpdate();
            mySpriteRendererButton.InternalUpdate();
        }


        public override void Draw()
        {
            base.Draw();

            myToolLabel.InternalDraw();

            myObjectNameLabel.InternalDraw();

            mySaveButton.InternalDraw();
            myInputField.InternalDraw();

            mySpriteRendererLabel.InternalDraw();
            mySpriteName.InternalDraw();
            mySpriteRendererButton.InternalDraw();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void Save()
        {
            if (myInputField.GetText() == "")
                return;

            myEditedEntity.SetName(myInputField.GetText());

            if (mySpriteRendererComponent != null)
                mySpriteRendererComponent.myTexturePath = mySpriteName.GetText();

            Resources.SaveEntity(myEditedEntity);

            Debug.Log("Saved the entity " + myInputField.GetText());
        }

        public void AddSpriteRendererComponent()
        {
            mySpriteRendererComponent = myEditedEntity.AddComponent(new SpriteRendererComponent("test")) as SpriteRendererComponent;
            mySpriteRendererButton.myIsActive = false;
            mySpriteName.myIsActive = true;
            mySpriteRendererLabel.myIsActive = true;
        }
    }
}
