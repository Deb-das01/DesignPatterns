using System;
using System.Collections.Generic;

namespace PrototypePattern
{
    public interface IHeroPrototype
    {
        IHeroPrototype Clone();
        void Display();
    }

    public class Hero : IHeroPrototype
    {
        private int health;
        private string name;
        private List<string> weapons;

        public Hero(int h, string n, List<string> wep)
        {
            health = h;
            name = n;
            weapons = wep;
        }

        public IHeroPrototype Clone()
        {
            // Deep copy of the weapon list
            return new Hero(health, name, new List<string>(weapons));
        }

        public void Display()
        {
            Console.WriteLine($"Hello, myself {name} with health {health}");
            Console.WriteLine("Weapons:");

            foreach (string item in weapons)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            List<string> w = new List<string>();

            w.Add("Gun");
            w.Add("Stick");

            IHeroPrototype h1 = new Hero(50, "Alice", w);

            Console.WriteLine("Original Hero");
            h1.Display();

            IHeroPrototype h2 = h1.Clone();

            Console.WriteLine("Cloned Hero");
            h2.Display();
        }
    }
}