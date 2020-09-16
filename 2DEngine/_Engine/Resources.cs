using _2DEngine._Engine._Component;
using System;
using System.Collections.Generic;
using System.IO;

namespace _2DEngine._Engine
{
    static class Resources
    {
        private const string mySavePath = "/Content/Prefabs/";

        private static Dictionary<string, Entity> myEntities = null;

        public static void SaveEntity(Entity anEntity)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + mySavePath + anEntity.GetName() + ".json";
            StreamWriter file = new StreamWriter(fullPath);
            file.WriteLine("NAME:" + anEntity.GetName());
            file.WriteLine("ID:" + anEntity.myID);
            file.WriteLine("ACTIVE:" + anEntity.myIsActive);
            file.WriteLine("DESTROYED:" + anEntity.GetIsDestroyed());
            Component[] components = anEntity.GetComponents();
            for (int i = 0; i < components.Length; i++)
            {
                file.WriteLine(components[i].Save());
            }
            Debug.Log("Saved :" + fullPath);
            file.Flush();
            file.Close();
        }

        public static void LoadEntities()
        {
            if (myEntities == null)
                myEntities = new Dictionary<string, Entity>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + mySavePath;
            if (Directory.Exists(fullPath))
            {
                string[] fileEntries = Directory.GetFiles(fullPath);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    LoadEntity(fileEntries[i]);
                }
            }
            else
            {
                Debug.Log(fullPath + " is not a valid file or directory.");
            }
        }
            

        private static void LoadEntity(string aPath)
        {
            string line;

            Entity e = new Entity("");
            e.Initialize();

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(aPath);
            List<string> lines = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                Debug.Log(lines[i]);
                string[] args = lines[i].Split(':');
                if (args[0] == "NAME")
                {
                    e.SetName(args[1]);
                }
                else if (args[0] == "ID")
                {
                    e.myID = uint.Parse(args[1]);
                }
                else if (args[0] == "COMPONENT")
                {
                    if (args[1] == "Transform")
                    {
                        TransformComponent tc = e.GetComponent<TransformComponent>() as TransformComponent;
                        tc.myPosition.X = float.Parse(lines[i + 1].Split(':')[1]);
                        tc.myPosition.Y = float.Parse(lines[i + 2].Split(':')[1]);
                        tc.myRotation = float.Parse(lines[i + 3].Split(':')[1]);
                        tc.myScale.X = float.Parse(lines[i + 4].Split(':')[1]);
                        tc.myScale.Y = float.Parse(lines[i + 5].Split(':')[1]);
                        i += 5;
                    }
                    else if (args[1] == "SpriteRenderer")
                    {
                        SpriteRendererComponent sr = e.AddComponent(new SpriteRendererComponent("test")) as SpriteRendererComponent;
                        sr.myTexturePath = lines[i + 1].Split(':')[1];
                        sr.myColor.R = byte.Parse(lines[i + 2].Split(':')[1]);
                        sr.myColor.G = byte.Parse(lines[i + 3].Split(':')[1]);
                        sr.myColor.B = byte.Parse(lines[i + 4].Split(':')[1]);
                        sr.myColor.A = byte.Parse(lines[i + 5].Split(':')[1]);
                        sr.LoadContent();
                        i += 5;
                    }
                    //e.myID = uint.Parse(args[1]);
                }
            }

            myEntities.Add(e.GetName(), e);

            file.Close();
        }
    }
}
