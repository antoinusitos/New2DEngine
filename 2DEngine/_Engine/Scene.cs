using System.Collections.Generic;

namespace _2DEngine._Engine
{
    class Scene
    {
        private List<Entity> myEntities = null;
        private string myName = "";

        public void Initialize()
        {
            myEntities = new List<Entity>();
        }

        //Draw serialized entities
        public void InternalDraw()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalDraw();
            }
        }

        //Update serialized entities
        public void InternalUpdate()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalUpdate();
            }
        }

        public void Awake()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].Awake();
            }
        }

        public void Start()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].Start();
            }
        }

        public void AddEntity(Entity anEntity, bool aWithInit = true)
        {
            myEntities.Add(anEntity);
            if(aWithInit)
                anEntity.Initialize();
        }

        public void DestroyEntity(Entity anEntity)
        {
            //TODO: deal with the pooler
            anEntity.myIsActive = false;
            myEntities.Remove(anEntity);
        }

        public void CleanEntities()
        {
            myEntities.Clear();
        }

        public Entity[] GetEntities()
        {
            return myEntities.ToArray();
        }

        public void SetName(string aName)
        {
            myName = aName;
        }

        public string GetName()
        {
            return myName;
        }
    }
}
