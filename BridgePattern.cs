using System;

namespace BridgePattern
{
    // =========================
    // Implementor
    // =========================
    public interface ITV
    {
        void TurnOn();
        void TurnOff();
        void ChangeChannel(int channel);
    }

    // =========================
    // Concrete Implementor 1
    // =========================
    public class SonyTV : ITV
    {
        public void TurnOn()
        {
            Console.WriteLine("Sony TV is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Sony TV is OFF");
        }

        public void ChangeChannel(int channel)
        {
            Console.WriteLine($"Sony TV changed to channel {channel}");
        }
    }

    // =========================
    // Concrete Implementor 2
    // =========================
    public class SamsungTV : ITV
    {
        public void TurnOn()
        {
            Console.WriteLine("Samsung TV is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Samsung TV is OFF");
        }

        public void ChangeChannel(int channel)
        {
            Console.WriteLine($"Samsung TV changed to channel {channel}");
        }
    }

    // =========================
    // Abstraction
    // =========================
    public abstract class Remote
    {
        protected ITV tv;

        public Remote(ITV tv)
        {
            this.tv = tv;
        }

        public virtual void PowerOn()
        {
            tv.TurnOn();
        }

        public virtual void PowerOff()
        {
            tv.TurnOff();
        }

        public virtual void SetChannel(int channel)
        {
            tv.ChangeChannel(channel);
        }
    }

    // =========================
    // Refined Abstraction 1
    // =========================
    public class BasicRemote : Remote
    {
        public BasicRemote(ITV tv) : base(tv)
        {
        }
    }

    // =========================
    // Refined Abstraction 2
    // =========================
    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(ITV tv) : base(tv)
        {
        }

        public void Mute()
        {
            Console.WriteLine("TV Muted");
        }
    }

    // =========================
    // Client
    // =========================
    class Program
    {
        static void Main(string[] args)
        {
            // Sony TV with Basic Remote
            ITV sony = new SonyTV();
            Remote basicRemote = new BasicRemote(sony);

            basicRemote.PowerOn();
            basicRemote.SetChannel(10);
            basicRemote.PowerOff();

            Console.WriteLine();

            // Samsung TV with Advanced Remote
            ITV samsung = new SamsungTV();
            AdvancedRemote advancedRemote = new AdvancedRemote(samsung);

            advancedRemote.PowerOn();
            advancedRemote.SetChannel(25);
            advancedRemote.Mute();
            advancedRemote.PowerOff();
        }
    }
}