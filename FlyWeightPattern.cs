using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    // ==========================
    // Flyweight Interface
    // ==========================
    public interface ICharacter
    {
        void Draw(int x, int y);
    }

    // ==========================
    // Concrete Flyweight
    // Stores ONLY intrinsic state
    // ==========================
    public class Character : ICharacter
    {
        private char letter;
        private string color;
        private int fontSize;

        public Character(char letter, string color, int fontSize)
        {
            this.letter = letter;
            this.color = color;
            this.fontSize = fontSize;

            Console.WriteLine($"Creating Flyweight for '{letter}'");
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine(
                $"Drawing '{letter}' Color={color}, Size={fontSize} at ({x},{y})");
        }
    }

    // ==========================
    // Flyweight Factory
    // ==========================
    public class CharacterFactory
    {
        private Dictionary<string, ICharacter> characters =
            new Dictionary<string, ICharacter>();

        public ICharacter GetCharacter(char letter, string color, int fontSize)
        {
            string key = $"{letter}-{color}-{fontSize}";

            if (!characters.ContainsKey(key))
            {
                characters[key] = new Character(letter, color, fontSize);
            }

            return characters[key];
        }
    }

    // ==========================
    // Client
    // ==========================
    class Program
    {
        static void Main()
        {
            CharacterFactory factory = new CharacterFactory();

            ICharacter c1 = factory.GetCharacter('A', "Black", 12);
            c1.Draw(10, 20);

            ICharacter c2 = factory.GetCharacter('A', "Black", 12);
            c2.Draw(40, 80);

            ICharacter c3 = factory.GetCharacter('B', "Black", 12);
            c3.Draw(70, 100);

            ICharacter c4 = factory.GetCharacter('A', "Black", 12);
            c4.Draw(150, 200);
        }
    }
}