using _2DEngine.Engine;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine.ExampleGame
{
    class Game
    {
        private Entity e;
        private TransformComponent transformComponent;
        private float speed = 100;

        public virtual void Initialize()
        {
            e = Entities.GetInstance().CreateEntity();
            e.AddComponent(new SpriteRendererComponent("Textures/test"));
            transformComponent = e.GetComponent<TransformComponent>() as TransformComponent;
        }

        public virtual void LoadContent()
        {

        }

        public virtual void Update()
        {
            if (Input.myKeyboardState.IsKeyDown(Keys.Right))
            {
                transformComponent.myPosition.X += speed * Time.myDeltaTime;
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Left))
            {
                transformComponent.myPosition.X -= speed * Time.myDeltaTime;
            }

            if (Input.myKeyboardState.IsKeyDown(Keys.Up))
            {
                transformComponent.myPosition.Y -= speed * Time.myDeltaTime;
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Down))
            {
                transformComponent.myPosition.Y += speed * Time.myDeltaTime;
            }
        }

        public virtual void Draw()
        {

        }
    }
}
