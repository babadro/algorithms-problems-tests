using System;

namespace _07_StaticConstructor
{
    public class Bus
    {
        // Static variable used by all Bus instances.
        // Represents the time the first bus of the day starts its route.
        protected static readonly DateTime globalStartTime;

        // Property for the number of each bus.
        protected int RouteNumber { get; set; }

        static Bus()
        {
            globalStartTime = DateTime.Now;
            Console.WriteLine("Static constructor sets global start time to {0}", globalStartTime.ToLongTimeString());
        }

        public Bus(int routNum)
        {
            RouteNumber = RouteNumber;
            Console.WriteLine("Bus #{0} is created.", RouteNumber);
        }

        public void Drive()
        {
            TimeSpan elapsedTime = DateTime.Now - globalStartTime;

            Console.WriteLine("{0} is starting its route {1:N2} minutes after global start time {2}.", this.RouteNumber, elapsedTime.Milliseconds, globalStartTime.ToShortDateString());
        }
    }

    public static class MyStaticClass
    {
        public static int MyStaticProperty { get; set; }

        static MyStaticClass()
        {
            MyStaticProperty = 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bus bus1 = new Bus(71);

            // Create a second bus.
            Bus bus2 = new Bus(72);

            // Send bus1 on its way.
            bus1.Drive();

            // Wait for bus2 to warm up.
            System.Threading.Thread.Sleep(25);

            // Send bus2 on its way.
            bus2.Drive();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
