using System;
using System.Collections.Generic;

namespace _10_CollectionsProperty
{
    class Classroom
    {
        private List<string> m_students = new List<string>();
        public List<string> Students { get { return m_students; } }

        public Classroom() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom
            {
                Students = { "Jeff", "Kristin", "Aidan", "Grant" }
            };

            foreach (var student in classroom.Students)
                Console.WriteLine(student);
        }
    }
}
