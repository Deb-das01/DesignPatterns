using System;

namespace AdapterPatternExample
{
    // Target Interface (what client expects)
    public interface ITypeCCharger
    {
        void ChargeWithTypeC();
    }

    // Adaptee (existing incompatible class)
    public class MicroUsbCharger
    {
        public void ChargeWithMicroUsb()
        {
            Console.WriteLine("Charging with Micro-USB...");
        }
    }

    // Adapter (Object Adapter)
    public class MicroUsbToTypeCAdapter : ITypeCCharger
    {
        private MicroUsbCharger _microUsbCharger;

        public MicroUsbToTypeCAdapter(MicroUsbCharger charger)
        {
            _microUsbCharger = charger;
        }

        public void ChargeWithTypeC()
        {
            Console.WriteLine("Converting Type-C to Micro-USB...");
            _microUsbCharger.ChargeWithMicroUsb();
        }
    }

    class Program
    {
        static void Main()
        {
            // Client expects Type-C
            ITypeCCharger charger;

            // We only have Micro-USB charger
            MicroUsbCharger oldCharger = new MicroUsbCharger();

            // Wrap it with adapter
            charger = new MicroUsbToTypeCAdapter(oldCharger);

            charger.ChargeWithTypeC();
        }
    }
}