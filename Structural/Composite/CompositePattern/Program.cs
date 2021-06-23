using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CompositePattern
{
    class Program
    {

        abstract class Component
        {
            abstract public void AddChild(Component c);
            abstract public void Traverse();
        }
        class File : Component
        {
            private string value = string.Empty;

            public File(string val)
            {
                value = val;
            }

            public override void AddChild(Component c){ }
            public override void Traverse()
            {
                Debug.WriteLine("File: " + value);
            }
        }

        class Folder : Component
        {
            private string value = string.Empty;
            private List<Component> ComponentList = new List<Component>();

            public Folder(string val)
            {
                value = val;
            }

            public override void AddChild(Component c)
            {
                ComponentList.Add(c);
            }

            public override void Traverse()
            {
                Debug.WriteLine("Folder: " + value);
                foreach(Component c in ComponentList)
                {
                    c.Traverse();
                }
            }
        }
        static void Main(string[] args)
        {
            Folder folder1 = new Folder("Folder 1 information");
            Folder folder2 = new Folder("Folder 2 information");

            File file1 = new File("File 1 information");
            File file2 = new File("File 2 information");

            folder2.AddChild(file1);
            folder2.AddChild(file2);
            File file3 = new File("File 3 information");
            folder1.AddChild(folder2);
            folder1.AddChild(file3);
            folder1.Traverse();
        }


    }
}
