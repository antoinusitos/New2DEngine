﻿using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class RigidBodyComponent : Component
    {
        public bool myUseGravity = true;

        private Vector2 myVelocity = Vector2.Zero;

        public RigidBodyComponent()
        {
            myName = "RigidBodyComponent";
        }

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

        public override string Save()
        {
            string text = "COMPONENT:RigidBodyComponent\n";
            text += "ID:" + myID + "\n";
            text += "GRAVITY:" + myUseGravity + "\n";
            text += "VELOCITYX:" + myVelocity.X + "\n";
            text += "VELOCITYY:" + myVelocity.Y;

            return text;
        }

        public override void Load(string aLine)
        {
        }
    }
}
