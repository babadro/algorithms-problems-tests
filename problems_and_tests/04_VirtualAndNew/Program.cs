using System;

namespace _04_VirtualAndNew
{
    public class BaseClass
    {
        public virtual void OverrideMethod()
        {
            Console.WriteLine("1");
        }

        public void NewMethod()
        {
            Console.WriteLine("2");
        }
    }

    public class InheritedClass : BaseClass
    {
        public override void OverrideMethod()
        {
            Console.WriteLine("3");
        }

        public new void NewMethod()
        {
            Console.WriteLine("4");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myObj = new InheritedClass();
            var myObjAsBaseClass = (BaseClass)myObj;

            // It takes it from inheritedClass
            myObjAsBaseClass.OverrideMethod(); // 3

            // But it takes it from base class
            myObjAsBaseClass.NewMethod(); // 2
        }
    }
}
