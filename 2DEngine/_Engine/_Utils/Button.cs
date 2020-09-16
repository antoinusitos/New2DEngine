using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._Engine._Utils
{
    class Button : Entity
    {
        protected SpriteRendererComponent mySpriteRendererComponent = null;
        protected TransformComponent myTransformComponent = null;
        protected ButtonState myLastMouseState = ButtonState.Released;
        protected bool myIsHover = false;
        protected bool myCanReceiveInputs = false;

        public delegate void OnClickDelegate();
        public OnClickDelegate myOnClickDelegate = null;
        public OnClickDelegate myOnUnClickDelegate = null;

        protected bool myShowName = true;

        public Button(string aName) : base(aName)
        {
            mySpriteRendererComponent = new SpriteRendererComponent("Button");
        }

        public override void Initialize()
        {
            base.Initialize();

            myTransformComponent = GetComponent<TransformComponent>() as TransformComponent;
            myComponents.Add(mySpriteRendererComponent);
            mySpriteRendererComponent.Initialize(this);
        }

        public void LoadContent()
        {
            mySpriteRendererComponent.LoadContent();
        }

        public bool EnterButton()
        {
            if (Input.myMouseState.X < myTransformComponent.myPosition.X + mySpriteRendererComponent.GetTexture().Width &&
                    Input.myMouseState.X > myTransformComponent.myPosition.X &&
                    Input.myMouseState.Y < myTransformComponent.myPosition.Y + mySpriteRendererComponent.GetTexture().Height &&
                    Input.myMouseState.Y > myTransformComponent.myPosition.Y)
            {
                return true;
            }
            return false;
        }

        public override void Update()
        {
            if (!myIsActive)
                return;

            base.Update();

            if (EnterButton())
            {
                myIsHover = true;
                mySpriteRendererComponent.myColor = Color.Gray;
                if (Input.myMouseState.LeftButton == ButtonState.Pressed && myLastMouseState == ButtonState.Released)
                {
                    OnClick();
                }
            }
            else
            {
                myIsHover = false;
                mySpriteRendererComponent.myColor = Color.White;
                if (Input.myMouseState.LeftButton == ButtonState.Pressed && myLastMouseState == ButtonState.Released)
                {
                    OnUnClick();
                }
            }

            myLastMouseState = Input.myMouseState.LeftButton;
        }

        public override void Draw()
        {
            if (!myIsActive)
                return;

            base.Draw();

            if(myShowName)
                Renderer.mySpriteBatch.DrawString(Renderer.myFont, myName, myTransformComponent.myPosition, Color.Black);
        }

        protected virtual void OnClick()
        {
            myOnClickDelegate?.Invoke();
        }

        protected virtual void OnUnClick()
        {
            myOnUnClickDelegate?.Invoke();
        }
    }
}
