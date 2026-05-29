using System;

namespace StatePattern
{
    // STATE INTERFACE
    public interface IState
    {
        void InsertCoin();
        void SelectItem();
        void Dispense();
    }

    // STATE 1 : NO COIN
    public class NoCoinState : IState
    {
        private VendingMachine machine;

        public NoCoinState(VendingMachine machine)
        {
            this.machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Coin inserted.");
            machine.SetState(machine.HasCoinState);
        }

        public void SelectItem()
        {
            Console.WriteLine("Insert coin first.");
        }

        public void Dispense()
        {
            Console.WriteLine("Insert coin first.");
        }
    }

    // STATE 2 : HAS COIN
    public class HasCoinState : IState
    {
        private VendingMachine machine;

        public HasCoinState(VendingMachine machine)
        {
            this.machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Coin already inserted.");
        }

        public void SelectItem()
        {
            Console.WriteLine("Item selected.");
            machine.SetState(machine.DispenseState);
        }

        public void Dispense()
        {
            Console.WriteLine("Select an item first.");
        }
    }

    // STATE 3 : DISPENSING
    public class DispenseState : IState
    {
        private VendingMachine machine;

        public DispenseState(VendingMachine machine)
        {
            this.machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Please wait, dispensing item.");
        }

        public void SelectItem()
        {
            Console.WriteLine("Item already selected.");
        }

        public void Dispense()
        {
            Console.WriteLine("Dispensing your item...");
            machine.SetState(machine.NoCoinState);
        }
    }

    // CONTEXT CLASS
    public class VendingMachine
    {
        // AVAILABLE STATES
        public IState NoCoinState { get; private set; }
        public IState HasCoinState { get; private set; }
        public IState DispenseState { get; private set; }

        // CURRENT STATE
        private IState currentState;

        public VendingMachine()
        {
            NoCoinState = new NoCoinState(this);
            HasCoinState = new HasCoinState(this);
            DispenseState = new DispenseState(this);

            currentState = NoCoinState;
        }

        public void SetState(IState state)
        {
            currentState = state;
        }

        public void InsertCoin()
        {
            currentState.InsertCoin();
        }

        public void SelectItem()
        {
            currentState.SelectItem();
        }

        public void DispenseItem()
        {
            currentState.Dispense();
        }
    }

    // CLIENT
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();

            // Invalid action
            vm.SelectItem();

            Console.WriteLine();

            // Proper flow
            vm.InsertCoin();
            vm.SelectItem();
            vm.DispenseItem();

            Console.WriteLine();

            // Invalid transitions
            vm.InsertCoin();
            vm.InsertCoin();

            vm.SelectItem();
            vm.SelectItem();

            vm.DispenseItem();

            Console.WriteLine();

            // Again back to initial state
            vm.DispenseItem();
        }
    }
}