using _2DEngine._Engine._Component;
using _2DEngine._ExampleGame;
using _2DEngine._ExampleGame._Component;
using System;
using System.Collections.Generic;
using System.IO;

namespace _2DEngine._Engine
{
    static class Resources
    {
        private const string myPrefabSavePath = "/Content/Prefabs/";
        private const string mySceneSavePath = "/Content/Scenes/";
        private const string myComponentsSavePath = "/Content/Components/";
        private const string myEngineComponentsSavePath = "/_Engine/_Component/";
        private const string myCustomComponentsSavePath = "/_ExampleGame/_Component/";
        private const string myTemplatesSavePath = "/Templates/";

        private static Dictionary<string, Entity> myEntities = null;
        private static Dictionary<string, Component> myComponent = null;

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

        /*public static void LoadComponents()
        {
            if (myComponent == null)
                myComponent = new Dictionary<string, Component>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + myComponentsSavePath;
            if (Directory.Exists(fullPath))
            {
                string[] fileEntries = Directory.GetFiles(fullPath);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    LoadComponent(fileEntries[i]);
                }
                Debug.Log("All Components are loaded !");
            }
            else
            {
                Debug.Log(fullPath + " is not a valid file or directory.");
            }

            fullPath = projectDirectory + myEngineComponentsSavePath;
            if (Directory.Exists(fullPath))
            {
                string[] fileEntries = Directory.GetFiles(fullPath);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    string[] args = fileEntries[i].Split('/');
                    string name = args[args.Length - 1].Split('.')[0];

                    if(!myComponent.ContainsKey(name))
                    {
                        Type type = Type.GetType("_2DEngine._Engine._Component." + name);
                        Component obj = (Component)Activator.CreateInstance(type);
                        obj.myID = Entities.GetInstance().GetComponentsID();
                        SaveComponent(obj);
                    }
                }
            }

            fullPath = projectDirectory + myCustomComponentsSavePath;
            if (Directory.Exists(fullPath))
            {
                string[] fileEntries = Directory.GetFiles(fullPath);
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    string[] args = fileEntries[i].Split('/');
                    string name = args[args.Length - 1].Split('.')[0];

                    if (!myComponent.ContainsKey(name))
                    {
                        Type type = Type.GetType("_2DEngine._ExampleGame._Component." + name);
                        Component obj = (Component)Activator.CreateInstance(type);
                        obj.myID = Entities.GetInstance().GetComponentsID();
                        SaveComponent(obj);
                    }
                }
            }
        }*/

        /*private static void LoadComponent(string aPath)
        {
            string line;

            string[] name = aPath.Split('/');
            string componentName = name[name.Length - 1].Split('.')[0];

            Type type = Type.GetType("_2DEngine._Engine._Component."+componentName);
            Component obj = (Component)Activator.CreateInstance(type);

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
                if (args[0] == "ID")
                {
                    obj.myID = uint.Parse(args[1]);
                    Entities.GetInstance().SetMaxComponentID(obj.myID);
                }
                else if(args[0] == "COMPONENT")
                {
                    obj.myName = args[1];
                }
                else
                {
                    obj.ReadArg(lines[i]);
                }
            }

            myComponent.Add(obj.myName, obj);

            file.Close();
        }*/

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
                    //TODO : continue with generic init
                    //Type type = Type.GetType("_2DEngine._Engine._Component." + componentName);
                    //Component obj = (Component)Activator.CreateInstance(type);
                    //obj.init, etc..

                    if (args[1] == "Transform")
                    {
                        TransformComponent tc = e.GetComponent<TransformComponent>() as TransformComponent;
                        tc.Initialize(e);
                        int l = 1;
                        while (lines[i + l].Split(':')[0] != "COMPONENT")
                        {
                            tc.ReadArg(lines[i + l]);
                            l++;
                        }
                        i += l - 1;
                    }
                    else if (args[1] == "SpriteRenderer")
                    {
                        SpriteRendererComponent sr = e.AddComponent(new SpriteRendererComponent("test")) as SpriteRendererComponent;
                        sr.Initialize(e);
                        int l = 1;
                        while (lines[i + l].Split(':')[0] != "COMPONENT")
                        {
                            sr.ReadArg(lines[i + l]);
                            l++;
                        }
                        sr.LoadContent();
                        i += l - 1;
                    }
                    else if (args[1] == "Collision")
                    {
                        CollisionComponent cc = e.AddComponent(new CollisionComponent()) as CollisionComponent;
                        cc.Initialize(e);
                        cc.myIsTrigger = bool.Parse(lines[i + 1].Split(':')[1]);
                        i += 1;
                    }
                    else if (args[1] == "RigidBody")
                    {
                        RigidBodyComponent rc = e.AddComponent(new RigidBodyComponent()) as RigidBodyComponent;
                        rc.Initialize(e);
                    }
                    else if (args[1] == "TriggerTest")
                    {
                        TriggerTest tt = e.AddComponent(new TriggerTest()) as TriggerTest;
                        tt.Initialize(e);
                    }
                    else if (args[1] == "MovePlayer")
                    {
                        MovePlayer mp = e.AddComponent(new MovePlayer()) as MovePlayer;
                        mp.Initialize(e);
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

        /*public static void CreateComponent(string aName, bool aInEngine)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = "";
            if(aInEngine)
                fullPath = projectDirectory + myEngineComponentsSavePath + aName + ".cs";
            else
                fullPath = projectDirectory + myCustomComponentsSavePath + aName + ".cs";
            File.Create(fullPath).Close();

            string templatesPath = projectDirectory + myTemplatesSavePath;
            if (aInEngine)
            {
                templatesPath += "EngineComponent.txt";
            }
            else
            {
                templatesPath += "GameComponent.txt";
            }

            string line;
            StreamReader fileToRead = new StreamReader(templatesPath);
            string text = "";
            while ((line = fileToRead.ReadLine()) != null)
            {
                text += line + "\n";
            }

            text = text.Replace("[TOREPLACE]", aName);

            StreamWriter file = new StreamWriter(fullPath);
            file.Write(text);
            file.Flush();
            file.Close();
        }*/

        /*public static void SaveComponent(Component aComponent)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + myComponentsSavePath + aComponent.myName + ".json";
            StreamWriter file = new StreamWriter(fullPath);
            file.Write(aComponent.Save());
            Debug.Log("Saved :" + fullPath);
            file.Flush();
            file.Close();
        }*/
    }
}
