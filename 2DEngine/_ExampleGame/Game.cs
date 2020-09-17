﻿using _2DEngine._Engine;
using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._ExampleGame
{
    class Game : EngineWindow
    {
        private Entity e;
        private Entity e2;
        private Entity e3;
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
            e.AddComponent(new SpriteRendererComponent("player"));
            rigidbodyComponent = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;
            rigidbodyComponent.myUseGravity = true;
            e.AddComponent(new CollisionComponent());
            ((TransformComponent)e.GetComponent<TransformComponent>()).myPosition = new Vector2(0, 500);

            e2 = Entities.GetInstance().CreateEntity("terrain");
            e2.AddComponent(new SpriteRendererComponent("test"));
            e2.AddComponent(new CollisionComponent());
            ((TransformComponent)e2.GetComponent<TransformComponent>()).myPosition = new Vector2(0, 550);

            e3 = Entities.GetInstance().CreateEntity("trigger");
            SpriteRendererComponent src = new SpriteRendererComponent("test")
            {
                myColor = Color.Yellow
            };
            e3.AddComponent(src);
            CollisionComponent cc = new CollisionComponent
            {
                myIsTrigger = true,
                myOnTriggerEnter = OnTriggerEntered
            };
            e3.AddComponent(cc);
            ((TransformComponent)e3.GetComponent<TransformComponent>()).myPosition = new Vector2(100, 450);

            Resources.SaveEntity(e);
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
                e.Destroy();
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

        public void OnTriggerEntered(CollisionComponent cc)
        {
            if(cc.GetOwner().GetName() == "player")
            {
                cc.GetOwner().Destroy();
            }
        }
    }
}
