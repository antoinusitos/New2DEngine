using System.Collections.Generic;
using _2DEngine._Engine._Component;

namespace _2DEngine._Engine
{
    class Entities
    {
        private static Entities myInstance = null;
        public static Entities GetInstance()
        {
            if (myInstance == null)
                myInstance = new Entities();

            return myInstance;
        }

        private List<Entity> myEntities = null;
        private List<CollisionComponent> myCollisions = null;
        private uint myEntitiesID = 0;
        private uint myComponentsID = 0;

        public void Initialize()
        {
            myEntities = new List<Entity>();
            myCollisions = new List<CollisionComponent>();
        }

        //Draw non serialized entities
        public void InternalDraw()
        {
            for(int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalDraw();
            }
        }

        //Update non serialized entities
        public void InternalUpdate()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalUpdate();
            }
        }

        public Entity CreateEntity(string aName)
        {
            //TODO: deal with the pooler
            Entity entity = new Entity(aName);
            myEntities.Add(entity);
            entity.myID = GetID();
            entity.Initialize();
            return entity;
        }

        public void AddEntity(Entity anEntity)
        {
            myEntities.Add(anEntity);
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

        public CollisionComponent[] GetCollisions()
        {
            return myCollisions.ToArray();
        }

        public void AddCollisionComponent(CollisionComponent aCollisionComponent)
        {
            if(!myCollisions.Contains(aCollisionComponent))
            {
                myCollisions.Add(aCollisionComponent);
            }
        }
        
        public uint GetID()
        {
            uint temp = myEntitiesID;
            myEntitiesID++;
            return temp;
        }

        public uint GetComponentsID()
        {
            uint temp = myComponentsID;
            myComponentsID++;
            return temp;
        }

        public void SetMaxComponentID(uint anID)
        {
            if (myComponentsID < anID)
                myComponentsID = anID;
        }
    }
}
