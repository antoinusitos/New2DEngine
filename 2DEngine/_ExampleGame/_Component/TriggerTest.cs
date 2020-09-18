using _2DEngine._Engine._Component;

namespace _2DEngine._ExampleGame._Component
{
    class TriggerTest : Component
    {
        private CollisionComponent myCollisionComponent = null;

        public override void Start()
        {
            myCollisionComponent = myOwnerEntity.GetComponent<CollisionComponent>() as CollisionComponent;
            myCollisionComponent.myOnTriggerEnter = OnTriggerEvent;
        }

        public void OnTriggerEvent(CollisionComponent aCollider)
        {
            if (aCollider.GetOwner().GetName() == "Player")
            {
                aCollider.GetOwner().Destroy();
            }
        }

        public override string Save()
        {
            return "COMPONENT:TriggerTest";
        }
    }
}
