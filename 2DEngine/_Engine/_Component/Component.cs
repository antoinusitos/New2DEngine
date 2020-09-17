namespace _2DEngine._Engine._Component
{
    class Component
    {
        protected Entity myOwnerEntity = null;
        protected bool myIsModified = false;

        public virtual void Initialize(Entity anEntity)
        {
            myOwnerEntity = anEntity;
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Draw()
        {
        }

        public virtual void Update()
        {
        }

        public virtual string Save()
        {
            return "COMPONENT:";
        }

        public virtual void Load()
        {
        }

        public bool GetIsModified()
        {
            return myIsModified;
        }

        public Entity GetOwner()
        {
            return myOwnerEntity;
        }
    }
}
