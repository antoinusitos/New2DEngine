using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine._Utils
{
    class InputField : Button
    {
        private Keys[] myLastPressedKeys = null;
        private string myText = "";

        public InputField(string aName) : base (aName)
        {
            myLastPressedKeys = new Keys[0];
            mySpriteRendererComponent.SetTexturePath("Textures/InputField");
        }

        public override void Update()
        {
            base.Update();
            
            if (!myCanReceiveInputs)
            {
                mySpriteRendererComponent.myColor = Color.White;
                return;
            }

            mySpriteRendererComponent.myColor = Color.DarkGreen;

            if (Input.myKeyboardState.IsKeyDown(Keys.Enter))
            {
                myCanReceiveInputs = false;
                return;
            }

            Keys[] keys = Input.myKeyboardState.GetPressedKeys();

            for (int i = 0; i < keys.Length; i++)
            {
                if (!Utils.ContainsKey(myLastPressedKeys, keys[i]) && (int)keys[i] >= 65 && (int)keys[i] <= 90)
                    myText += keys[i];
            }

            myLastPressedKeys = keys;
        }

        protected override void OnClick()
        {
            base.OnClick();
            myCanReceiveInputs = true;
        }

        protected override void OnUnClick()
        {
            base.OnUnClick();
            myCanReceiveInputs = false;
        }

        public override void Draw()
        {
            Renderer.mySpriteBatch.DrawString(Renderer.myFont, myText, myTransformComponent.myPosition, Color.Black);
        }
    }
}
