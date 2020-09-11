using _2DEngine._Engine._Component;
using _2DEngine._Engine._Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine._Tools
{
    class ObjectTool : Tool
    {
        private string myObjectName = "";
        private InputField myInputField = null;
        private Button mySaveButton = null;

        public override void Initialize()
        {
            base.Initialize();

            myToolName = "Object Tool";
            myWindowType = WindowType.OBJECT;

            myInputField = new InputField("Input Name");

            mySaveButton = new Button("Save");
        }

        public override void LoadContent()
        {
            base.LoadContent();

            mySaveButton.LoadContent();
            myInputField.LoadContent();
        }

        public override void Start()
        {
            base.Start();

            Entities.GetInstance().AddEntity(myInputField);
            Entities.GetInstance().AddEntity(mySaveButton);

            TransformComponent tc = myInputField.GetComponent<TransformComponent>() as TransformComponent;
            tc.myPosition = new Vector2((Renderer.myWindow_Width / 2) - 6 + 200, 50);

            tc = mySaveButton.GetComponent<TransformComponent>() as TransformComponent;
            tc.myPosition = new Vector2(500, 500);
        }

        public override void Update()
        {
            mySaveButton.Update();
            myInputField.Update();
        }


        public override void Draw()
        {
            base.Draw();

            Renderer.mySpriteBatch.DrawString(Renderer.myFont, "Object Name: " + myObjectName, new Vector2((Renderer.myWindow_Width / 2) - 6, 50), Color.Black);

            mySaveButton.Draw();
            myInputField.Draw();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
