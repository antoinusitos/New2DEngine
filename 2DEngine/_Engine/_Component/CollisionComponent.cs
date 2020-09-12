using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class CollisionComponent : Component
    {
        private RigidBodyComponent myRigidBodyComponent = null;

        private TransformComponent myTransformComponent = null;

        private SpriteRendererComponent mySpriteRendererComponent = null;

        public Vector2 myPosition = Vector2.Zero;
        public Vector2 mySize = Vector2.One * 256;

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
                    myRigidBodyComponent.SetVelocity(0, myRigidBodyComponent.GetVelocity().Y);
                }

                if (myRigidBodyComponent.GetVelocity().Y > 0 && IsTouchingTop(collisions[i]) ||
                    myRigidBodyComponent.GetVelocity().Y < 0 && IsTouchingBottom(collisions[i])
                    )
                {
                    myRigidBodyComponent.SetVelocity(myRigidBodyComponent.GetVelocity().X, 0);
                }
            }

            myTransformComponent.myPosition += myRigidBodyComponent.GetVelocity();
            myRigidBodyComponent.SetVelocity(Vector2.Zero);
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
            return "COMPONENT:Collision";
        }

        public override void Load()
        {
        }
    }
}
