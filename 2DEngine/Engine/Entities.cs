using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2DEngine.Engine
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
        private bool myInit = false;

        public void Initialize()
        {
            myEntities = new List<Entity>();
            myInit = true;
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
    }
}
