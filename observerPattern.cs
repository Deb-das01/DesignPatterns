using System;
using System.Collections.Generic;

namespace observerPattern
{
    public interface Iweather
    {
        void register(Iobserver o);
        void deregister(Iobserver o);
        void notifyObservers();   // renamed (notify is reserved keyword)
    }

    public interface Iobserver
    {
        void update(Iweather weatherobj);
    }

    public class weather : Iweather
    {
        private List<Iobserver> lst;
        public int temp, humidity, pressure;
		public int getTemp()=> return temp;
		public int gethumidity()=> return humidity;
		public int getpressure ()=> return pressure;
        public weather()
        {
            lst = new List<Iobserver>();   // fixed type
        }

        public void register(Iobserver ob)
        {
            lst.Add(ob);   // C# uses Add()
        }

        public void deregister(Iobserver ob)
        {
            lst.Remove(ob);   // C# uses Remove()
        }

        public void notifyObservers()
        {
            foreach (var it in lst)   // fixed loop
            {
                it.update(this);
            }
        }

        public void setWeather(int tmp, int hum, int pre)
        {
            this.temp = tmp;
            this.humidity = hum;
            this.pressure = pre;
            notifyObservers();
        }
    }

    public class DisplayStatistics : Iobserver
    {
        public void update(Iweather obj)
        {
            Console.WriteLine(obj.getTemp());
        }
    }

    public class DisplayForecast : Iobserver
    {
        public void update(Iweather obj)
        {
            Console.WriteLine(obj.gethumidity()+"\t"+obj.getpressure());
        }
    }

    public class program
    {
        public static void Main()   // Main must be capital M
        {
            weather wobj = new weather();   // use concrete type to access setWeather

            Iobserver stat = new DisplayStatistics();
            Iobserver cast = new DisplayForecast();

            wobj.register(stat);
            wobj.register(cast);

            wobj.setWeather(2, 3, 4);
            wobj.setWeather(4, 5, 6);
        }
    }
}