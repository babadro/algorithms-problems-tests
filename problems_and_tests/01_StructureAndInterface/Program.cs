using System;

namespace _01_StructureAndInterface
{
    interface IPromotion
    {
        void promote();
    }

    struct Employee : IPromotion
    {
        public string Name;
        public int JobGrade;
        public void promote()
        {
            JobGrade++;
        }

        public Employee(string name, int jobGrade)
        {
            this.Name = name;
            this.JobGrade = jobGrade;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, JobGrade);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
