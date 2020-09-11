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

        protected Texture2D myPanelTop = null;

        public override void Initialize()
        {
            myWindowType = WindowType.GAME;
            myPanelTop = new Texture2D(Renderer.myGraphicsDevice, 1, 1);
            myPanelTop.SetData(new[] { Color.White });
        }

        public override void LoadContent()
        {

        }

        public override void Start()
        {
            base.Start();

            e = Entities.GetInstance().CreateEntity("e");
            e.AddComponent(new SpriteRendererComponent("Textures/test"));
            rigidbodyComponent = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;
            rigidbodyComponent.myUseGravity = false;
            e.AddComponent(new CollisionComponent());
            transformComponent = e.GetComponent<TransformComponent>() as TransformComponent;

            e2 = Entities.GetInstance().CreateEntity("e2");
            e2.AddComponent(new SpriteRendererComponent("Textures/test"));
            //RigidBodyComponent rb = e2.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;
            //rb.myUseGravity = false;
            e2.AddComponent(new CollisionComponent());

            TransformComponent tc = e2.GetComponent<TransformComponent>() as TransformComponent;
            tc.myPosition = new Vector2(500, 100);
        }

        public override void Update()
        {
            if (Input.myKeyboardState.IsKeyDown(Keys.Right))
            {
                rigidbodyComponent.AddVelocity(Vector2.UnitX);
                //transformComponent.myPosition.X += speed * Time.myDeltaTime;
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Left))
            {
                rigidbodyComponent.AddVelocity(-Vector2.UnitX);
                //transformComponent.myPosition.X -= speed * Time.myDeltaTime;
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
            Renderer.mySpriteBatch.Draw(myPanelTop, new Rectangle(0, 0, 256, 256), Color.Chocolate);
        }

        public override void Stop()
        {
            base.Stop();

            Entities.GetInstance().CleanEntities();
        }
    }
}
