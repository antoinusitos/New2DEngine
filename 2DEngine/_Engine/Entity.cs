using System.Collections.Generic;
using _2DEngine._Engine._Component;

namespace _2DEngine._Engine
{
    class Entity
    {
        public bool myIsActive = true;

        protected List<Component> myComponents = null;

        protected string myName = "";

        public Entity(string aName)
        {
            myName = aName;
        }

        public virtual void Initialize()
        {
            myComponents = new List<Component>
            {
                new TransformComponent()
            };
        }

        public virtual void InternalDraw()
        {
            if (!myIsActive)
                return;

            for (int i = 0; i < myComponents.Count; i++)
            {
                myComponents[i].Draw();
            }

            Draw();
        }

        public void InternalUpdate()
        {
            if (!myIsActive)
                return;

            for (int i = 0; i < myComponents.Count; i++)
            {
                myComponents[i].Update();
            }

            Update();
        }

        public virtual void Draw()
        {

        }

        public virtual void Update()
        {
            
        }

        public Component GetComponent<T>()
        {
            for (int i = 0; i < myComponents.Count; i++)
            {
                if (myComponents[i].GetType().IsEquivalentTo(typeof(T)))
                {
                    return myComponents[i];
                }
            }
            return null;
        }

        public Component AddComponent(Component aComponent)
        {
            aComponent.Initialize(this);
            aComponent.LoadContent();
            myComponents.Add(aComponent);
            return aComponent;
        }
    }
}
