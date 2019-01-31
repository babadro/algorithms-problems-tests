using System;

namespace _06_Urnozo
{
    class ExampleClass
    {
        public int sampleMember;
        public void SampleMethod() { }

        static void Main()
        {
            Type t = typeof(ExampleClass);
            // Alternatively, you could use
            // ExampleClass obj = new ExampleClass();
            // Type t = obj.GetType();

            Console.WriteLine("Methods:");
            System.Reflection.MethodInfo[] methodInfo = t.GetMethods();

            foreach (System.Reflection.MethodInfo mInfo in methodInfo)
                Console.WriteLine(mInfo.ToString());

            Console.WriteLine("Members:");
            System.Reflection.MemberInfo[] memberInfo = t.GetMembers();

            foreach (System.Reflection.MemberInfo mInfo in memberInfo)
                Console.WriteLine(mInfo.ToString());
        }
    }
}
