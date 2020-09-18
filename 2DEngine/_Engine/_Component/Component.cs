namespace _2DEngine._Engine._Component
{
    class Component
    {
        //TIPS : if ID == 0, components is new
        public uint myID = 0;
        public string myName = "";
        
        protected Entity myOwnerEntity = null;
        protected bool myIsModified = false;

        public Component()
        {
            myName = "Component";
        }

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
            string text = "COMPONENT:Component\n";
            text += "ID:" + myID + "\n";
            return text;
        }

        public virtual void Load(string aLine)
        {
        }

        public virtual void ReadArg(string aLine)
        {
        }

        public virtual void Awake()
        {
        }

        public virtual void Start()
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
