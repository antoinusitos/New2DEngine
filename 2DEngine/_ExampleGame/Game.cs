using _2DEngine._Engine;
using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._ExampleGame
{
    class Game : EngineWindow
    {
        private Entity e;
        private TransformComponent transformComponent;
        private float speed = 100;

        public override void Initialize()
        {
            myWindowType = WindowType.GAME;
        }

        public override void LoadContent()
        {

        }

        public override void Start()
        {
            base.Start();

            e = Entities.GetInstance().CreateEntity();
            e.AddComponent(new SpriteRendererComponent("Textures/test"));
            transformComponent = e.GetComponent<TransformComponent>() as TransformComponent;
        }

        public override void Update()
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

            if (Input.myKeyboardState.IsKeyDown(Keys.P))
            {
                Entities.GetInstance().DestroyEntity(e);
            }
        }

        public override void Draw()
        {
        }

        public override void Stop()
        {
            base.Stop();

            Entities.GetInstance().CleanEntities();
        }
    }
}
