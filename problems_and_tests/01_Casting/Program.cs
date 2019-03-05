using System;

namespace _01_Casting
{
    internal class Employee { }
    internal class Manager : Employee { }
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager();
            PromoteEmployee(m);

            DateTime newYears = new DateTime(2013, 1, 1);
            PromoteEmployee(newYears);
        }

        public static void PromoteEmployee(Object o)
        {
            Employee e = (Employee) o;
        }
    }
}
