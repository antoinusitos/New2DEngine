using System.Collections.Generic;

namespace _2DEngine._Engine
{
    class Scene
    {
        private List<Entity> myEntities = null;

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
    }
}
