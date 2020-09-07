using System.Collections.Generic;

namespace _2DEngine.Engine
{
    class Pool
    {
        private List<Entity> myEntitiesPooled = null;
        private const int myEntitiesCountToPool = 20;

        public void Initialize()
        {
            myEntitiesPooled = new List<Entity>();
            for(int i = 0; i < myEntitiesCountToPool; i++)
            {
                myEntitiesPooled.Add(new Entity());
            }
        }
    }   
}
