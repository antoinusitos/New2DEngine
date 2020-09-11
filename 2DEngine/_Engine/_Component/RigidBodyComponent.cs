using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class RigidBodyComponent : Component
    {
        public bool myUseGravity = true;

        private Vector2 myVelocity = Vector2.Zero;

        public void AddVelocity(Vector2 aDirection)
        {
            myVelocity += aDirection;
        }

        public Vector2 GetVelocity()
        {
            return myVelocity;
        }

        public override void Update()
        {
            if(myUseGravity)
            {
                AddVelocity(Renderer.myGravityVector);
            }
        }

        public void SetVelocity(Vector2 aVelocity)
        {
            myVelocity = aVelocity;
        }

        public void SetVelocity(float aX, float aY)
        {
            myVelocity.X = aX;
            myVelocity.Y = aY;
        }
    }
}
