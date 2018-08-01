using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswersAndQuestions
{
    class A
    {
        public int SomeMethod()
        {
            return 1;
        }

        public void Method1(int a)
        {
            //return "";
        }

        public virtual int Method1()
        {
            return 1;
        }
    }

    class B : A
    {
        public int SomeMethodWrapper()
        {
            return SomeMethod();
        }

        public sealed override int Method1()
        {
            return 25;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayWithNoDefaultValue = Enumerable.Repeat(1, 10).ToArray();
        }
    }
}
