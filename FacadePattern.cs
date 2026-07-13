using System;

namespace FacadePattern
{
    // Subsystem 1
    public class Lights
    {
        public void Dim()
        {
            Console.WriteLine("Lights are dimmed.");
        }

        public void On()
        {
            Console.WriteLine("Lights are turned on.");
        }
    }

    // Subsystem 2
    public class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector is ON.");
        }

        public void Off()
        {
            Console.WriteLine("Projector is OFF.");
        }
    }

    // Subsystem 3
    public class SoundSystem
    {
        public void On()
        {
            Console.WriteLine("Sound System is ON.");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Volume set to {volume}.");
        }

        public void Off()
        {
            Console.WriteLine("Sound System is OFF.");
        }
    }

    // Subsystem 4
    public class DvdPlayer
    {
        public void On()
        {
            Console.WriteLine("DVD Player is ON.");
        }

        public void PlayMovie(string movie)
        {
            Console.WriteLine($"Playing: {movie}");
        }

        public void Off()
        {
            Console.WriteLine("DVD Player is OFF.");
        }
    }

    // Facade
    public class HomeTheaterFacade
    {
        private readonly Lights lights = new Lights();
        private readonly Projector projector = new Projector();
        private readonly SoundSystem sound = new SoundSystem();
        private readonly DvdPlayer dvd = new DvdPlayer();

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Preparing Home Theater...\n");

            lights.Dim();
            projector.On();
            sound.On();
            sound.SetVolume(15);
            dvd.On();
            dvd.PlayMovie(movie);

            Console.WriteLine("\nEnjoy your movie!");
        }

        public void EndMovie()
        {
            Console.WriteLine("\nShutting down Home Theater...\n");

            dvd.Off();
            sound.Off();
            projector.Off();
            lights.On();

            Console.WriteLine("Home Theater is back to normal.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HomeTheaterFacade theater = new HomeTheaterFacade();

            theater.WatchMovie("Avengers: Endgame");

            Console.WriteLine();

            theater.EndMovie();
        }
    }
}