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
            string text = "COMPONENT:Transform\n";
            text += "POSITIONX:" + myPosition.X.ToString() + "\n";
            text += "POSITIONY:" + myPosition.Y.ToString() + "\n";
            text += "ROTATION:" + myRotation.ToString() + "\n";
            text += "SCALEX:" + myScale.X.ToString() + "\n";
            text += "SCALEY:" + myScale.Y.ToString();

            return text;
        }

        public override void Load()
        {
        }
    }
}
