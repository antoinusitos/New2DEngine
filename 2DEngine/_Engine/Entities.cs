using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

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

        public void Initialize()
        {
            myEntities = new List<Entity>();
        }

        public void InternalDraw()
        {
            for(int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalDraw();
            }
        }

        public void InternalUpdate()
        {
            for (int i = 0; i < myEntities.Count; i++)
            {
                myEntities[i].InternalUpdate();
            }
        }

        public Entity CreateEntity()
        {
            //TODO: deal with the pooler
            Entity entity = new Entity();
            myEntities.Add(entity);
            entity.Initialize();
            return entity;
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
    }
}
