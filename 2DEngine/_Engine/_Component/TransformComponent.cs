using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class TransformComponent : Component
    {
        public Vector2 myPosition = Vector2.Zero;
        public float myRotation = 0;
        public Vector2 myScale = Vector2.One;

        public override string Save()
        {
            return "COMPONENT:Transform";
        }

        public override void Load()
        {
        }
    }
}
