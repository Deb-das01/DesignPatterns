using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public interface Icommand
    {
        void execute();
        void undo();
    }

    // Receivers
    public class Fan
    {
        public void FanOn() => Console.WriteLine("Switching on the Fan");
        public void FanOff() => Console.WriteLine("Switching off the Fan");
    }

    public class Light
    {
        public void LightOn() => Console.WriteLine("Switching the Light On");
        public void LightOff() => Console.WriteLine("Switching the Light Off");
    }

    // Commands
    public class FanSwitchOn : Icommand
    {
        Fan _fan;
        public FanSwitchOn(Fan fan) => _fan = fan;

        public void execute() => _fan.FanOn();
        public void undo() => _fan.FanOff();
    }

    public class FanSwitchOff : Icommand
    {
        Fan _fan;
        public FanSwitchOff(Fan fan) => _fan = fan;

        public void execute() => _fan.FanOff();
        public void undo() => _fan.FanOn();
    }

    public class LightSwitchOn : Icommand
    {
        Light _light;
        public LightSwitchOn(Light light) => _light = light;

        public void execute() => _light.LightOn();
        public void undo() => _light.LightOff();
    }

    public class LightSwitchOff : Icommand
    {
        Light _light;
        public LightSwitchOff(Light light) => _light = light;

        public void execute() => _light.LightOff();
        public void undo() => _light.LightOn();
    }

    // Invoker
    public class Remote
    {
        Dictionary<int, Tuple<Icommand, Icommand>> dict;
        Icommand lastCommand;

        public Remote(Dictionary<int, Tuple<Icommand, Icommand>> commands)
        {
            dict = commands;
        }

        public void pressOnbutton(int btn)
        {
            dict[btn].Item1.execute();
            lastCommand = dict[btn].Item1;
        }

        public void pressOffbutton(int btn)
        {
            dict[btn].Item2.execute();
            lastCommand = dict[btn].Item2;
        }

        public void undoChange()
        {
            if (lastCommand != null)
                lastCommand.undo();
        }
    }

    // Client
    public class Program
    {
        public static void Main()
        {
            Light light = new Light();
            Fan fan = new Fan();

            var commands = new Dictionary<int, Tuple<Icommand, Icommand>>()
            {
                {1, Tuple.Create<Icommand, Icommand>(
                    new LightSwitchOn(light),
                    new LightSwitchOff(light)
                )},
                {2, Tuple.Create<Icommand, Icommand>(
                    new FanSwitchOn(fan),
                    new FanSwitchOff(fan)
                )}
            };

            Remote remote = new Remote(commands);

            remote.pressOnbutton(1);
            remote.pressOffbutton(1);
            remote.undoChange();
        }
    }
}