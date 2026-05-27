using System;

namespace DecoratorPattern
{
    public abstract class beverage
    {
        public abstract string getDescription();
        public abstract int cost();
    }

    public abstract class decorator : beverage
    {
        public beverage brv;
    }

    public class espresso : beverage
    {
        public override int cost()
        {
            return 5;
        }

        public override string getDescription()
        {
            return "espresso";
        }
    }

    public class darkRoast : beverage
    {
        public override int cost()
        {
            return 10;
        }

        public override string getDescription()
        {
            return "darkRoast";
        }
    }

    public class milk : decorator
    {
        public milk(beverage b)
        {
            brv = b;
        }

        public override int cost()
        {
            return brv.cost() + 2;
        }

        public override string getDescription()
        {
            return brv.getDescription() + "+Milk";
        }
    }

    public class mocha : decorator
    {
        public mocha(beverage b)
        {
            brv = b;
        }

        public override int cost()
        {
            return brv.cost() + 3;
        }

        public override string getDescription()
        {
            return brv.getDescription() + "+Mocha";
        }
    }

    public class program
    {
        public static void Main()
        {
            beverage _espresso = new espresso();
            _espresso = new milk(_espresso);

            Console.WriteLine("You have ordered: " +
                _espresso.getDescription() +
                ", COST: " + _espresso.cost());

            beverage _darkRoast = new darkRoast();
            _darkRoast = new milk(_darkRoast);
            _darkRoast = new mocha(_darkRoast);

            Console.WriteLine("You have ordered: " +
                _darkRoast.getDescription() +
                ", COST: " + _darkRoast.cost());
        }
    }
}