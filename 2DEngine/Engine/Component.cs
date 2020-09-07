using Microsoft.Xna.Framework.Graphics;

namespace _2DEngine.Engine
{
    class Component
    {
        protected Entity myOwnerEntity = null;

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
    }
}
