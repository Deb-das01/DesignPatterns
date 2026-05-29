using System;

namespace ProxyPatterns
{
    // SUBJECT INTERFACE
    public interface IServer
    {
        void Display();
    }

    // REAL SUBJECT
    public class BankServer : IServer
    {
        public void Display()
        {
            Console.WriteLine("Welcome to Bank Server");
        }
    }

    // PROXY
    public class AtmProxy : IServer
    {
        private IServer server;
        private int passkey;

        public AtmProxy(IServer server, int passkey)
        {
            this.server = server;
            this.passkey = passkey;
        }

        public void Display()
        {
            if (passkey == 123)
            {
                server.Display();
            }
            else
            {
                Console.WriteLine("Incorrect passkey...");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IServer bank = new BankServer();

            IServer atm1 = new AtmProxy(bank, 123);
            atm1.Display();

            IServer atm2 = new AtmProxy(bank, 456);
            atm2.Display();
        }
    }
}