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
            mySpriteRendererComponent.SetTexturePath("InputField");
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
                int keyValue = (int)keys[i];
                if (keyValue >= 65 && keyValue <= 90)
                {
                    if (!Input.GetKeyPress(Keys.LeftShift))
                        keyValue += 32;
                    if(Input.GetKeyPressed(keys[i]))
                        myText += (char)keyValue;
                }

                if (myText.Length > 0 && !Utils.ContainsKey(myLastPressedKeys, keys[i]) && keyValue == (int)Keys.Back)
                    myText = myText.Remove(myText.Length - 1, 1);

                if (!Utils.ContainsKey(myLastPressedKeys, keys[i]) && keyValue == (int)Keys.Space)
                    myText += ' ';
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
            base.Draw();

            if (myText != "")
                myShowName = false;
            else
                myShowName = true;

            Renderer.mySpriteBatch.DrawString(Renderer.myFont, myText, myTransformComponent.myPosition, Color.Black);
        }

        public string GetText()
        {
            return myText;
        }
    }
}
