using _2DEngine._Engine._Component;
using System;
using System.IO;

namespace _2DEngine._Engine
{
    static class Resources
    {
        private const string mySavePath = "Content/Prefabs/";

        public static void SaveEntity(Entity anEntity)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fullPath = projectDirectory + "/Content/Prefabs/" + anEntity.GetName() + ".json";
            StreamWriter file = new StreamWriter(fullPath);
            file.WriteLine("NAME:" + anEntity.GetName());
            Component[] components = anEntity.GetComponents();
            for (int i = 0; i < components.Length; i++)
            {
                Debug.Log(components[i].Save());
                file.WriteLine(components[i].Save());
            }
            Debug.Log("Saved :" + fullPath);
            file.Flush();
            file.Close();
        }

        public static void LoadEntity()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(@"c:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
        }
    }
}
