using _2DEngine._Engine._Component;
using System;
using System.Collections.Generic;
using System.IO;

namespace _2DEngine._Engine
{
    static class Resources
    {
        private const string myPrefabSavePath = "/Content/Prefabs/";
        private const string mySceneSavePath = "/Content/Scenes/";

        private static Dictionary<string, Entity> myEntities = null;

        public static void SaveEntity(Entity anEntity)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + myPrefabSavePath + anEntity.GetName() + ".json";
            StreamWriter file = new StreamWriter(fullPath);
            file.Write(anEntity.GetEntitySerializationInfo());
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
            string fullPath = projectDirectory + myPrefabSavePath;
            if (Directory.Exists(fullPath))
            {
                string[] fileEntries = Directory.GetFiles(fullPath);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    LoadEntity(fileEntries[i]);
                }
                Debug.Log("All Prefabs are loaded !");
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
                    else if (args[1] == "Collision")
                    {
                        CollisionComponent cc = e.AddComponent(new CollisionComponent()) as CollisionComponent;
                    }
                    else if (args[1] == "RigidBody")
                    {
                        RigidBodyComponent rc = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;

                    }
                }
            }

            myEntities.Add(e.GetName(), e);

            file.Close();
        }

        private static Entity ReadEntity(string aName)
        {
            Entity e = new Entity(aName);

            return e;
        }

        public static void SaveScene(Scene aScene)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + mySceneSavePath + aScene.GetName() + ".json";
            StreamWriter file = new StreamWriter(fullPath);
            string toSave = "SCENENAME:" + aScene.GetName() + "\n";

            Entity[] entities = aScene.GetEntities();
            for(int i = 0; i < entities.Length; i++)
            {
                toSave += entities[i].GetEntitySerializationInfo();
            }

            file.Write(toSave);
            file.Flush();
            file.Close();

            Debug.Log("Saved :" + fullPath);
        }

        public static Scene LoadScene(string aName)
        {
            Scene scene = new Scene();
            scene.Initialize();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + mySceneSavePath + aName + ".json";

            StreamReader file = new StreamReader(fullPath);
            List<string> lines = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            Entity e = null;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] args = lines[i].Split(':');
                if (args[0] == "NAME")
                {
                    if(e != null)
                    {
                        scene.AddEntity(e, false);
                        e = null;
                    }
                    e = new Entity("");
                    e.Initialize();
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
                    else if (args[1] == "Collision")
                    {
                        CollisionComponent cc = e.AddComponent(new CollisionComponent()) as CollisionComponent;
                    }
                    else if (args[1] == "RigidBody")
                    {
                        RigidBodyComponent rc = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;

                    }
                }
            }

            if (e != null)
            {
                scene.AddEntity(e, false);
                e = null;
            }

            return scene;
        }

        public static Entity GetPrefab(string aName)
        {
            if(myEntities.ContainsKey(aName))
            {
                return myEntities[aName];
            }
            else
            {
                return null;
            }
        }
    }
}
