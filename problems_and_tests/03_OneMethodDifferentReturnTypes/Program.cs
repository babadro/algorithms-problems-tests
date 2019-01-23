using System;

namespace _03_OneMethodDifferentReturnTypes
{
    class Program
    {
        public class Person { }
        public class Aircraft { }
        public static class Fabric1
        {
            public static Person BuildPerson()
            {
                return new Person();
            }

            public static Aircraft BuildAircraft()
            {
                return new Aircraft();
            }
        }

        // Try to make fabric that has only one method with same abilities.
        //https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/new-constraint
        public static class Fabric2
        {
            public static object BuildObject<T>() where T : new() 
            {
                return new T();
            }
        }

        static void Main(string[] args)
        {
            var personByFabric1 = Fabric1.BuildPerson();
            var aircraftByFabric1 = Fabric1.BuildAircraft();

            var personByFabric2 = Fabric2.BuildObject<Person>();
            var aircraftByFabric2 = Fabric2.BuildObject<Aircraft>();

            Console.WriteLine(personByFabric2 is Person);
            Console.WriteLine(aircraftByFabric2 is Aircraft);
        }
    }
}
