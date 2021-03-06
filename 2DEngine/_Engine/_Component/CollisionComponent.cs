﻿using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class CollisionComponent : Component
    {
        private RigidBodyComponent myRigidBodyComponent = null;

        private TransformComponent myTransformComponent = null;

        private SpriteRendererComponent mySpriteRendererComponent = null;

        public Vector2 myPosition = Vector2.Zero;
        public Vector2 mySize = Vector2.One * 256;

        public bool myIsTrigger = false;

        public delegate void OnTriggerEvent(CollisionComponent aCollider);
        public OnTriggerEvent myOnTriggerEnter = null;
        public OnTriggerEvent myOnTriggerExit = null;

        public CollisionComponent()
        {
            myName = "CollisionComponent";
        }

        public override void Initialize(Entity anEntity)
        {
            base.Initialize(anEntity);

            Entities.GetInstance().AddCollisionComponent(this);

            myRigidBodyComponent = anEntity.GetComponent<RigidBodyComponent>() as RigidBodyComponent;
            myTransformComponent = anEntity.GetComponent<TransformComponent>() as TransformComponent;
            mySpriteRendererComponent = anEntity.GetComponent<SpriteRendererComponent>() as SpriteRendererComponent;
        }

        public override void Update()
        {
            if (myRigidBodyComponent == null)
                return;

            if (mySpriteRendererComponent != null)
                mySize = new Vector2(mySpriteRendererComponent.GetTexture().Width, mySpriteRendererComponent.GetTexture().Height);

            CollisionComponent[] collisions = Entities.GetInstance().GetCollisions();

            for(int i = 0; i < collisions.Length; i++)
            {
                if (collisions[i] == this)
                    continue;

                if( myRigidBodyComponent.GetVelocity().X > 0 && IsTouchingLeft(collisions[i]) ||
                    myRigidBodyComponent.GetVelocity().X < 0 && IsTouchingRight(collisions[i])
                    )
                {
                    if(collisions[i].myIsTrigger)
                    {
                        collisions[i].OnTriggerEnter(this);
                    }
                    else
                    {
                        myRigidBodyComponent.SetVelocity(0, myRigidBodyComponent.GetVelocity().Y);
                    }
                }

                if (myRigidBodyComponent.GetVelocity().Y > 0 && IsTouchingTop(collisions[i]) ||
                    myRigidBodyComponent.GetVelocity().Y < 0 && IsTouchingBottom(collisions[i])
                    )
                {
                    if (collisions[i].myIsTrigger)
                    {
                        collisions[i].OnTriggerEnter(this);
                    }
                    else
                    {
                        myRigidBodyComponent.SetVelocity(myRigidBodyComponent.GetVelocity().X, 0);
                    }
                }
            }

            myTransformComponent.myPosition += myRigidBodyComponent.GetVelocity();
            myRigidBodyComponent.SetVelocity(Vector2.Zero);
        }

        public void OnTriggerEnter(CollisionComponent aCollider)
        {
            myOnTriggerEnter?.Invoke(aCollider);
        }

        private bool IsTouchingLeft(CollisionComponent aCollisionComponent)
        {
            float localRight = myTransformComponent.myPosition.X + mySize.X;
            float localLeft = myTransformComponent.myPosition.X;
            float localBottom = myTransformComponent.myPosition.Y + mySize.Y;
            float localTop = myTransformComponent.myPosition.Y;

            float itsLeft = aCollisionComponent.myTransformComponent.myPosition.X;
            float itsTop = aCollisionComponent.myTransformComponent.myPosition.Y;
            float itsBottom = aCollisionComponent.myTransformComponent.myPosition.Y + aCollisionComponent.mySize.Y;

            return localRight + myRigidBodyComponent.GetVelocity().X > itsLeft &&
                    localLeft < itsLeft &&
                    localBottom > itsTop &&
                    localTop < itsBottom;
        }

        private bool IsTouchingRight(CollisionComponent aCollisionComponent)
        {
            float localRight = myTransformComponent.myPosition.X + mySize.X;
            float localLeft = myTransformComponent.myPosition.X;
            float localBottom = myTransformComponent.myPosition.Y + mySize.Y;
            float localTop = myTransformComponent.myPosition.Y;

            //float itsLeft = aCollisionComponent.myTransformComponent.myPosition.X;
            float itsRight = aCollisionComponent.myTransformComponent.myPosition.X + aCollisionComponent.mySize.X;
            float itsTop = aCollisionComponent.myTransformComponent.myPosition.Y;
            float itsBottom = aCollisionComponent.myTransformComponent.myPosition.Y + aCollisionComponent.mySize.Y;

            return localLeft + myRigidBodyComponent.GetVelocity().X < itsRight &&
                    localRight > itsRight &&
                    localBottom > itsTop &&
                    localTop < itsBottom;
        }

        private bool IsTouchingTop(CollisionComponent aCollisionComponent)
        {
            float localRight = myTransformComponent.myPosition.X + mySize.X;
            float localLeft = myTransformComponent.myPosition.X;
            float localBottom = myTransformComponent.myPosition.Y + mySize.Y;
            float localTop = myTransformComponent.myPosition.Y;

            float itsLeft = aCollisionComponent.myTransformComponent.myPosition.X;
            float itsRight = aCollisionComponent.myTransformComponent.myPosition.X + aCollisionComponent.mySize.X;
            float itsTop = aCollisionComponent.myTransformComponent.myPosition.Y;
            //float itsBottom = aCollisionComponent.myTransformComponent.myPosition.Y + aCollisionComponent.mySize.Y;

            return localBottom + myRigidBodyComponent.GetVelocity().Y > itsTop &&
                    localTop < itsTop &&
                    localRight > itsLeft &&
                    localLeft < itsRight;
        }

        private bool IsTouchingBottom(CollisionComponent aCollisionComponent)
        {
            float localRight = myTransformComponent.myPosition.X + mySize.X;
            float localLeft = myTransformComponent.myPosition.X;
            float localBottom = myTransformComponent.myPosition.Y + mySize.Y;
            float localTop = myTransformComponent.myPosition.Y;

            float itsLeft = aCollisionComponent.myTransformComponent.myPosition.X;
            float itsRight = aCollisionComponent.myTransformComponent.myPosition.X + aCollisionComponent.mySize.X;
            //float itsTop = aCollisionComponent.myTransformComponent.myPosition.Y;
            float itsBottom = aCollisionComponent.myTransformComponent.myPosition.Y + aCollisionComponent.mySize.Y;

            return localTop + myRigidBodyComponent.GetVelocity().Y < itsBottom &&
                    localBottom > itsBottom &&
                    localRight > itsLeft &&
                    localLeft < itsRight;
        }

        public override string Save()
        {
            string text = "COMPONENT:CollisionComponent\n";
            text += "ID:" + myID + "\n";
            text += "TRIGGER:" + myIsTrigger;
            text += "POSITIONX:" + myPosition.X.ToString() + "\n";
            text += "POSITIONY:" + myPosition.Y.ToString() + "\n";
            return text;
        }

        public override void Load(string aLine)
        {
        }
    }
}
