using System;
using System.Collections.Generic;

namespace IteratorPattern
{
    // Iterator Interface
    public interface IIterator
    {
        bool HasNext();
        string Next();
    }

    // Aggregate Interface
    public interface IResturant
    {
        void AddItem(string s);

        // Factory method for iterator
        IIterator CreateIterator();
    }

    // ================= ITERATORS =================

    // Iterator for List<string>
    public class ResturantAIterator : IIterator
    {
        private readonly List<string> _lst;
        private int _index = 0;

        public ResturantAIterator(List<string> lst)
        {
            _lst = lst;
        }

        public bool HasNext()
        {
            return _index < _lst.Count;
        }

        public string Next()
        {
            return _lst[_index++];
        }
    }

    // Iterator for string[]
    public class ResturantBIterator : IIterator
    {
        private readonly string[] _arr;
        private int _index = 0;

        public ResturantBIterator(string[] arr)
        {
            _arr = arr;
        }

        public bool HasNext()
        {
            // skip empty entries
            while (_index < _arr.Length && _arr[_index] == null)
            {
                _index++;
            }

            return _index < _arr.Length;
        }

        public string Next()
        {
            return _arr[_index++];
        }
    }

    // ================= COLLECTIONS =================

    // Uses List internally
    public class ResturantA : IResturant
    {
        private readonly List<string> _lst;

        public ResturantA()
        {
            _lst = new List<string>();
        }

        public void AddItem(string s)
        {
            _lst.Add(s);
        }

        public IIterator CreateIterator()
        {
            return new ResturantAIterator(_lst);
        }
    }

    // Uses array internally
    public class ResturantB : IResturant
    {
        private readonly string[] _arr;
        private int _ptr = 0;

        public ResturantB(int size)
        {
            _arr = new string[size];
        }

        public void AddItem(string s)
        {
            if (_ptr < _arr.Length)
            {
                _arr[_ptr++] = s;
            }
            else
            {
                Console.WriteLine("Restaurant is full");
            }
        }

        public IIterator CreateIterator()
        {
            return new ResturantBIterator(_arr);
        }
    }

    // ================= CLIENT =================

    public class Waiter
    {
        public void PrintMenu(IResturant resturant)
        {
            IIterator itr = resturant.CreateIterator();

            while (itr.HasNext())
            {
                Console.WriteLine(itr.Next());
            }
        }
    }

    // ================= MAIN =================

    class Program
    {
        static void Main(string[] args)
        {
            IResturant resturantA = new ResturantA();

            resturantA.AddItem("Pizza");
            resturantA.AddItem("Burger");
            resturantA.AddItem("Pasta");

            IResturant resturantB = new ResturantB(5);

            resturantB.AddItem("Biryani");
            resturantB.AddItem("Roll");
            resturantB.AddItem("Momo");

            Waiter waiter = new Waiter();

            Console.WriteLine("Restaurant A Menu:");
            waiter.PrintMenu(resturantA);

            Console.WriteLine();

            Console.WriteLine("Restaurant B Menu:");
            waiter.PrintMenu(resturantB);
        }
    }
}