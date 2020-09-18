using _2DEngine._Engine;
using _2DEngine._Engine._Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DEngine._ExampleGame
{
    class MovePlayer : Component
    {
        private RigidBodyComponent myRigidbodyComponent = null;
        private const float speed = 100;

        public override void Start()
        {
            myRigidbodyComponent = myOwnerEntity.GetComponent<RigidBodyComponent>() as RigidBodyComponent;
        }

        public override void Update()
        {
            if (Input.myKeyboardState.IsKeyDown(Keys.Right))
            {
                myRigidbodyComponent.AddVelocity(Vector2.UnitX * speed * Time.myDeltaTime);
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Left))
            {
                myRigidbodyComponent.AddVelocity(-Vector2.UnitX * speed * Time.myDeltaTime);
            }

            if (Input.myKeyboardState.IsKeyDown(Keys.Up))
            {
                myRigidbodyComponent.AddVelocity(-Vector2.UnitY * 3);
            }
            if (Input.myKeyboardState.IsKeyDown(Keys.Down))
            {
                //transformComponent.myPosition.Y += speed * Time.myDeltaTime;
            }

            if (Input.myKeyboardState.IsKeyDown(Keys.P))
            {
                myOwnerEntity.Destroy();
            }
        }

        public override string Save()
        {
            return "COMPONENT:MovePlayer";
        }
    }
}
