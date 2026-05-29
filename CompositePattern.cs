using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public interface IFileSystemItem
    {
        void Display();
    }

    // LEAF
    public class File : IFileSystemItem
    {
        string _name;

        public File(string name)
        {
            _name = name;
        }

        public void Display()
        {
            Console.WriteLine("FILE: " + _name);
        }
    }

    // COMPOSITE
    public class Folder : IFileSystemItem
    {
        string _name;

        List<IFileSystemItem> lst =
            new List<IFileSystemItem>();

        public Folder(string name)
        {
            _name = name;
        }

        public void Add(IFileSystemItem item)
        {
            lst.Add(item);
        }

        public void Remove(IFileSystemItem item)
        {
            lst.Remove(item);
        }

        public void Display()
        {
            Console.WriteLine("FOLDER: " + _name);

            Console.WriteLine("Items under this folder:-");

            foreach (var item in lst)
            {
                item.Display();
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            IFileSystemItem file1 =
                new File("hello.txt");

            IFileSystemItem file2 =
                new File("Yello.txt");

            IFileSystemItem file3 =
                new File("Mallo.txt");

            IFileSystemItem file4 =
                new File("Fellow.txt");

            Folder Folder1 =
                new Folder("NEW_FOLDER1");

            Folder1.Add(file1);
            Folder1.Add(file2);

            Folder Folder2 =
                new Folder("NEW_FOLDER2");

            Folder2.Add(file3);
            Folder2.Add(file4);

            Folder1.Add(Folder2);

            Folder1.Display();
        }
    }
}