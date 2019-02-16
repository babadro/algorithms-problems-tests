using System;

namespace _02_GenericConstraints
{
    public struct MyStruct
    {

    }

    interface IMyInterface
    {
        void DoSometing();
    }

    public class Sample<T,U> where T : class where U : struct, T
    {
        public T SomethingT { get; set; }
        public U SomethingU { get; set; }

        public Sample(T t, U u)
        {
            SomethingT = t;
            SomethingU = u;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sample<object, int> sample1 = new Sample<object, int>(new object(), 1);
        }
    }
}
