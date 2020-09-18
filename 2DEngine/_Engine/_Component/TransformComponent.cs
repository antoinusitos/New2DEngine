using Microsoft.Xna.Framework;

namespace _2DEngine._Engine._Component
{
    class TransformComponent : Component
    {
        public Vector2 myPosition = Vector2.Zero;
        public float myRotation = 0;
        public Vector2 myScale = Vector2.One;

        public TransformComponent()
        {
            myName = "TransformComponent";
        }

        public override string Save()
        {
            string text = "COMPONENT:TransformComponent\n";
            text += "ID:" + myID + "\n";
            text += "POSITIONX:" + myPosition.X.ToString() + "\n";
            text += "POSITIONY:" + myPosition.Y.ToString() + "\n";
            text += "ROTATION:" + myRotation.ToString() + "\n";
            text += "SCALEX:" + myScale.X.ToString() + "\n";
            text += "SCALEY:" + myScale.Y.ToString();

            return text;
        }

        public override void Load(string aLine)
        {
        }

        public override void ReadArg(string aLine)
        {
            string[] args = aLine.Split(':');
            if(args[0] == "POSITIONX")
                myPosition.X = float.Parse(args[1]);
            else if (args[0] == "POSITIONY")
                myPosition.Y = float.Parse(args[1]);
            else if (args[0] == "ROTATION")
                myRotation = float.Parse(args[1]);
            else if (args[0] == "SCALEX")
                myScale.X = float.Parse(args[1]);
            else if (args[0] == "SCALEY")
                myScale.Y = float.Parse(args[1]);
        }
    }
}
