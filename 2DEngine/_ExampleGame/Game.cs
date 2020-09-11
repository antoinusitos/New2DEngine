using _2DEngine._Engine;
using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._ExampleGame
{
    class Game : EngineWindow
    {
        private Entity e;
        private Entity e2;
        private TransformComponent transformComponent;
        private RigidBodyComponent rigidbodyComponent;
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

            e = Entities.GetInstance().CreateEntity("player");
            e.AddComponent(new SpriteRendererComponent("Textures/player"));
            rigidbodyComponent = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;
            rigidbodyComponent.myUseGravity = true;
            e.AddComponent(new CollisionComponent());
            transformComponent = e.GetComponent<TransformComponent>() as TransformComponent;
            TransformComponent tc1 = e.GetComponent<TransformComponent>() as TransformComponent;
            tc1.myPosition = new Vector2(0, 500);

            e2 = Entities.GetInstance().CreateEntity("terrain");
            e2.AddComponent(new SpriteRendererComponent("Textures/test"));
            e2.AddComponent(new CollisionComponent());
            TransformComponent tc = e2.GetComponent<TransformComponent>() as TransformComponent;
            tc.myPosition = new Vector2(0, 550);
        }

        public override void Update()
        {
            if (Input.myKeyboardState.IsKeyDown(Keys.Right))
            {
                rigidbodyComponent.AddVelocity(Vector2.UnitX);
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Left))
            {
                rigidbodyComponent.AddVelocity(-Vector2.UnitX);
            }

            if (Input.myKeyboardState.IsKeyDown(Keys.Up))
            {
                rigidbodyComponent.AddVelocity(-Vector2.UnitY * 3);
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Down))
            {
                //transformComponent.myPosition.Y += speed * Time.myDeltaTime;
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
